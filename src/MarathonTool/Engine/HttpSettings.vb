''' <summary>
''' Contains a set of configuration values to use when making HTTP requests
''' </summary>
Public Class HttpSettings
    Private m_TargetBaseUrl As String

    Private m_AppendStartText As String = ""
    Private m_AppendEndText As String = ""

    Private m_UseSSL As Boolean = False
    Private m_UsePostMethod As Boolean = False

    Private m_HttpParams As Collections.Specialized.NameValueCollection
    Private m_InjectableHttpParamName As String
    Private m_Cookies As Collections.Specialized.NameValueCollection

    Private m_Authentication As AuthenticationType = AuthenticationType.None
    Private m_UserName As String = ""
    Private m_Password As String = ""
    Private m_Domain As String = ""

    Private m_ProxyAddress As String = ""
    Private m_ProxyPort As Integer

    Public Enum AuthenticationType
        None
        Basic
        Digest
        Ntlm
    End Enum

    ''' <summary>
    ''' Gets or sets the target base URL (without parameters)
    ''' </summary>
    Public Property TargetBaseUrl() As String
        Get
            Return Me.m_TargetBaseUrl
        End Get
        Set(ByVal value As String)
            Me.m_TargetBaseUrl = value
            m_UseSSL = Me.m_TargetBaseUrl.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text to be added at the end of the injection string
    ''' </summary>
    Public Property AppendEndText() As String
        Get
            Return Me.m_AppendEndText
        End Get
        Set(ByVal value As String)
            Me.m_AppendEndText = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text to be added before the injection string
    ''' </summary>
    Public Property AppendStartText() As String
        Get
            Return Me.m_AppendStartText
        End Get
        Set(ByVal value As String)
            Me.m_AppendStartText = value
        End Set
    End Property

    ''' <summary>
    ''' Returns true if the requests needs to be sent using SSL
    ''' </summary>
    Public ReadOnly Property UseSSL() As Boolean
        Get
            Return Me.m_UseSSL
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the method for the HTTP requests (POST if true or GET if false)
    ''' </summary>
    Public Property UsePostMethod() As Boolean
        Get
            Return Me.m_UsePostMethod
        End Get
        Set(ByVal value As Boolean)
            Me.m_UsePostMethod = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the collection of HTTP parameters to be sent in each request
    ''' </summary>
    Public Property HttpParams() As Collections.Specialized.NameValueCollection
        Get
            Return Me.m_HttpParams
        End Get
        Set(ByVal value As Collections.Specialized.NameValueCollection)
            Me.m_HttpParams = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the name of the parameter vulnerable to SQL injection that will be used
    ''' </summary>
    Public Property InjectableHttpParamName() As String
        Get
            Return Me.m_InjectableHttpParamName
        End Get
        Set(ByVal value As String)
            Me.m_InjectableHttpParamName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the collection of cookies to be sent in each request
    ''' </summary>
    Public Property Cookies() As Collections.Specialized.NameValueCollection
        Get
            Return Me.m_Cookies
        End Get
        Set(ByVal value As Collections.Specialized.NameValueCollection)
            Me.m_Cookies = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the authentication type
    ''' </summary>
    Public Property Authentication() As AuthenticationType
        Get
            Return Me.m_Authentication
        End Get
        Set(ByVal value As AuthenticationType)
            Me.m_Authentication = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the authentication username
    ''' </summary>
    Public Property UserName() As String
        Get
            Return Me.m_UserName
        End Get
        Set(ByVal value As String)
            Me.m_UserName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the authentication password
    ''' </summary>
    Public Property Password() As String
        Get
            Return Me.m_Password
        End Get
        Set(ByVal value As String)
            Me.m_Password = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the authentication domain used by NTLM mode
    ''' </summary>
    Public Property Domain() As String
        Get
            Return Me.m_Domain
        End Get
        Set(ByVal value As String)
            Me.m_Domain = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the proxy address
    ''' </summary>
    Public Property ProxyAddress() As String
        Get
            Return Me.m_ProxyAddress
        End Get
        Set(ByVal value As String)
            Me.m_ProxyAddress = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the proxy port number
    ''' </summary>
    Public Property ProxyPort() As Integer
        Get
            Return Me.m_ProxyPort
        End Get
        Set(ByVal value As Integer)
            Me.m_ProxyPort = value
        End Set
    End Property

End Class
