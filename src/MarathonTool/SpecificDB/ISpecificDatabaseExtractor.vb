Public Interface ISpecificDatabaseExtractor
    Function ToString() As String

    ''' <summary>
    ''' The default names of the tables to be used in the heavy queries, separated by commas
    ''' </summary>
    ReadOnly Property DefaultTableNames() As String



    ''' <summary>
    ''' The SQL specific format to get the number of user tables
    ''' </summary>
    ReadOnly Property NumberOfUserTablesQuery() As String
    ''' <summary>
    ''' The SQL specific format to get the next table identifier (parameters: 0=last table ID found)
    ''' </summary>
    ReadOnly Property NextTableIDQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get the number of characters of the specified table identifier (parameters: 0=table ID)
    ''' </summary>
    ReadOnly Property TableNameLengthQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get a character of the name of the specified table identifier (parameters: 0=char index; 1=table ID)
    ''' </summary>
    ReadOnly Property TableNameCharQueryFormat() As String


    ''' <summary>
    ''' The SQL specific format to get the number of columns of a table (parameters: 0=table ID)
    ''' </summary>
    ReadOnly Property NumberOfColumnsQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get the next column identifier of a table (parameters: 0=table ID; 1=last column ID found)
    ''' </summary>
    ReadOnly Property NextColumnIDQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get the number of characters of the specified column name (parameters: 0=table ID; 1=column ID)
    ''' </summary>
    ReadOnly Property ColumnNameLengthQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get a character of the name of the specified column (parameters: 0=char index; 1=table ID, 2=column ID)
    ''' </summary>
    ReadOnly Property ColumnNameCharQueryFormat() As String
    ''' <summary>
    ''' The SQL specific format to get the data type of the specified column (parameters: 0=table ID, 1=column ID)
    ''' </summary>
    ReadOnly Property ColumnTypeQueryFormat() As String


    ''' <summary>
    ''' The SQL specific format to get the user name associated with the current server database connection
    ''' </summary>
    ReadOnly Property UserNameLengthQuery() As String
    ''' <summary>
    ''' The SQL specific format to get a character of the user name associated with the current server database connection (parameters: 0=char index)
    ''' </summary>
    ReadOnly Property UserNameCharQueryFormat() As String


    ReadOnly Property NumberOfDatabaseFilesQueryFormat() As String
    ReadOnly Property NextDatabaseFileIDQueryFormat() As String
    ReadOnly Property DatabaseFileNameLengthQueryFormat() As String
    ReadOnly Property DatabaseFileNameCharQueryFormat() As String


    Function ConvertDataType(ByVal dataType As Object) As SqlDbType

End Interface


