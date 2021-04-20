<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.tvSchema = New System.Windows.Forms.TreeView
        Me.imgListDatabaseSchema = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUrlBase = New System.Windows.Forms.TextBox
        Me.btnInitialize = New System.Windows.Forms.Button
        Me.bgwSchema = New System.ComponentModel.BackgroundWorker
        Me.txtDebugLog = New System.Windows.Forms.TextBox
        Me.btnGetSchema = New System.Windows.Forms.Button
        Me.btnGetUser = New System.Windows.Forms.Button
        Me.bgwUser = New System.ComponentModel.BackgroundWorker
        Me.tabCtrlMain = New System.Windows.Forms.TabControl
        Me.tabConfig = New System.Windows.Forms.TabPage
        Me.grpStartInjection = New System.Windows.Forms.GroupBox
        Me.grpInjectionOptions = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtHeavyTables = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.numMaxJoins = New System.Windows.Forms.NumericUpDown
        Me.numMinJoins = New System.Windows.Forms.NumericUpDown
        Me.numRepeatTests = New System.Windows.Forms.NumericUpDown
        Me.numPauseAfterHeavy = New System.Windows.Forms.NumericUpDown
        Me.numPauseAfterAny = New System.Windows.Forms.NumericUpDown
        Me.numHttpTimeout = New System.Windows.Forms.NumericUpDown
        Me.numMinHeavyTime = New System.Windows.Forms.NumericUpDown
        Me.chkEnableEqualSign = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpBasicConfig = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtStartInjectionWith = New System.Windows.Forms.TextBox
        Me.btnValidateUrl = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtEndInjectionWith = New System.Windows.Forms.TextBox
        Me.chkSSL = New System.Windows.Forms.CheckBox
        Me.rbHttpPost = New System.Windows.Forms.RadioButton
        Me.rbHttpGet = New System.Windows.Forms.RadioButton
        Me.tabCtrlParameters = New System.Windows.Forms.TabControl
        Me.tabParameters = New System.Windows.Forms.TabPage
        Me.dgvHttpParams = New System.Windows.Forms.DataGridView
        Me.colParamName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParamValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInjectable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tabCookies = New System.Windows.Forms.TabPage
        Me.dgvCookies = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabAuthentication = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAuthDomain = New System.Windows.Forms.TextBox
        Me.txtAuthPassword = New System.Windows.Forms.TextBox
        Me.txtAuthUsername = New System.Windows.Forms.TextBox
        Me.rbAuthNone = New System.Windows.Forms.RadioButton
        Me.rbAuthBasic = New System.Windows.Forms.RadioButton
        Me.rbAuthNtlm = New System.Windows.Forms.RadioButton
        Me.rbAuthDigest = New System.Windows.Forms.RadioButton
        Me.tabProxy = New System.Windows.Forms.TabPage
        Me.numProxyPort = New System.Windows.Forms.NumericUpDown
        Me.txtProxyAddress = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbDatabaseEngine = New System.Windows.Forms.ComboBox
        Me.tabSchema = New System.Windows.Forms.TabPage
        Me.tabAccess = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.listBoxData = New System.Windows.Forms.ListBox
        Me.txtRecords = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnGetData = New System.Windows.Forms.Button
        Me.txtColumnName = New System.Windows.Forms.TextBox
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.tabDebug = New System.Windows.Forms.TabPage
        Me.btnSaveLog = New System.Windows.Forms.Button
        Me.btnClearLog = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbVerbosityLevel = New System.Windows.Forms.ComboBox
        Me.menuStripMain = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.statusStripMain = New System.Windows.Forms.StatusStrip
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.bgwData = New System.ComponentModel.BackgroundWorker
        Me.tabCtrlMain.SuspendLayout()
        Me.tabConfig.SuspendLayout()
        Me.grpStartInjection.SuspendLayout()
        Me.grpInjectionOptions.SuspendLayout()
        CType(Me.numMaxJoins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinJoins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRepeatTests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPauseAfterHeavy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPauseAfterAny, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHttpTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinHeavyTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBasicConfig.SuspendLayout()
        Me.tabCtrlParameters.SuspendLayout()
        Me.tabParameters.SuspendLayout()
        CType(Me.dgvHttpParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCookies.SuspendLayout()
        CType(Me.dgvCookies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAuthentication.SuspendLayout()
        Me.tabProxy.SuspendLayout()
        CType(Me.numProxyPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSchema.SuspendLayout()
        Me.tabAccess.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabDebug.SuspendLayout()
        Me.menuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvSchema
        '
        Me.tvSchema.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvSchema.ImageIndex = 0
        Me.tvSchema.ImageList = Me.imgListDatabaseSchema
        Me.tvSchema.Location = New System.Drawing.Point(3, 6)
        Me.tvSchema.Name = "tvSchema"
        Me.tvSchema.SelectedImageIndex = 0
        Me.tvSchema.Size = New System.Drawing.Size(544, 570)
        Me.tvSchema.TabIndex = 8
        '
        'imgListDatabaseSchema
        '
        Me.imgListDatabaseSchema.ImageStream = CType(resources.GetObject("imgListDatabaseSchema.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListDatabaseSchema.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListDatabaseSchema.Images.SetKeyName(0, "BD.png")
        Me.imgListDatabaseSchema.Images.SetKeyName(1, "Tabla.png")
        Me.imgListDatabaseSchema.Images.SetKeyName(2, "Columna.png")
        Me.imgListDatabaseSchema.Images.SetKeyName(3, "Usuario.png")
        Me.imgListDatabaseSchema.Images.SetKeyName(4, "Fichero.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Target base URL:"
        '
        'txtUrlBase
        '
        Me.txtUrlBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUrlBase.Location = New System.Drawing.Point(115, 46)
        Me.txtUrlBase.Name = "txtUrlBase"
        Me.txtUrlBase.Size = New System.Drawing.Size(354, 20)
        Me.txtUrlBase.TabIndex = 9
        Me.txtUrlBase.Text = "http://localhost/retomysql/pista.aspx?id_pista=1"
        '
        'btnInitialize
        '
        Me.btnInitialize.Location = New System.Drawing.Point(22, 32)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(87, 40)
        Me.btnInitialize.TabIndex = 11
        Me.btnInitialize.Text = "Initialize"
        Me.btnInitialize.UseVisualStyleBackColor = True
        '
        'bgwSchema
        '
        '
        'txtDebugLog
        '
        Me.txtDebugLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebugLog.BackColor = System.Drawing.Color.LightYellow
        Me.txtDebugLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebugLog.Location = New System.Drawing.Point(3, 35)
        Me.txtDebugLog.Multiline = True
        Me.txtDebugLog.Name = "txtDebugLog"
        Me.txtDebugLog.ReadOnly = True
        Me.txtDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDebugLog.Size = New System.Drawing.Size(547, 544)
        Me.txtDebugLog.TabIndex = 12
        Me.txtDebugLog.WordWrap = False
        '
        'btnGetSchema
        '
        Me.btnGetSchema.Enabled = False
        Me.btnGetSchema.Location = New System.Drawing.Point(117, 32)
        Me.btnGetSchema.Name = "btnGetSchema"
        Me.btnGetSchema.Size = New System.Drawing.Size(87, 40)
        Me.btnGetSchema.TabIndex = 11
        Me.btnGetSchema.Text = "Get schema"
        Me.btnGetSchema.UseVisualStyleBackColor = True
        '
        'btnGetUser
        '
        Me.btnGetUser.Enabled = False
        Me.btnGetUser.Location = New System.Drawing.Point(210, 32)
        Me.btnGetUser.Name = "btnGetUser"
        Me.btnGetUser.Size = New System.Drawing.Size(87, 40)
        Me.btnGetUser.TabIndex = 11
        Me.btnGetUser.Text = "Get user"
        Me.btnGetUser.UseVisualStyleBackColor = True
        '
        'bgwUser
        '
        '
        'tabCtrlMain
        '
        Me.tabCtrlMain.Controls.Add(Me.tabConfig)
        Me.tabCtrlMain.Controls.Add(Me.tabSchema)
        Me.tabCtrlMain.Controls.Add(Me.tabAccess)
        Me.tabCtrlMain.Controls.Add(Me.tabDebug)
        Me.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCtrlMain.Location = New System.Drawing.Point(0, 24)
        Me.tabCtrlMain.Name = "tabCtrlMain"
        Me.tabCtrlMain.SelectedIndex = 0
        Me.tabCtrlMain.Size = New System.Drawing.Size(561, 608)
        Me.tabCtrlMain.TabIndex = 13
        '
        'tabConfig
        '
        Me.tabConfig.Controls.Add(Me.grpStartInjection)
        Me.tabConfig.Controls.Add(Me.grpInjectionOptions)
        Me.tabConfig.Controls.Add(Me.grpBasicConfig)
        Me.tabConfig.Location = New System.Drawing.Point(4, 22)
        Me.tabConfig.Name = "tabConfig"
        Me.tabConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfig.Size = New System.Drawing.Size(553, 582)
        Me.tabConfig.TabIndex = 0
        Me.tabConfig.Text = "Configuration"
        Me.tabConfig.UseVisualStyleBackColor = True
        '
        'grpStartInjection
        '
        Me.grpStartInjection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStartInjection.Controls.Add(Me.btnInitialize)
        Me.grpStartInjection.Controls.Add(Me.btnGetSchema)
        Me.grpStartInjection.Controls.Add(Me.btnGetUser)
        Me.grpStartInjection.Location = New System.Drawing.Point(12, 476)
        Me.grpStartInjection.Name = "grpStartInjection"
        Me.grpStartInjection.Size = New System.Drawing.Size(533, 100)
        Me.grpStartInjection.TabIndex = 14
        Me.grpStartInjection.TabStop = False
        Me.grpStartInjection.Text = "Start injection"
        '
        'grpInjectionOptions
        '
        Me.grpInjectionOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInjectionOptions.Controls.Add(Me.Label15)
        Me.grpInjectionOptions.Controls.Add(Me.Label14)
        Me.grpInjectionOptions.Controls.Add(Me.Label13)
        Me.grpInjectionOptions.Controls.Add(Me.Label12)
        Me.grpInjectionOptions.Controls.Add(Me.txtHeavyTables)
        Me.grpInjectionOptions.Controls.Add(Me.Label11)
        Me.grpInjectionOptions.Controls.Add(Me.numMaxJoins)
        Me.grpInjectionOptions.Controls.Add(Me.numMinJoins)
        Me.grpInjectionOptions.Controls.Add(Me.numRepeatTests)
        Me.grpInjectionOptions.Controls.Add(Me.numPauseAfterHeavy)
        Me.grpInjectionOptions.Controls.Add(Me.numPauseAfterAny)
        Me.grpInjectionOptions.Controls.Add(Me.numHttpTimeout)
        Me.grpInjectionOptions.Controls.Add(Me.numMinHeavyTime)
        Me.grpInjectionOptions.Controls.Add(Me.chkEnableEqualSign)
        Me.grpInjectionOptions.Controls.Add(Me.Label10)
        Me.grpInjectionOptions.Controls.Add(Me.Label9)
        Me.grpInjectionOptions.Controls.Add(Me.Label8)
        Me.grpInjectionOptions.Controls.Add(Me.Label7)
        Me.grpInjectionOptions.Controls.Add(Me.Label6)
        Me.grpInjectionOptions.Controls.Add(Me.Label5)
        Me.grpInjectionOptions.Controls.Add(Me.Label4)
        Me.grpInjectionOptions.Location = New System.Drawing.Point(12, 290)
        Me.grpInjectionOptions.Name = "grpInjectionOptions"
        Me.grpInjectionOptions.Size = New System.Drawing.Size(533, 180)
        Me.grpInjectionOptions.TabIndex = 13
        Me.grpInjectionOptions.TabStop = False
        Me.grpInjectionOptions.Text = "Injection options"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(230, 105)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "ms"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(230, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "ms"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "ms"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(230, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "ms"
        '
        'txtHeavyTables
        '
        Me.txtHeavyTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeavyTables.Location = New System.Drawing.Point(149, 143)
        Me.txtHeavyTables.Name = "txtHeavyTables"
        Me.txtHeavyTables.Size = New System.Drawing.Size(363, 20)
        Me.txtHeavyTables.TabIndex = 19
        Me.txtHeavyTables.Text = "sys.databases, sysusers, information_schema.columns"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Heavy queries tables:"
        '
        'numMaxJoins
        '
        Me.numMaxJoins.Location = New System.Drawing.Point(435, 77)
        Me.numMaxJoins.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numMaxJoins.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numMaxJoins.Name = "numMaxJoins"
        Me.numMaxJoins.Size = New System.Drawing.Size(77, 20)
        Me.numMaxJoins.TabIndex = 17
        Me.numMaxJoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMaxJoins.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'numMinJoins
        '
        Me.numMinJoins.Location = New System.Drawing.Point(435, 51)
        Me.numMinJoins.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numMinJoins.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numMinJoins.Name = "numMinJoins"
        Me.numMinJoins.Size = New System.Drawing.Size(77, 20)
        Me.numMinJoins.TabIndex = 16
        Me.numMinJoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMinJoins.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'numRepeatTests
        '
        Me.numRepeatTests.Location = New System.Drawing.Point(435, 25)
        Me.numRepeatTests.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numRepeatTests.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRepeatTests.Name = "numRepeatTests"
        Me.numRepeatTests.Size = New System.Drawing.Size(77, 20)
        Me.numRepeatTests.TabIndex = 15
        Me.numRepeatTests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRepeatTests.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'numPauseAfterHeavy
        '
        Me.numPauseAfterHeavy.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numPauseAfterHeavy.Location = New System.Drawing.Point(149, 77)
        Me.numPauseAfterHeavy.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.numPauseAfterHeavy.Name = "numPauseAfterHeavy"
        Me.numPauseAfterHeavy.Size = New System.Drawing.Size(77, 20)
        Me.numPauseAfterHeavy.TabIndex = 14
        Me.numPauseAfterHeavy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numPauseAfterHeavy.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'numPauseAfterAny
        '
        Me.numPauseAfterAny.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numPauseAfterAny.Location = New System.Drawing.Point(149, 103)
        Me.numPauseAfterAny.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.numPauseAfterAny.Name = "numPauseAfterAny"
        Me.numPauseAfterAny.Size = New System.Drawing.Size(77, 20)
        Me.numPauseAfterAny.TabIndex = 14
        Me.numPauseAfterAny.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numPauseAfterAny.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'numHttpTimeout
        '
        Me.numHttpTimeout.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numHttpTimeout.Location = New System.Drawing.Point(149, 51)
        Me.numHttpTimeout.Maximum = New Decimal(New Integer() {200000, 0, 0, 0})
        Me.numHttpTimeout.Name = "numHttpTimeout"
        Me.numHttpTimeout.Size = New System.Drawing.Size(77, 20)
        Me.numHttpTimeout.TabIndex = 14
        Me.numHttpTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numHttpTimeout.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'numMinHeavyTime
        '
        Me.numMinHeavyTime.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numMinHeavyTime.Location = New System.Drawing.Point(149, 25)
        Me.numMinHeavyTime.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.numMinHeavyTime.Name = "numMinHeavyTime"
        Me.numMinHeavyTime.Size = New System.Drawing.Size(77, 20)
        Me.numMinHeavyTime.TabIndex = 14
        Me.numMinHeavyTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMinHeavyTime.Value = New Decimal(New Integer() {4500, 0, 0, 0})
        '
        'chkEnableEqualSign
        '
        Me.chkEnableEqualSign.AutoSize = True
        Me.chkEnableEqualSign.Location = New System.Drawing.Point(322, 104)
        Me.chkEnableEqualSign.Name = "chkEnableEqualSign"
        Me.chkEnableEqualSign.Size = New System.Drawing.Size(157, 17)
        Me.chkEnableEqualSign.TabIndex = 13
        Me.chkEnableEqualSign.Text = "Enable equal sign in selects"
        Me.chkEnableEqualSign.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(319, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Max. joins for queries:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(319, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Min. joins for queries:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(319, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Repeat tests count:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Pause after any query:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Pause after heavy query:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "HTTP request timeout:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Min. heavy query time:"
        '
        'grpBasicConfig
        '
        Me.grpBasicConfig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBasicConfig.Controls.Add(Me.Label22)
        Me.grpBasicConfig.Controls.Add(Me.txtStartInjectionWith)
        Me.grpBasicConfig.Controls.Add(Me.btnValidateUrl)
        Me.grpBasicConfig.Controls.Add(Me.Label21)
        Me.grpBasicConfig.Controls.Add(Me.txtEndInjectionWith)
        Me.grpBasicConfig.Controls.Add(Me.chkSSL)
        Me.grpBasicConfig.Controls.Add(Me.rbHttpPost)
        Me.grpBasicConfig.Controls.Add(Me.rbHttpGet)
        Me.grpBasicConfig.Controls.Add(Me.tabCtrlParameters)
        Me.grpBasicConfig.Controls.Add(Me.Label3)
        Me.grpBasicConfig.Controls.Add(Me.cmbDatabaseEngine)
        Me.grpBasicConfig.Controls.Add(Me.Label1)
        Me.grpBasicConfig.Controls.Add(Me.txtUrlBase)
        Me.grpBasicConfig.Location = New System.Drawing.Point(12, 7)
        Me.grpBasicConfig.Name = "grpBasicConfig"
        Me.grpBasicConfig.Size = New System.Drawing.Size(533, 277)
        Me.grpBasicConfig.TabIndex = 12
        Me.grpBasicConfig.TabStop = False
        Me.grpBasicConfig.Text = "Basic configuration"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(276, 251)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "End injection with:"
        '
        'txtStartInjectionWith
        '
        Me.txtStartInjectionWith.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtStartInjectionWith.Location = New System.Drawing.Point(119, 248)
        Me.txtStartInjectionWith.Name = "txtStartInjectionWith"
        Me.txtStartInjectionWith.Size = New System.Drawing.Size(137, 20)
        Me.txtStartInjectionWith.TabIndex = 20
        '
        'btnValidateUrl
        '
        Me.btnValidateUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidateUrl.Location = New System.Drawing.Point(475, 44)
        Me.btnValidateUrl.Name = "btnValidateUrl"
        Me.btnValidateUrl.Size = New System.Drawing.Size(37, 23)
        Me.btnValidateUrl.TabIndex = 19
        Me.btnValidateUrl.Text = "OK"
        Me.btnValidateUrl.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 251)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Start injection with:"
        '
        'txtEndInjectionWith
        '
        Me.txtEndInjectionWith.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndInjectionWith.Location = New System.Drawing.Point(375, 248)
        Me.txtEndInjectionWith.Name = "txtEndInjectionWith"
        Me.txtEndInjectionWith.Size = New System.Drawing.Size(137, 20)
        Me.txtEndInjectionWith.TabIndex = 17
        '
        'chkSSL
        '
        Me.chkSSL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSSL.AutoSize = True
        Me.chkSSL.Enabled = False
        Me.chkSSL.Location = New System.Drawing.Point(470, 21)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(46, 17)
        Me.chkSSL.TabIndex = 16
        Me.chkSSL.Text = "SSL"
        Me.chkSSL.UseVisualStyleBackColor = True
        '
        'rbHttpPost
        '
        Me.rbHttpPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbHttpPost.AutoSize = True
        Me.rbHttpPost.Location = New System.Drawing.Point(413, 20)
        Me.rbHttpPost.Name = "rbHttpPost"
        Me.rbHttpPost.Size = New System.Drawing.Size(46, 17)
        Me.rbHttpPost.TabIndex = 15
        Me.rbHttpPost.Text = "Post"
        Me.rbHttpPost.UseVisualStyleBackColor = True
        '
        'rbHttpGet
        '
        Me.rbHttpGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbHttpGet.AutoSize = True
        Me.rbHttpGet.Checked = True
        Me.rbHttpGet.Location = New System.Drawing.Point(365, 20)
        Me.rbHttpGet.Name = "rbHttpGet"
        Me.rbHttpGet.Size = New System.Drawing.Size(42, 17)
        Me.rbHttpGet.TabIndex = 14
        Me.rbHttpGet.TabStop = True
        Me.rbHttpGet.Text = "Get"
        Me.rbHttpGet.UseVisualStyleBackColor = True
        '
        'tabCtrlParameters
        '
        Me.tabCtrlParameters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrlParameters.Controls.Add(Me.tabParameters)
        Me.tabCtrlParameters.Controls.Add(Me.tabCookies)
        Me.tabCtrlParameters.Controls.Add(Me.tabAuthentication)
        Me.tabCtrlParameters.Controls.Add(Me.tabProxy)
        Me.tabCtrlParameters.Location = New System.Drawing.Point(20, 72)
        Me.tabCtrlParameters.Name = "tabCtrlParameters"
        Me.tabCtrlParameters.SelectedIndex = 0
        Me.tabCtrlParameters.Size = New System.Drawing.Size(492, 170)
        Me.tabCtrlParameters.TabIndex = 13
        '
        'tabParameters
        '
        Me.tabParameters.Controls.Add(Me.dgvHttpParams)
        Me.tabParameters.Location = New System.Drawing.Point(4, 22)
        Me.tabParameters.Name = "tabParameters"
        Me.tabParameters.Padding = New System.Windows.Forms.Padding(3)
        Me.tabParameters.Size = New System.Drawing.Size(484, 144)
        Me.tabParameters.TabIndex = 0
        Me.tabParameters.Text = "Parameters"
        Me.tabParameters.UseVisualStyleBackColor = True
        '
        'dgvHttpParams
        '
        Me.dgvHttpParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHttpParams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParamName, Me.colParamValue, Me.colInjectable})
        Me.dgvHttpParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHttpParams.Location = New System.Drawing.Point(3, 3)
        Me.dgvHttpParams.Name = "dgvHttpParams"
        Me.dgvHttpParams.Size = New System.Drawing.Size(478, 138)
        Me.dgvHttpParams.TabIndex = 15
        '
        'colParamName
        '
        Me.colParamName.HeaderText = "Name"
        Me.colParamName.Name = "colParamName"
        Me.colParamName.Width = 120
        '
        'colParamValue
        '
        Me.colParamValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colParamValue.HeaderText = "Value"
        Me.colParamValue.Name = "colParamValue"
        '
        'colInjectable
        '
        Me.colInjectable.HeaderText = "Injectable"
        Me.colInjectable.Name = "colInjectable"
        Me.colInjectable.Width = 60
        '
        'tabCookies
        '
        Me.tabCookies.Controls.Add(Me.dgvCookies)
        Me.tabCookies.Location = New System.Drawing.Point(4, 22)
        Me.tabCookies.Name = "tabCookies"
        Me.tabCookies.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCookies.Size = New System.Drawing.Size(484, 144)
        Me.tabCookies.TabIndex = 1
        Me.tabCookies.Text = "Cookies"
        Me.tabCookies.UseVisualStyleBackColor = True
        '
        'dgvCookies
        '
        Me.dgvCookies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCookies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvCookies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCookies.Location = New System.Drawing.Point(3, 3)
        Me.dgvCookies.Name = "dgvCookies"
        Me.dgvCookies.Size = New System.Drawing.Size(478, 138)
        Me.dgvCookies.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'tabAuthentication
        '
        Me.tabAuthentication.Controls.Add(Me.Label18)
        Me.tabAuthentication.Controls.Add(Me.Label17)
        Me.tabAuthentication.Controls.Add(Me.Label16)
        Me.tabAuthentication.Controls.Add(Me.txtAuthDomain)
        Me.tabAuthentication.Controls.Add(Me.txtAuthPassword)
        Me.tabAuthentication.Controls.Add(Me.txtAuthUsername)
        Me.tabAuthentication.Controls.Add(Me.rbAuthNone)
        Me.tabAuthentication.Controls.Add(Me.rbAuthBasic)
        Me.tabAuthentication.Controls.Add(Me.rbAuthNtlm)
        Me.tabAuthentication.Controls.Add(Me.rbAuthDigest)
        Me.tabAuthentication.Location = New System.Drawing.Point(4, 22)
        Me.tabAuthentication.Name = "tabAuthentication"
        Me.tabAuthentication.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAuthentication.Size = New System.Drawing.Size(484, 144)
        Me.tabAuthentication.TabIndex = 2
        Me.tabAuthentication.Text = "Authentication"
        Me.tabAuthentication.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(110, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Domain:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Password:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Username:"
        '
        'txtAuthDomain
        '
        Me.txtAuthDomain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthDomain.Enabled = False
        Me.txtAuthDomain.Location = New System.Drawing.Point(171, 76)
        Me.txtAuthDomain.Name = "txtAuthDomain"
        Me.txtAuthDomain.Size = New System.Drawing.Size(294, 20)
        Me.txtAuthDomain.TabIndex = 6
        '
        'txtAuthPassword
        '
        Me.txtAuthPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthPassword.Enabled = False
        Me.txtAuthPassword.Location = New System.Drawing.Point(171, 50)
        Me.txtAuthPassword.Name = "txtAuthPassword"
        Me.txtAuthPassword.Size = New System.Drawing.Size(294, 20)
        Me.txtAuthPassword.TabIndex = 5
        '
        'txtAuthUsername
        '
        Me.txtAuthUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthUsername.Enabled = False
        Me.txtAuthUsername.Location = New System.Drawing.Point(171, 23)
        Me.txtAuthUsername.Name = "txtAuthUsername"
        Me.txtAuthUsername.Size = New System.Drawing.Size(294, 20)
        Me.txtAuthUsername.TabIndex = 4
        '
        'rbAuthNone
        '
        Me.rbAuthNone.AutoSize = True
        Me.rbAuthNone.Checked = True
        Me.rbAuthNone.Location = New System.Drawing.Point(16, 16)
        Me.rbAuthNone.Name = "rbAuthNone"
        Me.rbAuthNone.Size = New System.Drawing.Size(51, 17)
        Me.rbAuthNone.TabIndex = 0
        Me.rbAuthNone.TabStop = True
        Me.rbAuthNone.Text = "None"
        Me.rbAuthNone.UseVisualStyleBackColor = True
        '
        'rbAuthBasic
        '
        Me.rbAuthBasic.AutoSize = True
        Me.rbAuthBasic.Location = New System.Drawing.Point(16, 39)
        Me.rbAuthBasic.Name = "rbAuthBasic"
        Me.rbAuthBasic.Size = New System.Drawing.Size(51, 17)
        Me.rbAuthBasic.TabIndex = 1
        Me.rbAuthBasic.Text = "Basic"
        Me.rbAuthBasic.UseVisualStyleBackColor = True
        '
        'rbAuthNtlm
        '
        Me.rbAuthNtlm.AutoSize = True
        Me.rbAuthNtlm.Location = New System.Drawing.Point(16, 85)
        Me.rbAuthNtlm.Name = "rbAuthNtlm"
        Me.rbAuthNtlm.Size = New System.Drawing.Size(55, 17)
        Me.rbAuthNtlm.TabIndex = 3
        Me.rbAuthNtlm.Text = "NTLM"
        Me.rbAuthNtlm.UseVisualStyleBackColor = True
        '
        'rbAuthDigest
        '
        Me.rbAuthDigest.AutoSize = True
        Me.rbAuthDigest.Location = New System.Drawing.Point(16, 62)
        Me.rbAuthDigest.Name = "rbAuthDigest"
        Me.rbAuthDigest.Size = New System.Drawing.Size(55, 17)
        Me.rbAuthDigest.TabIndex = 2
        Me.rbAuthDigest.Text = "Digest"
        Me.rbAuthDigest.UseVisualStyleBackColor = True
        '
        'tabProxy
        '
        Me.tabProxy.Controls.Add(Me.numProxyPort)
        Me.tabProxy.Controls.Add(Me.txtProxyAddress)
        Me.tabProxy.Controls.Add(Me.Label20)
        Me.tabProxy.Controls.Add(Me.Label19)
        Me.tabProxy.Location = New System.Drawing.Point(4, 22)
        Me.tabProxy.Name = "tabProxy"
        Me.tabProxy.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProxy.Size = New System.Drawing.Size(484, 144)
        Me.tabProxy.TabIndex = 3
        Me.tabProxy.Text = "Proxy"
        Me.tabProxy.UseVisualStyleBackColor = True
        '
        'numProxyPort
        '
        Me.numProxyPort.Location = New System.Drawing.Point(73, 40)
        Me.numProxyPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numProxyPort.Name = "numProxyPort"
        Me.numProxyPort.Size = New System.Drawing.Size(79, 20)
        Me.numProxyPort.TabIndex = 5
        Me.numProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProxyAddress
        '
        Me.txtProxyAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProxyAddress.Location = New System.Drawing.Point(73, 14)
        Me.txtProxyAddress.Name = "txtProxyAddress"
        Me.txtProxyAddress.Size = New System.Drawing.Size(391, 20)
        Me.txtProxyAddress.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(19, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Address:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(19, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Port:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Database engine:"
        '
        'cmbDatabaseEngine
        '
        Me.cmbDatabaseEngine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDatabaseEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDatabaseEngine.FormattingEnabled = True
        Me.cmbDatabaseEngine.Location = New System.Drawing.Point(115, 19)
        Me.cmbDatabaseEngine.Name = "cmbDatabaseEngine"
        Me.cmbDatabaseEngine.Size = New System.Drawing.Size(208, 21)
        Me.cmbDatabaseEngine.TabIndex = 11
        '
        'tabSchema
        '
        Me.tabSchema.Controls.Add(Me.tvSchema)
        Me.tabSchema.Location = New System.Drawing.Point(4, 22)
        Me.tabSchema.Name = "tabSchema"
        Me.tabSchema.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSchema.Size = New System.Drawing.Size(553, 582)
        Me.tabSchema.TabIndex = 1
        Me.tabSchema.Text = "Database schema"
        Me.tabSchema.UseVisualStyleBackColor = True
        '
        'tabAccess
        '
        Me.tabAccess.Controls.Add(Me.GroupBox2)
        Me.tabAccess.Controls.Add(Me.GroupBox1)
        Me.tabAccess.Location = New System.Drawing.Point(4, 22)
        Me.tabAccess.Name = "tabAccess"
        Me.tabAccess.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAccess.Size = New System.Drawing.Size(553, 582)
        Me.tabAccess.TabIndex = 3
        Me.tabAccess.Text = "Database data"
        Me.tabAccess.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.listBoxData)
        Me.GroupBox2.Controls.Add(Me.txtRecords)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(542, 480)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information"
        '
        'listBoxData
        '
        Me.listBoxData.FormattingEnabled = True
        Me.listBoxData.Location = New System.Drawing.Point(123, 65)
        Me.listBoxData.Name = "listBoxData"
        Me.listBoxData.Size = New System.Drawing.Size(355, 368)
        Me.listBoxData.TabIndex = 21
        '
        'txtRecords
        '
        Me.txtRecords.Location = New System.Drawing.Point(123, 30)
        Me.txtRecords.Name = "txtRecords"
        Me.txtRecords.ReadOnly = True
        Me.txtRecords.Size = New System.Drawing.Size(100, 20)
        Me.txtRecords.TabIndex = 20
        Me.txtRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(26, 65)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 13)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Data:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(25, 33)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(83, 13)
        Me.Label26.TabIndex = 14
        Me.Label26.Text = "Records Found:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGetData)
        Me.GroupBox1.Controls.Add(Me.txtColumnName)
        Me.GroupBox1.Controls.Add(Me.txtTableName)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data to extract"
        '
        'btnGetData
        '
        Me.btnGetData.Enabled = False
        Me.btnGetData.Location = New System.Drawing.Point(388, 24)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(87, 40)
        Me.btnGetData.TabIndex = 18
        Me.btnGetData.Text = "Get data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'txtColumnName
        '
        Me.txtColumnName.Location = New System.Drawing.Point(120, 48)
        Me.txtColumnName.Name = "txtColumnName"
        Me.txtColumnName.Size = New System.Drawing.Size(189, 20)
        Me.txtColumnName.TabIndex = 16
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(120, 24)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(189, 20)
        Me.txtTableName.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(23, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 13)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "Column Name:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(22, 27)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Table Name:"
        '
        'tabDebug
        '
        Me.tabDebug.Controls.Add(Me.btnSaveLog)
        Me.tabDebug.Controls.Add(Me.btnClearLog)
        Me.tabDebug.Controls.Add(Me.Label2)
        Me.tabDebug.Controls.Add(Me.cmbVerbosityLevel)
        Me.tabDebug.Controls.Add(Me.txtDebugLog)
        Me.tabDebug.Location = New System.Drawing.Point(4, 22)
        Me.tabDebug.Name = "tabDebug"
        Me.tabDebug.Size = New System.Drawing.Size(553, 582)
        Me.tabDebug.TabIndex = 2
        Me.tabDebug.Text = "Debug log"
        Me.tabDebug.UseVisualStyleBackColor = True
        '
        'btnSaveLog
        '
        Me.btnSaveLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveLog.Location = New System.Drawing.Point(389, 6)
        Me.btnSaveLog.Name = "btnSaveLog"
        Me.btnSaveLog.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveLog.TabIndex = 16
        Me.btnSaveLog.Text = "Save as..."
        Me.btnSaveLog.UseVisualStyleBackColor = True
        '
        'btnClearLog
        '
        Me.btnClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLog.Location = New System.Drawing.Point(470, 6)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(75, 23)
        Me.btnClearLog.TabIndex = 15
        Me.btnClearLog.Text = "Clear log"
        Me.btnClearLog.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Verbosity level:"
        '
        'cmbVerbosityLevel
        '
        Me.cmbVerbosityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVerbosityLevel.FormattingEnabled = True
        Me.cmbVerbosityLevel.Items.AddRange(New Object() {"0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100"})
        Me.cmbVerbosityLevel.Location = New System.Drawing.Point(88, 8)
        Me.cmbVerbosityLevel.MaxDropDownItems = 15
        Me.cmbVerbosityLevel.Name = "cmbVerbosityLevel"
        Me.cmbVerbosityLevel.Size = New System.Drawing.Size(70, 21)
        Me.cmbVerbosityLevel.TabIndex = 13
        '
        'menuStripMain
        '
        Me.menuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.menuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.menuStripMain.Name = "menuStripMain"
        Me.menuStripMain.Size = New System.Drawing.Size(561, 24)
        Me.menuStripMain.TabIndex = 14
        Me.menuStripMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'statusStripMain
        '
        Me.statusStripMain.Location = New System.Drawing.Point(0, 632)
        Me.statusStripMain.Name = "statusStripMain"
        Me.statusStripMain.Size = New System.Drawing.Size(561, 22)
        Me.statusStripMain.TabIndex = 15
        Me.statusStripMain.Text = "StatusStrip1"
        '
        'bgwData
        '
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 654)
        Me.Controls.Add(Me.tabCtrlMain)
        Me.Controls.Add(Me.menuStripMain)
        Me.Controls.Add(Me.statusStripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStripMain
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marathon Tool"
        Me.tabCtrlMain.ResumeLayout(False)
        Me.tabConfig.ResumeLayout(False)
        Me.grpStartInjection.ResumeLayout(False)
        Me.grpInjectionOptions.ResumeLayout(False)
        Me.grpInjectionOptions.PerformLayout()
        CType(Me.numMaxJoins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinJoins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRepeatTests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPauseAfterHeavy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPauseAfterAny, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHttpTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinHeavyTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBasicConfig.ResumeLayout(False)
        Me.grpBasicConfig.PerformLayout()
        Me.tabCtrlParameters.ResumeLayout(False)
        Me.tabParameters.ResumeLayout(False)
        CType(Me.dgvHttpParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCookies.ResumeLayout(False)
        CType(Me.dgvCookies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAuthentication.ResumeLayout(False)
        Me.tabAuthentication.PerformLayout()
        Me.tabProxy.ResumeLayout(False)
        Me.tabProxy.PerformLayout()
        CType(Me.numProxyPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSchema.ResumeLayout(False)
        Me.tabAccess.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabDebug.ResumeLayout(False)
        Me.tabDebug.PerformLayout()
        Me.menuStripMain.ResumeLayout(False)
        Me.menuStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvSchema As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUrlBase As System.Windows.Forms.TextBox
    Friend WithEvents btnInitialize As System.Windows.Forms.Button
    Friend WithEvents bgwSchema As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtDebugLog As System.Windows.Forms.TextBox
    Friend WithEvents imgListDatabaseSchema As System.Windows.Forms.ImageList
    Friend WithEvents btnGetSchema As System.Windows.Forms.Button
    Friend WithEvents btnGetUser As System.Windows.Forms.Button
    Friend WithEvents bgwUser As System.ComponentModel.BackgroundWorker
    Friend WithEvents tabCtrlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabConfig As System.Windows.Forms.TabPage
    Friend WithEvents tabSchema As System.Windows.Forms.TabPage
    Friend WithEvents tabDebug As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVerbosityLevel As System.Windows.Forms.ComboBox
    Friend WithEvents btnClearLog As System.Windows.Forms.Button
    Friend WithEvents menuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpBasicConfig As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDatabaseEngine As System.Windows.Forms.ComboBox
    Friend WithEvents statusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents grpInjectionOptions As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkEnableEqualSign As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numPauseAfterHeavy As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPauseAfterAny As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHttpTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMinHeavyTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numMaxJoins As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMinJoins As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRepeatTests As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpStartInjection As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHeavyTables As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvHttpParams As System.Windows.Forms.DataGridView
    Friend WithEvents tabCtrlParameters As System.Windows.Forms.TabControl
    Friend WithEvents tabParameters As System.Windows.Forms.TabPage
    Friend WithEvents tabCookies As System.Windows.Forms.TabPage
    Friend WithEvents dgvCookies As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabAuthentication As System.Windows.Forms.TabPage
    Friend WithEvents rbAuthNtlm As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuthDigest As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuthBasic As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuthNone As System.Windows.Forms.RadioButton
    Friend WithEvents tabProxy As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAuthDomain As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents numProxyPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbHttpPost As System.Windows.Forms.RadioButton
    Friend WithEvents rbHttpGet As System.Windows.Forms.RadioButton
    Friend WithEvents chkSSL As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtEndInjectionWith As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveLog As System.Windows.Forms.Button
    Friend WithEvents colParamName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParamValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInjectable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnValidateUrl As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtStartInjectionWith As System.Windows.Forms.TextBox
    Friend WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabAccess As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents txtColumnName As System.Windows.Forms.TextBox
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bgwData As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents listBoxData As System.Windows.Forms.ListBox
    Friend WithEvents txtRecords As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
