Public Class DebugEventArgs
    Inherits EventArgs

    Private m_Message As String
    Private m_DateTime As Date
    Private m_VerbosityLevel As Integer

    Public ReadOnly Property Message() As String
        Get
            Return Me.m_Message
        End Get
    End Property

    Public ReadOnly Property DateTime() As Date
        Get
            Return Me.m_DateTime
        End Get
    End Property

    Public ReadOnly Property VerbosityLevel() As Integer
        Get
            Return Me.m_VerbosityLevel
        End Get
    End Property


    Public Sub New(ByVal message As String)
        Me.New(message, 0)
    End Sub

    Public Sub New(ByVal message As String, ByVal verbosityLevel As Integer)
        Me.m_DateTime = Now
        Me.m_Message = message
        Me.m_VerbosityLevel = verbosityLevel
    End Sub

    Public Overrides Function ToString() As String
        Return m_DateTime.ToLongTimeString + "  " + m_Message
    End Function
End Class


