''' <summary>
''' Provides additional functionality to extract the database schema of the mySQL engine
''' </summary>
Public Class MySQLCatalogExtractorEngine
    Inherits CatalogExtractorEngine

    Public Sub New(ByVal httpSettings As HttpSettings, ByVal engineSettings As EngineSettings, ByVal specificDB As ISpecificDatabaseExtractor)
        MyBase.New(httpSettings, engineSettings, specificDB)
    End Sub

    ''' <summary>
    ''' Returns the identifiers (names) of the user tables found in the database schema
    ''' </summary>
    Public Overrides Function GetTableIDs() As ArrayList
        Dim n As Integer = NumberOfUserTables()

        Me.OnNumOfTablesFound(New TableEventArgs(n))

        Dim ids As New ArrayList

        Dim lastID As String = ""
        For i As Integer = 1 To n
            lastID = NextTableID(lastID)
            ids.Add(lastID)

            Dim e As New TableEventArgs(n)
            e.TableID = lastID
            Me.OnNewTableIDFound(e)
        Next
        Return ids
    End Function

    ''' <summary>
    ''' Returns the next table identifier (name) after the last found
    ''' </summary>
    ''' <param name="lastTableName">The last table identifier (name) that was found</param>
    Protected Overloads Function NextTableID(ByVal lastTableName As String) As String
        Dim n As Integer = TableNameLength(lastTableName)

        Dim name As String = ""
        For i As Integer = 1 To n
            name += TableNameChar(lastTableName, i)

            Me.RaiseDebugEvent("** Table = " + name + New String("?"c, n - name.Length), 5)
        Next
        Return name
    End Function

    ''' <summary>
    ''' Returns the table name of the one with the specified identifier
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    Public Overrides Function GetTableName(ByVal tableID As Object) As String
        Me.OnNewTableNameFound(New TableEventArgs(tableID, CStr(tableID)))
        Return CStr(tableID)
    End Function


    ''' <summary>
    ''' Returns the column data type for the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    Protected Overrides Function ColumnType(ByVal tableID As Object, ByVal columnID As Long) As Integer
        'TODO: Not implemented yet
        Return 0
    End Function


End Class
