''' <summary>
''' Provides functionality to extract the database schema from the catalog of some database engines
''' </summary>
Public Class CatalogExtractorEngine
    Inherits BaseEngine

    Protected m_SpecificDB As ISpecificDatabaseExtractor
    Protected m_MaxUnicode As Integer = 256 '65536


    Public Sub New(ByVal httpSettings As HttpSettings, ByVal engineSettings As EngineSettings, ByVal specificDB As ISpecificDatabaseExtractor)
        MyBase.New(httpSettings, engineSettings)

        Me.m_SpecificDB = specificDB
    End Sub


    ''' <summary>
    ''' Occurs when the number of tables is determined
    ''' </summary>
    Public Event NumOfTablesFound(ByVal sender As Object, ByVal e As TableEventArgs)
    ''' <summary>
    ''' Occurs after a new table identifier is found
    ''' </summary>
    Public Event NewTableIDFound(ByVal sender As Object, ByVal e As TableEventArgs)
    ''' <summary>
    ''' Occurs after a new table name is found
    ''' </summary>
    Public Event NewTableNameFound(ByVal sender As Object, ByVal e As TableEventArgs)

    ''' <summary>
    ''' Occurs when the number of columns of a table is determined
    ''' </summary>
    Public Event NumOfColumnsFound(ByVal sender As Object, ByVal e As ColumnEventArgs)
    ''' <summary>
    ''' Occurs after a new column identifier is found
    ''' </summary>
    Public Event NewColumnIDFound(ByVal sender As Object, ByVal e As ColumnEventArgs)
    ''' <summary>
    ''' Occurs after a new column name is found
    ''' </summary>
    Public Event NewColumnNameFound(ByVal sender As Object, ByVal e As ColumnEventArgs)
    ''' <summary>
    ''' Occurs after a new column data type is found
    ''' </summary>
    Public Event NewColumnTypeFound(ByVal sender As Object, ByVal e As ColumnEventArgs)

    Public Event RecordsFound(ByVal sender As Object, ByVal e As MessageEventArgs)
    Public Event CharacterFound(ByVal sender As Object, ByVal e As MessageEventArgs)
    Public Event RecordValueLengthFound(ByVal sender As Object, ByVal e As MessageEventArgs)
    Public Event RecordValueFound(ByVal sender As Object, ByVal e As MessageEventArgs)


#Region " Methods to enable raising events in derived classes "
    Protected Sub OnNumOfTablesFound(ByVal e As TableEventArgs)
        RaiseEvent NumOfTablesFound(Me, e)
    End Sub

    Protected Sub OnNewTableIDFound(ByVal e As TableEventArgs)
        RaiseEvent NewTableIDFound(Me, e)
    End Sub

    Protected Sub OnNewTableNameFound(ByVal e As TableEventArgs)
        RaiseEvent NewTableNameFound(Me, e)
    End Sub

    Protected Sub OnNewColumnIDFound(ByVal e As ColumnEventArgs)
        RaiseEvent NewColumnIDFound(Me, e)
    End Sub

    Protected Sub OnNumOfColumnsFound(ByVal e As ColumnEventArgs)
        RaiseEvent NumOfColumnsFound(Me, e)
    End Sub

    Protected Sub OnNewColumnNameFound(ByVal e As ColumnEventArgs)
        RaiseEvent NewColumnNameFound(Me, e)
    End Sub

    Protected Sub OnNewColumnTypeFound(ByVal e As ColumnEventArgs)
        RaiseEvent NewColumnTypeFound(Me, e)
    End Sub

    Protected Sub onCharacterFound(ByVal e As MessageEventArgs)
        RaiseEvent CharacterFound(Me, e)
    End Sub

    Protected Sub onRecordsFound(ByVal e As MessageEventArgs)
        RaiseEvent RecordsFound(Me, e)
    End Sub

    Protected Sub onRecordValueFound(ByVal e As MessageEventArgs)
        RaiseEvent RecordValueFound(Me, e)
    End Sub

    Protected Sub onRecordValueLengthFound(ByVal e As MessageEventArgs)
        RaiseEvent RecordValueLengthFound(Me, e)
    End Sub

