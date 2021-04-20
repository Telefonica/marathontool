Public Class OracleExtractor
    Implements ISpecificDatabaseExtractor

    Public Overrides Function ToString() As String Implements ISpecificDatabaseExtractor.ToString
        Return "Oracle"
    End Function

    Public ReadOnly Property DefaultTableNames() As String Implements ISpecificDatabaseExtractor.DefaultTableNames
        Get
            Return "all_users"
        End Get
    End Property


    Public ReadOnly Property ColumnNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameCharQueryFormat
        Get
            Return "SELECT ASCII(SUBSTR(COLUMN_NAME,{0},1)) FROM USER_TAB_COLUMNS, USER_OBJECTS where USER_OBJECTS.OBJECT_ID={1}" + _
                   " AND USER_OBJECTS.OBJECT_NAME = USER_TAB_COLUMNS.TABLE_NAME AND USER_TAB_COLUMNS.COLUMN_ID={2}"
        End Get
    End Property

    Public ReadOnly Property ColumnNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameLengthQueryFormat
        Get
            Return "SELECT length(column_name) FROM USER_TAB_COLUMNS, USER_OBJECTS WHERE rownum = 1 AND USER_TAB_COLUMNS.column_id={1}" + _
                   " AND USER_TAB_COLUMNS.table_name = USER_OBJECTS.object_name AND USER_OBJECTS.object_id={0}"
        End Get
    End Property

    Public ReadOnly Property ColumnTypeQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnTypeQueryFormat
        Get
            Return "SELECT mod(to_number(replace(substr(dump(data_type), instr(dump(data_type), chr(58))+1), chr(44), chr(48))), 255)-decode(data_scale, 0, 0, null, 0, 1)" + _
                   " FROM USER_TAB_COLUMNS, ALL_OBJECTS WHERE COLUMN_ID={1} AND OBJECT_ID={0} AND OBJECT_NAME = TABLE_NAME"
        End Get
    End Property

    Public ReadOnly Property NextColumnIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextColumnIDQueryFormat
        Get
            Return "SELECT MIN(COLUMN_ID) FROM USER_TAB_COLUMNS, USER_OBJECTS WHERE COLUMN_ID > {1} AND OBJECT_ID={0} AND OBJECT_NAME=TABLE_NAME"
        End Get
    End Property

    Public ReadOnly Property NextTableIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextTableIDQueryFormat
        Get
            Return "SELECT MIN(OBJECT_ID) FROM USER_OBJECTS WHERE OBJECT_ID > {0} AND OBJECT_TYPE=chr(84)||chr(65)||chr(66)||chr(76)||chr(69)"
        End Get
    End Property

    Public ReadOnly Property NumberOfColumnsQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfColumnsQueryFormat
        Get
            Return "SELECT COUNT(COLUMN_NAME) FROM USER_TAB_COLUMNS, USER_OBJECTS WHERE OBJECT_ID={0} AND USER_TAB_COLUMNS.TABLE_NAME = USER_OBJECTS.OBJECT_NAME"
        End Get
    End Property

    Public ReadOnly Property NumberOfUserTablesQuery() As String Implements ISpecificDatabaseExtractor.NumberOfUserTablesQuery
        Get
            Return "SELECT COUNT(TABLE_NAME) FROM USER_TABLES"
        End Get
    End Property

    Public ReadOnly Property TableNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameCharQueryFormat
        Get
            Return "SELECT ASCII(SUBSTR((OBJECT_NAME),{0},1)) FROM USER_OBJECTS WHERE OBJECT_ID={1}"
        End Get
    End Property

    Public ReadOnly Property TableNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameLengthQueryFormat
        Get
            Return "SELECT LENGTH(OBJECT_NAME) FROM USER_OBJECTS WHERE OBJECT_ID={0} AND OBJECT_TYPE=chr(84)||chr(65)||chr(66)||chr(76)||chr(69)"
        End Get
    End Property


    Public Function ConvertDataType(ByVal dataType As Object) As SqlDbType Implements ISpecificDatabaseExtractor.ConvertDataType
        Select Case CInt(dataType)
            Case 52 : Return SqlDbType.Char
            Case 79 : Return SqlDbType.DateTime
            Case 81 : Return SqlDbType.VarChar
            Case 87 : Return SqlDbType.Variant
            Case 97 : Return SqlDbType.NText
            Case 118 : Return SqlDbType.Variant
            Case 125 : Return SqlDbType.VarChar
            Case 126 : Return SqlDbType.Variant
            Case 141 : Return SqlDbType.Float
            Case 142 : Return SqlDbType.Int
            Case 143 : Return SqlDbType.Variant
            Case 196 : Return SqlDbType.BigInt
            Case 200 : Return SqlDbType.NVarChar
            Case 222 : Return SqlDbType.Variant

            Case Else : Return SqlDbType.Variant
        End Select
    End Function


    Public ReadOnly Property UserNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameLengthQuery
        Get
            Return "SELECT LENGTH(username) FROM USER_USERS"
        End Get
    End Property

    Public ReadOnly Property UserNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameCharQueryFormat
        Get
            Return "SELECT ASCII(SUBSTR(username,{0},1)) FROM USER_USERS"
        End Get
    End Property


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


End Class
