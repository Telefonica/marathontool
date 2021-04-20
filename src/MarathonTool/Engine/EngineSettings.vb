''' <summary>
''' Contains a set of configuration values that will be used by the injection engine
''' </summary>
Public Class EngineSettings
    Private m_MinJoins As Integer = 3
    Private m_MaxJoins As Integer = 15

    Private m_PauseTimeAfterHeavyQuery As Integer = 4000
    Private m_PauseTimeAfterAnyQuery As Integer = 200

    Private m_MinHeavyQueryTime As Integer = 3000
    Private m_HttpTimeout As Integer = 4000

    Private m_EnableEqualInSelects As Boolean = False
    Private m_RepeatTestCount As Integer = 2

    Private m_HeavyTableNames As String() = {"sys.databases", "sysusers"}


    ''' <summary>
    ''' Gets or sets the minimum number of times to join the tables in the heavy queries
    ''' </summary>
    Public Property MinJoins() As Integer
        Get
            Return Me.m_MinJoins
        End Get
        Set(ByVal value As Integer)
            Me.m_MinJoins = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the maximum number of times to join the tables in the heavy queries
    ''' </summary>
    Public Property MaxJoins() As Integer
        Get
            Return Me.m_MaxJoins
        End Get
        Set(ByVal value As Integer)
            Me.m_MaxJoins = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the time to pause (in milliseconds) after sending a heavy query
    ''' </summary>
    Public Property PauseTimeAfterHeavyQuery() As Integer
        Get
            Return Me.m_PauseTimeAfterHeavyQuery
        End Get
        Set(ByVal value As Integer)
            Me.m_PauseTimeAfterHeavyQuery = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the time to pause (in milliseconds) after sending any query
    ''' </summary>
    Public Property PauseTimeAfterAnyQuery() As Integer
        Get
            Return Me.m_PauseTimeAfterAnyQuery
        End Get
        Set(ByVal value As Integer)
            Me.m_PauseTimeAfterAnyQuery = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the time (in milliseconds) to consider some query as a valid heavy query
    ''' </summary>
    Public Property MinHeavyQueryTime() As Integer
        Get
            Return Me.m_MinHeavyQueryTime
        End Get
        Set(ByVal value As Integer)
            Me.m_MinHeavyQueryTime = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the timeout of an HTTP request (ignored due to possible saturation of the server)
    ''' </summary>
    Public Property HttpTimeout() As Integer
        Get
            Return Me.m_HttpTimeout
        End Get
        Set(ByVal value As Integer)
            Me.m_HttpTimeout = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets if the equal sign can be used in SQL statements, or only the greater-than and lower-than operators
    ''' </summary>
    ''' <remarks>In some database servers can change the execution plan, causing the injection to fail</remarks>
    Public Property EnableEqualInSelects() As Boolean
        Get
            Return Me.m_EnableEqualInSelects
        End Get
        Set(ByVal value As Boolean)
            Me.m_EnableEqualInSelects = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the number of times to repeat all requests to calculate the average values
    ''' </summary>
    Public Property RepeatTestCount() As Integer
        Get
            Return Me.m_RepeatTestCount
        End Get
        Set(ByVal value As Integer)
            Me.m_RepeatTestCount = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets an array of valid table names to include into the heavy queries
    ''' </summary>
    Public Property HeavyTableNames() As String()
        Get
            Return Me.m_HeavyTableNames
        End Get
        Set(ByVal value As String())
            Me.m_HeavyTableNames = value
            For i As Integer = 0 To Me.m_HeavyTableNames.Length - 1
                Me.m_HeavyTableNames(i) = Me.m_HeavyTableNames(i).Trim
            Next
        End Set
    End Property


    'Public Shared ReadOnly SqlServer2000Defaults As EngineSettings
    'Public Shared ReadOnly SqlServer2005Defaults As EngineSettings
    'Public Shared ReadOnly OracleDefaults As EngineSettings


    'Shared Sub New()
    '    Dim sql2000 As New EngineSettings
    '    With sql2000
    '        .MinHeavyQueryTime = 2000
    '        .HttpTimeout = 2100

    '        .PauseTimeAfterHeavyQuery = 3000
    '        .EnableEqualInSelects = True
    '        .HeavyTableNames = New String() {"sysusers", "sys.databases"}
    '    End With
    '    SqlServer2000Defaults = sql2000


    '    Dim sql2005 As New EngineSettings
    '    With sql2005
    '        .MinHeavyQueryTime = 3500
    '        .HttpTimeout = 4000

    '        .PauseTimeAfterHeavyQuery = 6000
    '        .PauseTimeAfterAnyQuery = 250
    '        .EnableEqualInSelects = False
    '        .HeavyTableNames = New String() {"sys.databases", "sysusers"}
    '    End With
    '    SqlServer2005Defaults = sql2005


    '    Dim oracle As New EngineSettings
    '    With oracle
    '        .MinJoins = 2
    '        .PauseTimeAfterHeavyQuery = 7000
    '        .PauseTimeAfterAnyQuery = 800
    '        .EnableEqualInSelects = False
    '        .HeavyTableNames = New String() {"all_users"}
    '    End With
    '    OracleDefaults = oracle
    'End Sub

End Class
