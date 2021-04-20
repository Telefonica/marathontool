Public Class FormMain

    Private WithEvents m_Engine As CatalogExtractorEngine

    Private m_VerbosityLevel As Integer

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName + "  (version " + Application.ProductVersion + ")"

        Me.cmbVerbosityLevel.SelectedIndex = Me.cmbVerbosityLevel.FindStringExact("90")

        Me.cmbDatabaseEngine.Items.Add(New SqlServerExtractor)
        Me.cmbDatabaseEngine.Items.Add(New MySQLExtractor)
        Me.cmbDatabaseEngine.Items.Add(New OracleExtractor)
        Me.cmbDatabaseEngine.Items.Add(New AccessExtractor(1))
        Me.cmbDatabaseEngine.Items.Add(New AccessExtractor(2))

        Me.cmbDatabaseEngine.SelectedIndex = 0
        Me.txtUrlBase.Text = ""

        Me.tabCtrlMain.TabPages.Remove(Me.tabAccess)

        'MySQL
        'Me.cmbDatabaseEngine.SelectedIndex = 1
        'Me.txtUrlBase.Text = "http://localhost/retomysql/pista.aspx?id_pista=1"

        ''SQL Server 2000
        'Me.cmbDatabaseEngine.SelectedIndex = 0
        'Me.txtUrlBase.Text = "http://blind.elladodelmal.com/sql2000/pista.aspx?id_pista=1"
    End Sub


    Private Sub cmbDatabaseEngine_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDatabaseEngine.SelectedIndexChanged
        If Me.cmbDatabaseEngine.SelectedIndex < 0 Then Exit Sub
        Dim db As ISpecificDatabaseExtractor = CType(Me.cmbDatabaseEngine.SelectedItem, ISpecificDatabaseExtractor)
        Me.txtHeavyTables.Text = db.DefaultTableNames

        If TypeOf db Is AccessExtractor Then
            Me.tabCtrlMain.TabPages.Remove(Me.tabSchema)
            Me.tabCtrlMain.TabPages.Remove(Me.tabAccess)
            Me.tabCtrlMain.TabPages.Insert(1, Me.tabAccess)
        Else
            If Me.tabCtrlMain.TabPages(1).Name = "tabAccess" Then
                Me.tabCtrlMain.TabPages.Remove(Me.tabAccess)
                Me.tabCtrlMain.TabPages.Insert(1, Me.tabSchema)
            End If
        End If
    End Sub

    Private Sub btnValidateUrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidateUrl.Click
        Try
            Me.ValidateURL()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error validating URL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValidateURL()
        Dim url As String = Me.txtUrlBase.Text

        If String.IsNullOrEmpty(url) Then Throw New ApplicationException("The URL is empty")

        If url.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase) Then
            Me.chkSSL.Checked = True
        ElseIf url.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) Then
            Me.chkSSL.Checked = False
        Else
            url = "http://" + url
            Me.chkSSL.Checked = False
        End If

        If url.Contains("?") Then
            Try
                Me.dgvHttpParams.Rows.Clear()

                For Each param As String In url.Split("?"c)(1).Split("&"c)
                    Dim params As String() = param.Split("="c)
                    Dim name As String = params(0)

                    If Not String.IsNullOrEmpty(name) Then
                        Dim value As String = ""
                        If params.Length > 1 Then value = params(1)

                        Me.dgvHttpParams.Rows.Add(name, value, False)
                    End If
                Next
            Catch ex As Exception
                Throw New ApplicationException("Error parsing the URL", ex)
            End Try
            url = url.Split("?"c)(0)
        End If

        Dim uri As New Uri(url, UriKind.Absolute)
        Me.txtUrlBase.Text = uri.ToString()
    End Sub

    Private m_ChangingParamsCheckboxes As Boolean = False

    Private Sub dgvHttpParams_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHttpParams.CellValueChanged
        If Me.m_ChangingParamsCheckboxes OrElse e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = Me.colInjectable.Index Then
            If CBool(Me.dgvHttpParams.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True Then
                Me.m_ChangingParamsCheckboxes = True
                For Each row As DataGridViewRow In Me.dgvHttpParams.Rows
                    If row.Index <> e.RowIndex Then row.Cells(e.ColumnIndex).Value = False
                Next
                Me.m_ChangingParamsCheckboxes = False
            End If
        End If
    End Sub


    Private Shared Function GetNameValueCollection(ByVal dgv As DataGridView) As Specialized.NameValueCollection
        Dim params As New Specialized.NameValueCollection

        For Each row As DataGridViewRow In dgv.Rows
            Dim name As String = CStr(row.Cells(0).Value)
            Dim value As String = CStr(row.Cells(1).Value)
            If Not String.IsNullOrEmpty(name) AndAlso Not String.IsNullOrEmpty(value) Then
                params.Add(name, value)
            End If
        Next
        Return params
    End Function

    Private Function GetInjectableParamName() As String
        For Each row As DataGridViewRow In Me.dgvHttpParams.Rows
            If CBool(row.Cells(Me.colInjectable.Index).Value) = True Then
                Return CStr(row.Cells(Me.colParamName.Index).Value)
            End If
        Next

        If Me.dgvHttpParams.Rows.Count = 2 Then   'Including the new row
            Me.dgvHttpParams.Rows(0).Cells(Me.colInjectable.Index).Value = True
            Return CStr(Me.dgvHttpParams.Rows(0).Cells(Me.colParamName.Index).Value)
        Else
            Throw New ApplicationException("Injectable parameter name is missing")
        End If
    End Function


    Private Sub btnInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitialize.Click
        Try
            Me.ValidateURL()

            Dim db As ISpecificDatabaseExtractor = CType(Me.cmbDatabaseEngine.SelectedItem, ISpecificDatabaseExtractor)

            Dim engineSettings As New EngineSettings
            With engineSettings
                .MinHeavyQueryTime = CInt(Me.numMinHeavyTime.Value)
                .HttpTimeout = CInt(Me.numHttpTimeout.Value)
                .PauseTimeAfterHeavyQuery = CInt(Me.numPauseAfterHeavy.Value)
                .PauseTimeAfterAnyQuery = CInt(Me.numPauseAfterAny.Value)

                .RepeatTestCount = CInt(Me.numRepeatTests.Value)
                .MinJoins = CInt(Me.numMinJoins.Value)
                .MaxJoins = CInt(Me.numMaxJoins.Value)
                .EnableEqualInSelects = Me.chkEnableEqualSign.Checked

                .HeavyTableNames = Me.txtHeavyTables.Text.Split(","c)
            End With

            Dim httpSettings As New HttpSettings
            With httpSettings
                .TargetBaseUrl = Me.txtUrlBase.Text

                .AppendStartText = Me.txtStartInjectionWith.Text
                .AppendEndText = Me.txtEndInjectionWith.Text

                .UsePostMethod = Me.rbHttpPost.Checked

                .HttpParams = GetNameValueCollection(Me.dgvHttpParams)
                .Cookies = GetNameValueCollection(Me.dgvCookies)

                .InjectableHttpParamName = Me.GetInjectableParamName

                .ProxyAddress = Me.txtProxyAddress.Text
                .ProxyPort = CInt(Me.numProxyPort.Value)

                If Me.rbAuthNone.Checked Then
                    .Authentication = MarathonTool.HttpSettings.AuthenticationType.None
                ElseIf Me.rbAuthBasic.Checked Then
                    .Authentication = MarathonTool.HttpSettings.AuthenticationType.Basic
                    .UserName = Me.txtAuthUsername.Text
                    .Password = Me.txtAuthPassword.Text
                ElseIf Me.rbAuthDigest.Checked Then
                    .Authentication = MarathonTool.HttpSettings.AuthenticationType.Digest
                    .UserName = Me.txtAuthUsername.Text
                    .Password = Me.txtAuthPassword.Text
                ElseIf Me.rbAuthNtlm.Checked Then
                    .Authentication = MarathonTool.HttpSettings.AuthenticationType.Ntlm
                    .UserName = Me.txtAuthUsername.Text
                    .Password = Me.txtAuthPassword.Text
                    .Domain = Me.txtAuthDomain.Text
                End If
            End With

            If TypeOf db Is MySQLExtractor Then
                m_Engine = New MySQLCatalogExtractorEngine(httpSettings, engineSettings, db)
            ElseIf TypeOf db Is AccessExtractor Then
                m_Engine = New AccessExtractorEngine(httpSettings, engineSettings, db)
            Else
                m_Engine = New CatalogExtractorEngine(httpSettings, engineSettings, db)
            End If


            Me.tvSchema.Nodes.Clear()
            With Me.tvSchema.Nodes
                '.Add("Version", "Version = ?", 0, 0)
                .Add("User", "User = ?", 3, 3)
                '.Add("Files", "FILES", 0, 0)
                .Add("Tables", "TABLES", 0, 0)
            End With

            Me.EnableControls(False)

            If TypeOf db Is AccessExtractor Then
                Me.btnGetData.Enabled = True
                Me.btnGetUser.Enabled = False
                Me.btnGetSchema.Enabled = False
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnableControls(ByVal enable As Boolean)
        Me.btnGetSchema.Enabled = Not enable
        Me.btnGetUser.Enabled = Not enable
        Me.btnInitialize.Enabled = enable
        Me.grpInjectionOptions.Enabled = enable
        Me.grpBasicConfig.Enabled = enable
    End Sub



    Private Sub btnGetSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSchema.Click
        Me.bgwSchema.RunWorkerAsync()
    End Sub

    Private Sub btnGetUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUser.Click
        Me.bgwUser.RunWorkerAsync()
    End Sub


    Private Sub bgwSchema_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwSchema.DoWork
        Me.SetButtonsEnabled(False)

        Dim x As Object = Me.m_Engine.GetTableIDs()
        MessageBox.Show("Injection completed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.SetButtonsEnabled(True)
    End Sub

    Private Sub bgwUser_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwUser.DoWork
        Me.SetButtonsEnabled(False)

        Me.SetUserName(Me.m_Engine.GetUserName())

        Me.SetButtonsEnabled(True)
    End Sub

    Private Sub m_Engine_NewTableIDFound(ByVal sender As Object, ByVal e As TableEventArgs) Handles m_Engine.NewTableIDFound
        Me.AddTableNode(e.TableID)
        Me.m_Engine.GetTableName(e.TableID)
        Me.m_Engine.GetColumnIDs(e.TableID)
    End Sub

    Private Sub m_Engine_NewTableNameFound(ByVal sender As Object, ByVal e As TableEventArgs) Handles m_Engine.NewTableNameFound
        Me.SetTableName(e.TableID, e.TableName)
    End Sub



#Region " Update user interface "
    Private Sub m_Engine_DebugEvent(ByVal sender As Object, ByVal e As DebugEventArgs) Handles m_Engine.DebugEvent
        If e.VerbosityLevel <= Me.m_VerbosityLevel Then
            Me.AddDebugMessage(e.ToString)
        End If
    End Sub


    Delegate Sub SetButtonsEnabledCallback(ByVal enabled As Boolean)

    Private Sub SetButtonsEnabled(ByVal enabled As Boolean)
        If Me.btnGetSchema.InvokeRequired Then
            Dim cbk As New SetButtonsEnabledCallback(AddressOf SetButtonsEnabled)
            Me.Invoke(cbk, New Object() {enabled})
        Else
            Me.btnGetSchema.Enabled = enabled
            Me.btnGetUser.Enabled = enabled
            Me.btnInitialize.Enabled = enabled

            If enabled Then Me.EnableControls(True)
        End If
    End Sub


    Delegate Sub AddDebugMessageCallback(ByVal message As String)

    Private Sub AddDebugMessage(ByVal message As String)
        If Me.txtDebugLog.InvokeRequired Then
            Dim cbk As New AddDebugMessageCallback(AddressOf AddDebugMessage)
            Me.Invoke(cbk, New Object() {message})
        Else
            Me.txtDebugLog.AppendText(message + vbCrLf)
            Me.txtDebugLog.SelectionStart = Me.txtDebugLog.Text.Length
            Me.txtDebugLog.ScrollToCaret()
        End If
    End Sub



    Delegate Sub AddTableNodeCallback(ByVal tableID As Object)

    Private Sub AddTableNode(ByVal tableID As Object)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New AddTableNodeCallback(AddressOf AddTableNode)
            Me.Invoke(cbk, New Object() {tableID})
        Else
            Me.tvSchema.Nodes("Tables").Nodes.Add(tableID.ToString, "[ID=" + tableID.ToString + "]", 1, 1).EnsureVisible()
        End If
    End Sub

    Delegate Sub SetTableNameCallback(ByVal tableID As Object, ByVal name As String)

    Private Sub SetTableName(ByVal tableID As Object, ByVal name As String)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New SetTableNameCallback(AddressOf SetTableName)
            Me.Invoke(cbk, New Object() {tableID, name})
        Else
            Me.tvSchema.Nodes("Tables").Nodes(tableID.ToString).Text = name
        End If
    End Sub

    Delegate Sub AddColumnNodeCallback(ByVal tableID As Object, ByVal columnID As Long)

    Private Sub AddColumnNode(ByVal tableID As Object, ByVal columnID As Long)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New AddColumnNodeCallback(AddressOf AddColumnNode)
            Me.Invoke(cbk, New Object() {tableID, columnID})
        Else
            Me.tvSchema.Nodes("Tables").Nodes(tableID.ToString).Nodes.Add(columnID.ToString, "[ID=" + columnID.ToString + "]", 2, 2)
        End If
    End Sub

    Delegate Sub SetColumnNameCallback(ByVal tableID As Object, ByVal columnID As Long, ByVal name As String)

    Private Sub SetColumnName(ByVal tableID As Object, ByVal columnID As Long, ByVal name As String)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New SetColumnNameCallback(AddressOf SetColumnName)
            Me.Invoke(cbk, New Object() {tableID, columnID, name})
        Else
            Me.tvSchema.Nodes("Tables").Nodes(tableID.ToString).Nodes(columnID.ToString).Text = name
        End If
    End Sub

    Delegate Sub SetColumnTypeCallback(ByVal tableID As Object, ByVal columnID As Long, ByVal type As SqlDbType)

    Private Sub SetColumnType(ByVal tableID As Object, ByVal columnID As Long, ByVal type As SqlDbType)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New SetColumnTypeCallback(AddressOf SetColumnType)
            Me.Invoke(cbk, New Object() {tableID, columnID, type})
        Else
            Me.tvSchema.Nodes("Tables").Nodes(tableID.ToString).Nodes(columnID.ToString).Text += " [" + type.ToString + "]"
        End If
    End Sub

    Delegate Sub SetUserNameCallback(ByVal name As String)

    Private Sub SetUserName(ByVal name As String)
        If Me.tvSchema.InvokeRequired Then
            Dim cbk As New SetUserNameCallback(AddressOf SetUserName)
            Me.Invoke(cbk, New Object() {name})
        Else
            Me.tvSchema.Nodes("User").Text = "User = " + name
        End If
    End Sub

    Private Sub m_Engine_NewColumnIDFound(ByVal sender As Object, ByVal e As ColumnEventArgs) Handles m_Engine.NewColumnIDFound
        Me.AddColumnNode(e.TableID, e.ColumnID)
        m_Engine.GetColumnName(e.TableID, e.ColumnID)
        m_Engine.GetColumnType(e.TableID, e.ColumnID)
    End Sub

    Private Sub m_Engine_NewColumnNameFound(ByVal sender As Object, ByVal e As ColumnEventArgs) Handles m_Engine.NewColumnNameFound
        Me.SetColumnName(e.TableID, e.ColumnID, e.ColumnName)
    End Sub

    Private Sub m_Engine_NewColumnTypeFound(ByVal sender As Object, ByVal e As ColumnEventArgs) Handles m_Engine.NewColumnTypeFound
        Me.SetColumnType(e.TableID, e.ColumnID, e.ColumnType)
    End Sub

    Private Sub m_Engine_RecordsFound(ByVal sender As Object, ByVal e As MessageEventArgs) Handles m_Engine.RecordsFound
        Me.SetNumberRecords(e.Message)
    End Sub

    Private Sub m_Engine_RecordValueFound(ByVal sender As Object, ByVal e As MessageEventArgs) Handles m_Engine.RecordValueFound
        Me.SetRecordValue(e.Message)
    End Sub

#End Region


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Do you want to exit the application?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3) <> Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbVerbosityLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbVerbosityLevel.SelectedIndexChanged
        Me.m_VerbosityLevel = CInt(Me.cmbVerbosityLevel.SelectedItem)
    End Sub

    Private Sub btnClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLog.Click
        If MessageBox.Show("Do you really want to clear the log?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.Yes Then
            Me.txtDebugLog.Clear()
        End If
    End Sub



    Private Sub rbAuthentication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAuthNtlm.CheckedChanged, rbAuthDigest.CheckedChanged, rbAuthBasic.CheckedChanged
        If Me.rbAuthNone.Checked Then
            Me.txtAuthUsername.Enabled = False
            Me.txtAuthPassword.Enabled = False
            Me.txtAuthDomain.Enabled = False
        ElseIf Me.rbAuthBasic.Checked OrElse Me.rbAuthDigest.Checked Then
            Me.txtAuthUsername.Enabled = True
            Me.txtAuthPassword.Enabled = True
            Me.txtAuthDomain.Enabled = False
        ElseIf Me.rbAuthNtlm.Checked Then
            Me.txtAuthUsername.Enabled = True
            Me.txtAuthPassword.Enabled = True
            Me.txtAuthDomain.Enabled = True
        End If
    End Sub

    Private Sub btnSaveLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLog.Click
        With Me.saveFileDialog
            .DefaultExt = ".txt"
            .FileName = Application.ProductName + " log"
            .Filter = "Text files (*.txt)|*.txt|All files|*.*"
            .Title = "Save log file"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim log As String = Me.txtDebugLog.Text

                Try
                    Dim fs As IO.Stream = .OpenFile()
                    Dim sw As New IO.StreamWriter(fs)
                    sw.Write(log)
                    sw.Close()
                    fs.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End With


    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New FormAbout
        frm.ShowDialog()
    End Sub

 
    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        tableName = Me.txtTableName.Text
        columnName = Me.txtColumnName.Text       

        If String.IsNullOrEmpty(tableName) Then
            MessageBox.Show("Table name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(columnName) Then
            MessageBox.Show("Column name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)        
        Else
            bgwData.RunWorkerAsync()
        End If
    End Sub

    Private tableName As String
    Private columnName As String    

    Private Sub bgwData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwData.DoWork
        Me.SetBGetDataEnabled(False)

        Dim access As AccessExtractorEngine = CType(Me.m_Engine, AccessExtractorEngine)
        access.GetData(tableName, columnName)

        Me.SetBGetDataEnabled(True)
    End Sub

    Delegate Sub SetGetDataEnabledCallback(ByVal enabled As Boolean)
    Delegate Sub SetNumberRecordsCallback(ByVal records As String)
    Delegate Sub SetRecordValueCallback(ByVal records As String)

    Private Sub SetBGetDataEnabled(ByVal enabled As Boolean)
        If Me.btnGetData.InvokeRequired Then
            Dim cbk As New SetGetDataEnabledCallback(AddressOf SetBGetDataEnabled)
            Me.Invoke(cbk, New Object() {enabled})
        Else
            Me.btnGetData.Enabled = enabled
            If enabled Then Me.EnableControls(True)
        End If
    End Sub

    Private Sub SetNumberRecords(ByVal records As String)
        If Me.txtRecords.InvokeRequired Then
            Dim cbk As New SetNumberRecordsCallback(AddressOf SetNumberRecords)
            Me.Invoke(cbk, New Object() {records})
        Else
            Me.txtRecords.Text = records
        End If
    End Sub

    Private Sub SetRecordValue(ByVal record As String)
        If Me.txtRecords.InvokeRequired Then
            Dim cbk As New SetRecordValueCallback(AddressOf SetRecordValue)
            Me.Invoke(cbk, New Object() {record})
        Else
            Me.listBoxData.Items.Add(record)
        End If
    End Sub

   
End Class