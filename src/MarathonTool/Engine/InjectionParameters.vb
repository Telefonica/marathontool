''' <summary>
''' Contains a set of configuration values that will be used for each specific type of query
''' </summary>
Public Class InjectionParameters
    Public Shared ReadOnly Empty As New InjectionParameters(-1, "")

    Private m_NumJoins As Integer = -1
    Private m_TableName As String = ""
    Private m_ReverseOrder As Boolean

    Private m_TimeTrue As Long = -1
    Private m_TimeFalse As Long = -1

    ''' <summary>
    ''' Gets or sets the number of joins of the heavy query that will be used for this instance
    ''' </summary>
    Public Property NumJoins() As Integer
        Get
            Return Me.m_NumJoins
        End Get
        Set(ByVal value As Integer)
            Me.m_NumJoins = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the name of the heavy query that will be used for this instance
    ''' </summary>
    Public Property TableName() As String
        Get
            Return Me.m_TableName
        End Get
        Set(ByVal value As String)
            Me.m_TableName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets if the heavy query will be appended to the left or to the right of the SQL condition
    ''' </summary>
    Public Property ReverseOrder() As Boolean
        Get
            Return Me.m_ReverseOrder
        End Get
        Set(ByVal value As Boolean)
            Me.m_ReverseOrder = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the time (in milliseconds) established for the true case (slow response)
    ''' </summary>
    Public Property TimeTrue() As Long
        Get
            Return Me.m_TimeTrue
        End Get
        Set(ByVal value As Long)
            Me.m_TimeTrue = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the time (in milliseconds) established for the false case (normal response)
    ''' </summary>
    Public Property TimeFalse() As Long
        Get
            Return Me.m_TimeFalse
        End Get
        Set(ByVal value As Long)
            Me.m_TimeFalse = value
        End Set
    End Property


    Public Sub New(ByVal numJoins As Integer, ByVal tableName As String)
        Me.New(numJoins, tableName, False)
    End Sub

    Public Sub New(ByVal numJoins As Integer, ByVal tableName As String, ByVal reverseOrder As Boolean)
        Me.m_NumJoins = numJoins
        Me.m_TableName = tableName
        Me.m_ReverseOrder = reverseOrder
    End Sub


    ''' <summary>
    ''' Returns true if the parameters have been initialized properly
    ''' </summary>
    Public Function IsInitialized() As Boolean
        Return (Me.m_NumJoins > 0)
    End Function
End Class
