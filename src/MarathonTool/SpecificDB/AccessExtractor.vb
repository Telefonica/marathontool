Public Class AccessExtractor
    Implements ISpecificDatabaseExtractor

    Private version As Integer

    Public Sub New(ByVal version As Integer)
        Me.version = version
    End Sub

    Public ReadOnly Property ColumnNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameCharQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property ColumnNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameLengthQueryFormat
        Get
            Return "select Len({0}) from {1} where {2} not in (select top {3} {4} from {5} order by {6}) order by {7}"
        End Get
    End Property

    Public ReadOnly Property ColumnTypeQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnTypeQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public Function ConvertDataType(ByVal dataType As Object) As System.Data.SqlDbType Implements ISpecificDatabaseExtractor.ConvertDataType

    End Function

    Public ReadOnly Property DatabaseFileNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameCharQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property DatabaseFileNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameLengthQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property DefaultTableNames() As String Implements ISpecificDatabaseExtractor.DefaultTableNames
        Get
            If Me.version = 1 Then
                Return "msysaccessobjects"
            Else
                Return "msysaccessstorage"
            End If

        End Get
    End Property

    Public ReadOnly Property NextColumnIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextColumnIDQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property NextDatabaseFileIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextDatabaseFileIDQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property NextTableIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextTableIDQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property NumberOfColumnsQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfColumnsQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property NumberOfDatabaseFilesQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfDatabaseFilesQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property NumberOfUserTablesQuery() As String Implements ISpecificDatabaseExtractor.NumberOfUserTablesQuery
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property TableNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameCharQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property TableNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameLengthQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function ToString() As String Implements ISpecificDatabaseExtractor.ToString
        If Me.version = 1 Then
            Return "Microsoft Access 97/2000"
        Else
            Return "Microsoft Access 2003/2007"
        End If
    End Function

    Public ReadOnly Property UserNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameCharQueryFormat
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property UserNameLengthQuery() As String Implements ISpecificDatabaseExtractor.UserNameLengthQuery
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property RecordsLengthQuery() As String
        Get
            Return "Select count(*) from {0}"
        End Get
    End Property

    Public ReadOnly Property RecordNameCharQueryFormat() As String
        Get
            Return "select top {0} "
        End Get
    End Property

    Public ReadOnly Property RecordLengthQueryFormat() As String
        Get
            Return "select Top 1 Len({0}) from {1} order by {2}"
        End Get
    End Property

    Public ReadOnly Property NextRecordLengthQueryFormat() As String
        Get
            Return "select Top 1 Len({0}) from {1} where {2} not in (select top {3} {4} from {5} order by {6}) order by {7}"
        End Get
    End Property

    Public ReadOnly Property RecordValueQueryFormat() As String
        Get
            Return "select Top 1 Asc(mid({0},{1},1)) from {2} order by {3}"
        End Get
    End Property

    Public ReadOnly Property NextRecordValueQueryFormat() As String
        Get
            Return "select Top 1 Asc(mid({0},{1},1)) from {2} where {3} not in (select top {4} {5} from {6} order by {7}) order by {8}"
        End Get
    End Property
End Class
