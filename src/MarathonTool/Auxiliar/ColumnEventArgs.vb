Public Class ColumnEventArgs
    Inherits EventArgs

    Private m_Count As Integer
    Private m_TableID As Object
    Private m_ColumnID As Long
    Private m_ColumnName As String
    Private m_ColumnType As SqlDbType

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.m_Count
        End Get
    End Property

    Public ReadOnly Property TableID() As Object
        Get
            Return Me.m_TableID
        End Get
    End Property

    Public ReadOnly Property ColumnID() As Long
        Get
            Return Me.m_ColumnID
        End Get
    End Property

    Public ReadOnly Property ColumnName() As String
        Get
            Return Me.m_ColumnName
        End Get
    End Property

    Public ReadOnly Property ColumnType() As SqlDbType
        Get
            Return Me.m_ColumnType
        End Get
    End Property


    Public Sub New(ByVal count As Integer)
        Me.m_Count = count
    End Sub

    Public Sub New(ByVal tableID As Object, ByVal columnID As Long)
        Me.m_TableID = tableID
        Me.m_ColumnID = columnID
    End Sub

    Public Sub New(ByVal tableID As Object, ByVal columnID As Long, ByVal name As String)
        Me.m_TableID = tableID
        Me.m_ColumnID = columnID
        Me.m_ColumnName = name
    End Sub

    Public Sub New(ByVal tableID As Object, ByVal columnID As Long, ByVal type As SqlDbType)
        Me.m_TableID = tableID
        Me.m_ColumnID = columnID
        Me.m_ColumnType = type
    End Sub
End Class


