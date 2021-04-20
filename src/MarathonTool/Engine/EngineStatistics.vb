''' <summary>
''' Contains shared functions to update the statistics of the injection engine. 
''' The statistics are implemented using performance counters of the Windows operating system
''' </summary>
Public Class EngineStatistics

    Private Shared m_NumberOfRequests As PerformanceCounter
    Private Shared m_TrueQueries As PerformanceCounter
    Private Shared m_FalseQueries As PerformanceCounter
    Private Shared m_IndeterminateQueries As PerformanceCounter

    ''' <summary>
    ''' Returns a performance counter for the total number of HTTP requests that has been made
    ''' since the initializacion of the application
    ''' </summary>
    Public Shared ReadOnly Property NumberOfRequests() As PerformanceCounter
        Get
            Return m_NumberOfRequests
        End Get
    End Property

    ''' <summary>
    ''' Returns a performance counter for the number of queries that has been considerated as true
    ''' since the initializacion of the application
    ''' </summary>
    Public Shared ReadOnly Property TrueQueries() As PerformanceCounter
        Get
            Return m_TrueQueries
        End Get
    End Property

    ''' <summary>
    ''' Returns a performance counter for the number of queries that has been considerated as false
    ''' since the initializacion of the application
    ''' </summary>
    Public Shared ReadOnly Property FalseQueries() As PerformanceCounter
        Get
            Return m_FalseQueries
        End Get
    End Property

    ''' <summary>
    ''' Returns a performance counter for the number of queries which result has been 
    ''' considerated as indeterminate since the initializacion of the application
    ''' </summary>
    Public Shared ReadOnly Property IndeterminateQueries() As PerformanceCounter
        Get
            Return m_IndeterminateQueries
        End Get
    End Property


    Private Sub New()
    End Sub

    Shared Sub New()
        Dim categoryName As String = Application.ProductName

        If Not PerformanceCounterCategory.Exists(categoryName) Then
            Dim counters As New CounterCreationDataCollection
            counters.Add(New CounterCreationData("Requests", "Number of HTTP requests", PerformanceCounterType.NumberOfItems32))
            counters.Add(New CounterCreationData("True queries", "Number of queries interpreted as True", PerformanceCounterType.NumberOfItems32))
            counters.Add(New CounterCreationData("False queries", "Number of queries interpreted as False", PerformanceCounterType.NumberOfItems32))
            counters.Add(New CounterCreationData("Indeterminate queries", "Number of indeterminate queries", PerformanceCounterType.NumberOfItems32))

            PerformanceCounterCategory.Create(categoryName, "", PerformanceCounterCategoryType.SingleInstance, counters)
        End If

        m_NumberOfRequests = New PerformanceCounter(categoryName, "Requests", False)
        m_NumberOfRequests.RawValue = 0

        m_TrueQueries = New PerformanceCounter(categoryName, "True queries", False)
        m_TrueQueries.RawValue = 0

        m_FalseQueries = New PerformanceCounter(categoryName, "False queries", False)
        m_FalseQueries.RawValue = 0

        m_IndeterminateQueries = New PerformanceCounter(categoryName, "Indeterminate queries", False)
        m_IndeterminateQueries.RawValue = 0
    End Sub

End Class
