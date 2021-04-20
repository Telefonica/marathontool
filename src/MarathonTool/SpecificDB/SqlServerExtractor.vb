Public Class SqlServerExtractor
    Implements ISpecificDatabaseExtractor


    Public Overrides Function ToString() As String Implements ISpecificDatabaseExtractor.ToString
        Return "Microsoft SQL Server"
    End Function

    Public ReadOnly Property DefaultTableNames() As String Implements ISpecificDatabaseExtractor.DefaultTableNames
        Get
            Return "sys.databases, sysusers"
        End Get
    End Property



    Public ReadOnly Property ColumnNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameCharQueryFormat
        Get
            Return "SELECT UNICODE(SUBSTRING((name),{0},1)) FROM syscolumns WHERE id={1} AND colid={2}"
        End Get
    End Property

    Public ReadOnly Property ColumnNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnNameLengthQueryFormat
        Get
            Return "SELECT LEN(name) FROM syscolumns WHERE id={0} AND colid={1}"
        End Get
    End Property

    Public ReadOnly Property ColumnTypeQueryFormat() As String Implements ISpecificDatabaseExtractor.ColumnTypeQueryFormat
        Get
            Return "SELECT xtype FROM syscolumns WHERE id={0} AND colid={1}"
        End Get
    End Property

    Public ReadOnly Property NextColumnIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextColumnIDQueryFormat
        Get
            Return "SELECT MIN(colid) FROM syscolumns WHERE id={0} AND colid>{1}"
        End Get
    End Property

    Public ReadOnly Property NextTableIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextTableIDQueryFormat
        Get
            Return "SELECT MIN(id) FROM sysobjects WHERE xtype=char(85) AND id>{0}"
        End Get
    End Property

    Public ReadOnly Property NumberOfColumnsQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfColumnsQueryFormat
        Get
            Return "SELECT COUNT(*) FROM syscolumns WHERE id={0}"
        End Get
    End Property

    Public ReadOnly Property NumberOfUserTablesQuery() As String Implements ISpecificDatabaseExtractor.NumberOfUserTablesQuery
        Get
            Return "SELECT COUNT(*) FROM sysobjects WHERE xtype=char(85)"
        End Get
    End Property

    Public ReadOnly Property TableNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameCharQueryFormat
        Get
            Return "SELECT UNICODE(SUBSTRING(name,{0},1)) FROM sysobjects WHERE id={1}"
        End Get
    End Property


    Public ReadOnly Property TableNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.TableNameLengthQueryFormat
        Get
            Return "SELECT LEN(name) FROM sysobjects WHERE id={0}"
        End Get
    End Property


    Public Function ConvertDataType(ByVal dataType As Object) As SqlDbType Implements ISpecificDatabaseExtractor.ConvertDataType
        Select Case CInt(dataType)
            Case 56 : Return SqlDbType.Int
            Case 167 : Return SqlDbType.VarChar
            Case 175 : Return SqlDbType.Char
            Case 106 : Return SqlDbType.Decimal
            Case 127 : Return SqlDbType.BigInt
            Case 173 : Return SqlDbType.Binary
            Case 104 : Return SqlDbType.Bit
            Case 61 : Return SqlDbType.DateTime
            Case 34 : Return SqlDbType.Image
            Case 60 : Return SqlDbType.Money
            Case 239 : Return SqlDbType.NChar
            Case 99 : Return SqlDbType.NText
            Case 108 : Return SqlDbType.Variant
            Case 62 : Return SqlDbType.Float
            Case 231 : Return SqlDbType.NVarChar
            Case 59 : Return SqlDbType.Real
            Case 58 : Return SqlDbType.SmallDateTime
            Case 52 : Return SqlDbType.SmallInt
            Case 122 : Return SqlDbType.SmallMoney
            Case 35 : Return SqlDbType.Text
            Case 189 : Return SqlDbType.Timestamp
            Case 48 : Return SqlDbType.TinyInt
            Case 36 : Return SqlDbType.UniqueIdentifier
            Case 165 : Return SqlDbType.VarBinary

            Case Else : Return SqlDbType.Variant
                'Faltan tipos (ej: XML, UDT, Image, etc)
        End Select
    End Function


    Public ReadOnly Property UserNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameLengthQuery
        Get
            Return "SELECT LEN(system_user)"
        End Get
    End Property

    Public ReadOnly Property UserNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.UserNameCharQueryFormat
        Get
            Return "SELECT UNICODE(SUBSTRING((system_user),{0},1))"
        End Get
    End Property



    Public ReadOnly Property NumberOfDatabaseFilesQueryFormat() As String Implements ISpecificDatabaseExtractor.NumberOfDatabaseFilesQueryFormat
        Get
            Return "SELECT COUNT(*) FROM sysfiles"
        End Get
    End Property

    Public ReadOnly Property NextDatabaseFileIDQueryFormat() As String Implements ISpecificDatabaseExtractor.NextDatabaseFileIDQueryFormat
        Get
            Return "SELECT MIN(fileid) FROM sysfiles WHERE fileid>{0}"
        End Get
    End Property

    Public ReadOnly Property DatabaseFileNameLengthQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameLengthQueryFormat
        Get
            Return "SELECT LEN(filename) FROM sysfiles WHERE fileid={0}"
        End Get
    End Property

    Public ReadOnly Property DatabaseFileNameCharQueryFormat() As String Implements ISpecificDatabaseExtractor.DatabaseFileNameCharQueryFormat
        Get
            Return "SELECT UNICODE(SUBSTRING((filename),{0},1)) FROM sysfiles WHERE fileid={1}"
        End Get
    End Property



End Class