#End Region


    ''' <summary>
    ''' Returns the identifiers of the user tables found in the database schema
    ''' </summary>
    Public Overridable Function GetTableIDs() As ArrayList
        Dim n As Integer = NumberOfUserTables()

        RaiseEvent NumOfTablesFound(Me, New TableEventArgs(n))

        Dim ids As New ArrayList

        Dim lastID As Long = 0
        For i As Integer = 1 To n
            lastID = NextTableID(lastID)
            ids.Add(lastID)

            RaiseEvent NewTableIDFound(Me, New TableEventArgs(n, lastID))
        Next
        Return ids
    End Function


    ''' <summary>
    ''' Returns the table name of the one with the specified identifier
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    Public Overridable Function GetTableName(ByVal tableID As Object) As String
        Dim n As Integer = TableNameLength(tableID)

        Dim name As String = ""
        For i As Integer = 1 To n
            name += TableNameChar(tableID, i)

            RaiseEvent NewTableNameFound(Me, New TableEventArgs(tableID, name + New String("?"c, n - name.Length)))
        Next
        RaiseEvent NewTableNameFound(Me, New TableEventArgs(tableID, name))
        Return name
    End Function

    ''' <summary>
    ''' Returns the identifiers of the columns of the table with the specified identifier
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    Public Function GetColumnIDs(ByVal tableID As Object) As List(Of Long)
        Dim n As Integer = NumberOfColumns(tableID)

        RaiseEvent NumOfColumnsFound(Me, New ColumnEventArgs(n))

        Dim ids As New List(Of Long)

        Dim lastID As Long = 0
        For i As Integer = 1 To n
            lastID = NextColumnID(tableID, lastID)
            ids.Add(lastID)

            RaiseEvent NewColumnIDFound(Me, New ColumnEventArgs(tableID, lastID))
        Next
        Return ids
    End Function

    ''' <summary>
    ''' Returns the column name of the one with the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    Public Function GetColumnName(ByVal tableID As Object, ByVal columnID As Long) As String
        Dim n As Integer = ColumnNameLength(tableID, columnID)

        Dim name As String = ""
        For i As Integer = 1 To n
            name += ColumnNameChar(tableID, columnID, i)

            RaiseEvent NewColumnNameFound(Me, New ColumnEventArgs(tableID, columnID, name + New String("?"c, n - name.Length)))
        Next

        RaiseEvent NewColumnNameFound(Me, New ColumnEventArgs(tableID, columnID, name))
        Return name
    End Function


    ''' <summary>
    ''' Returns the column data type of the one with the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    Public Function GetColumnType(ByVal tableID As Object, ByVal columnID As Long) As SqlDbType
        Dim type As SqlDbType = m_SpecificDB.ConvertDataType(ColumnType(tableID, columnID))

        RaiseEvent NewColumnTypeFound(Me, New ColumnEventArgs(tableID, columnID, type))

        Return type
    End Function

    ''' <summary>
    ''' Returns the user name associated with the current server database connection
    ''' </summary>
    Public Function GetUserName() As String
        Dim n As Integer = Me.UserNameLength

        Dim name As String = ""
        For i As Integer = 1 To n
            name += Me.UserNameChar(i)

            Me.RaiseDebugEvent("** Username = " + name + New String("?"c, n - name.Length), 5)
        Next
        Return name
    End Function


    ''' <summary>
    ''' Returns the number of the tables created by the user
    ''' </summary>
    Protected Function NumberOfUserTables() As Integer
        Dim sql As String = m_SpecificDB.NumberOfUserTablesQuery
        Return CInt(FindNumericValue(sql, sql, 0, 1000, False))
    End Function

    ''' <summary>
    ''' Returns the next table identifier after the last found
    ''' </summary>
    ''' <param name="lastID">The last table identifier that was found</param>
    Protected Function NextTableID(ByVal lastID As Long) As Long
        Dim sqlFormat As String = m_SpecificDB.NextTableIDQueryFormat
        Dim sql As String = String.Format(sqlFormat, lastID)

        Return FindNumericValue(sqlFormat, sql, lastID)
    End Function


    ''' <summary>
    ''' Returns the number of characters of the table name with the specified identifier
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    Protected Function TableNameLength(ByVal tableID As Object) As Integer
        Dim sqlFormat As String = m_SpecificDB.TableNameLengthQueryFormat
        Dim sql As String = String.Format(sqlFormat, tableID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 200, False))
    End Function

    ''' <summary>
    ''' Returns the character at the specified index of the name of the specified identifier
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="charIndex">The index of the character</param>
    Protected Function TableNameChar(ByVal tableID As Object, ByVal charIndex As Integer) As Char
        Dim sqlFormat As String = m_SpecificDB.TableNameCharQueryFormat
        Dim sql As String = String.Format(sqlFormat, charIndex, tableID)

        Return ChrW(CInt(FindNumericValue(sqlFormat, sql, 0, m_MaxUnicode)))
    End Function

    ''' <summary>
    ''' Returns the number of columns of the specified table
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    Protected Function NumberOfColumns(ByVal tableID As Object) As Integer
        Dim sqlFormat As String = m_SpecificDB.NumberOfColumnsQueryFormat
        Dim sql As String = String.Format(sqlFormat, tableID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 1000))
    End Function

    ''' <summary>
    ''' Returns the next column identifier after the last found
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="lastID">The last column identifier that was found</param>
    Protected Function NextColumnID(ByVal tableID As Object, ByVal lastID As Long) As Long
        Dim sqlFormat As String = m_SpecificDB.NextColumnIDQueryFormat
        Dim sql As String = String.Format(sqlFormat, tableID, lastID)

        Return FindNumericValue(sqlFormat, sql, lastID, 1000, False)
    End Function

    ''' <summary>
    ''' Returns the number of characters of the column name with the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    Protected Function ColumnNameLength(ByVal tableID As Object, ByVal columnID As Long) As Integer
        Dim sqlFormat As String = m_SpecificDB.ColumnNameLengthQueryFormat
        Dim sql As String = String.Format(sqlFormat, tableID, columnID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 200, False))
    End Function

    ''' <summary>
    ''' Returns the character at the specified index of the column name of the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    ''' <param name="charIndex">The index of the character</param>
    Protected Function ColumnNameChar(ByVal tableID As Object, ByVal columnID As Long, ByVal charIndex As Integer) As Char
        Dim sqlFormat As String = m_SpecificDB.ColumnNameCharQueryFormat
        Dim sql As String = String.Format(sqlFormat, charIndex, tableID, columnID)

        Return ChrW(CInt(FindNumericValue(sqlFormat, sql, 0, m_MaxUnicode)))
    End Function


    ''' <summary>
    ''' Returns the column data type for the specified identifiers
    ''' </summary>
    ''' <param name="tableID">The table identifier</param>
    ''' <param name="columnID">The column identifier</param>
    Protected Overridable Function ColumnType(ByVal tableID As Object, ByVal columnID As Long) As Integer
        Dim sqlFormat As String = m_SpecificDB.ColumnTypeQueryFormat
        Dim sql As String = String.Format(sqlFormat, tableID, columnID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 256))
    End Function



    ''' <summary>
    ''' Returns the number of characters of the user name associated with the current server database connection
    ''' </summary>
    Protected Function UserNameLength() As Integer
        Dim sql As String = m_SpecificDB.UserNameLengthQuery
        Return CInt(FindNumericValue(sql, sql, 0, 200, False))
    End Function

    ''' <summary>
    ''' Returns the character at the specified index of the user name associated with the current server database connection
    ''' </summary>
    Protected Function UserNameChar(ByVal charIndex As Integer) As Char
        Dim sqlFormat As String = m_SpecificDB.UserNameCharQueryFormat
        Dim sql As String = String.Format(sqlFormat, charIndex)

        Return ChrW(CInt(FindNumericValue(sqlFormat, sql, 0, m_MaxUnicode)))
    End Function



    Protected Function NumberOfDatabaseFiles() As Integer
        Dim sql As String = m_SpecificDB.NumberOfDatabaseFilesQueryFormat
        Return CInt(FindNumericValue(sql, sql, 0, 20, False))
    End Function

    Protected Function NextDatabaseFileID(ByVal lastID As Long) As Integer
        Dim sqlFormat As String = m_SpecificDB.NextDatabaseFileIDQueryFormat
        Dim sql As String = String.Format(sqlFormat, lastID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 256))
    End Function

    Protected Function DatabaseFileNameLength(ByVal fileID As Long) As Integer
        Dim sqlFormat As String = m_SpecificDB.DatabaseFileNameLengthQueryFormat
        Dim sql As String = String.Format(sqlFormat, fileID)

        Return CInt(FindNumericValue(sqlFormat, sql, 0, 256, False))
    End Function

    Protected Function DatabaseFileNameChar(ByVal fileID As Long, ByVal charIndex As Integer) As Char
        Dim sqlFormat As String = m_SpecificDB.DatabaseFileNameCharQueryFormat
        Dim sql As String = String.Format(sqlFormat, charIndex, fileID)

        Return ChrW(CInt(FindNumericValue(sqlFormat, sql, 0, m_MaxUnicode)))
    End Function
End Class
