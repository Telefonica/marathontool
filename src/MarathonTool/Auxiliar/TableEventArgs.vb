Public Class TableEventArgs
    Inherits EventArgs

    Private m_Count As Integer
    Private m_TableID As Object
    Private m_TableName As String

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.m_Count
        End Get
    End Property

    Public Property TableID() As Object
        Get
            Return Me.m_TableID
        End Get
        Set(ByVal value As Object)
            Me.m_TableID = value
        End Set
    End Property

    Public ReadOnly Property TableName() As String
        Get
            Return Me.m_TableName
        End Get
    End Property


    Public Sub New(ByVal count As Integer)
        Me.New(count, -1, "")
    End Sub

    Public Sub New(ByVal count As Integer, ByVal tableID As Object)
        Me.New(count, tableID, "")
    End Sub

    Public Sub New(ByVal tableID As Object, ByVal tableName As String)
        Me.New(-1, tableID, tableName)
    End Sub

    Public Sub New(ByVal count As Integer, ByVal tableID As Object, ByVal tableName As String)
        Me.m_Count = count
        Me.m_TableID = tableID
        Me.m_TableName = tableName
    End Sub
End Class
