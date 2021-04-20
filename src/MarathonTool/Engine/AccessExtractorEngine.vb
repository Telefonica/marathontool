Public Class AccessExtractorEngine
    Inherits CatalogExtractorEngine



    Public Sub New(ByVal httpSettings As HttpSettings, ByVal engineSettings As EngineSettings, ByVal specificDB As ISpecificDatabaseExtractor)
        MyBase.New(httpSettings, engineSettings, specificDB)

    End Sub

    Public Function GetData(ByVal tableName As String, ByVal tableColumn As String) As Integer
        Dim n As Integer = Me.RecordsLength(tableName)
        Dim record As String = String.Empty

        Me.RaiseDebugEvent("** Table = " + tableName + "; Records: " + n.ToString(), 5)        
        Me.onRecordsFound(New MessageEventArgs(n.ToString()))

        For i As Integer = 0 To (n - 1)
            Dim t As Integer = Me.DataLength(tableName, tableColumn, i)
            record = String.Empty
            Me.RaiseDebugEvent("** Length record " + (i + 1).ToString() + " = " + t.ToString(), 5)            

            For j As Integer = 1 To t
                Dim p As Integer = Me.DataValue(tableName, tableColumn, i, j)
                Me.RaiseDebugEvent("** Text record " + (i + 1).ToString() + " = " + record + Chr(p) + "?", 5)
                record += Chr(p)
            Next

            Me.onRecordValueFound(New MessageEventArgs(record))
        Next

        Return n
    End Function


    Public Function RecordsLength(ByVal tableName As String) As Integer
        Dim access As AccessExtractor = CType(Me.m_SpecificDB, AccessExtractor)
        Dim sqlFormat As String = access.RecordsLengthQuery
        Dim sql As String = String.Format(sqlFormat, tableName)
        Return CInt(FindNumericValue(sql, sql, 0, 200, False))
    End Function

    Public Function DataLength(ByVal tableName As String, ByVal columnName As String, ByVal indice As Integer) As Integer
        Dim access As AccessExtractor = CType(Me.m_SpecificDB, AccessExtractor)
        Dim sqlFormat As String = String.Empty
        Dim sql As String = String.Empty

        If indice = 0 Then
            sqlFormat = access.RecordLengthQueryFormat
            sql = String.Format(sqlFormat, columnName, tableName, columnName)
        Else
            sqlFormat = access.NextRecordLengthQueryFormat
            sql = String.Format(sqlFormat, columnName, tableName, columnName, indice, columnName, tableName, columnName, columnName)
        End If

        Return CInt(FindNumericValue(sql, sql, 0, 200, False))
    End Function

    Public Function DataValue(ByVal tableName As String, ByVal columnName As String, ByVal indice As Integer, ByVal caracter As Integer) As Integer
        Dim access As AccessExtractor = CType(Me.m_SpecificDB, AccessExtractor)
        Dim sqlFormat As String = String.Empty
        Dim sql As String = String.Empty

        If indice = 0 Then
            sqlFormat = access.RecordValueQueryFormat
            sql = String.Format(sqlFormat, columnName, caracter, tableName, columnName)
        Else
            sqlFormat = access.NextRecordValueQueryFormat
            sql = String.Format(sqlFormat, columnName, caracter, tableName, columnName, indice, columnName, tableName, columnName, columnName)
        End If

        Return CInt(FindNumericValue(sql, sql, 0, 200, False))
    End Function

End Class
