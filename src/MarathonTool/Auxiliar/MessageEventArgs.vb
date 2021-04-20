Public Class MessageEventArgs  
    Inherits System.EventArgs

    Private m_Message As String
    Private m_DateTime As DateTime

    Public Sub New(ByVal m_Message As String, ByVal m_DateTime As DateTime)
        MyBase.New()
        Me.m_Message = m_Message
        Me.m_DateTime = m_DateTime
    End Sub

    Public Sub New(ByVal m_Message As String)
        MyBase.New()
        Me.m_Message = m_Message
        Me.m_DateTime = Date.Now
    End Sub

    Public ReadOnly Property DateTime() As Date
        Get
            Return Me.m_DateTime
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return Me.m_Message
        End Get
    End Property
End Class


