Public Class MySQLExtractor
    Implements ISpecificDatabaseExtractor


    Public Overrides Function ToString() As String Implements ISpecificDatabaseExtractor.ToString
        Return "MySQL"
    End Function


    Public ReadOnly Property DefaultTableNames() As String Implements ISpecificDatabaseExtractor.DefaultTableNames
        Get
            Return "information_schema.columns"
        End Get
    End Property



    Public ReadOnly Property ColumnNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameCharQueryFormat
        Get
            Return "SELECT ORD(SUBSTRING(column_name,{0},1)) FROM information_schema.columns WHERE table_schema<>'information_schema' AND table_name='{1}' AND ordinal_position={2}"
        End Get
    End Property

    Public ReadOnly Property ColumnNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameLengthQueryFormat
        Get
            Return "SELECT LENGTH(column_name) FROM information_schema.columns WHERE table_schema<>'information_schema' AND table_name='{0}' AND ordinal_position={1}"
        End Get
    End Property

    Public ReadOnly Property ColumnTypeQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnTypeQueryFormat
        Get
            'NO VALE PORQUE data_type ES DE TIPO string!
            Return "SELECT data_type FROM information_schema.columns WHERE table_schema<>'information_schema' AND table_name='{0}' AND ordinal_position={1}"
        End Get
    End Property

    Public ReadOnly Property NextColumnIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextColumnIDQueryFormat
        Get
            Return "SELECT MIN(ordinal_position) FROM information_schema.columns WHERE table_schema<>'information_schema' AND table_name='{0}' AND ordinal_position>{1}"
        End Get
    End Property


    Public ReadOnly Property NextTableIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextTableIDQueryFormat
        Get
            'The column "id" is the same name of the table, so this query is not necessary
            Throw New NotSupportedException
        End Get
    End Property

    Public ReadOnly Property NumberOfColumnsQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfColumnsQueryFormat
        Get
            Return "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema<>'information_schema' AND table_name='{0}'"
        End Get
    End Property

    Public ReadOnly Property NumberOfUserTablesQuery() As String Implements ISpecificDatabaseExtractor.NumberOfUserTablesQuery
        Get
            Return "SELECT COUNT(*) FROM information_schema.tables WHERE table_type='BASE TABLE'"
        End Get
    End Property

    Public ReadOnly Property TableNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameCharQueryFormat
        Get
            Return "SELECT ORD(SUBSTRING(MIN(table_name),{0},1)) FROM information_schema.tables WHERE table_type='BASE TABLE' AND table_name>'{1}'"
        End Get
    End Property

    Public ReadOnly Property TableNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameLengthQueryFormat
        Get
            Return "SELECT LENGTH(MIN(table_name)) FROM information_schema.tables WHERE table_type='BASE TABLE' AND table_name>'{0}'"
        End Get
    End Property

    Public Function ConvertDataType(ByVal dataType As Object) As SqlDbType Implements ISpecificDatabaseExtractor.ConvertDataType
        Return SqlDbType.Variant
    End Function

    Public ReadOnly Property DatabaseFileNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameCharQueryFormat
        Get
            Throw New NotImplementedException
        End Get
    End Property

    Public ReadOnly Property DatabaseFileNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameLengthQueryFormat
        Get
            Throw New NotImplementedException
        End Get
    End Property

    Public ReadOnly Property NextDatabaseFileIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextDatabaseFileIDQueryFormat
        Get
            Throw New NotImplementedException
        End Get
    End Property

    Public ReadOnly Property NumberOfDatabaseFilesQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfDatabaseFilesQueryFormat
        Get
            Throw New NotImplementedException
        End Get
    End Property


    Public ReadOnly Property UserNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameCharQueryFormat
        Get
            Return "SELECT ORD(SUBSTRING(CURRENT_USER,{0},1))"
        End Get
    End Property

    Public ReadOnly Property UserNameLengthQuery() As String Implements ISpecificDatabaseExtractor.UserNameLengthQuery
        Get
            Return "SELECT LENGTH(CURRENT_USER)"
        End Get
    End Property


End Class
