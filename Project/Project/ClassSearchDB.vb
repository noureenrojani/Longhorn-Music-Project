
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Class ClassSearchDB
    'Purpose: connect to tblSong
    'Arguments: Procedures
    'Returns: Dataset containing information from tblEMployee
    'Author: Erik Margetis
    'Date: 15 April 2015

    ' these module variables are internal to object
    Dim aryNames As ArrayList
    Dim aryValues As ArrayList
    Dim mMyViewGenre As New DataView
    Dim mDatasetSearch As New DataSet
    Dim mDatasetGenre As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team14;user id=msbcn211;password=Aida90210"

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property SearchDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetSearch
        End Get
    End Property

    Public ReadOnly Property GenreDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetGenre
        End Get
    End Property


    Public Sub UseSP(ByVal strUSPName As String, ByVal strDatasetName As DataSet, ByVal strViewName As DataView, ByVal strTableName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'Purpose: Run any stored procedure with any number of parameters
        'Arguments: Stored procedure name, tblName, dataset name, dataview name, arraylist of parameter names, and arraylist of parameter values
        'Returns: Nothing
        'Author: Rick Byars
        'Date: 4/16/10
        'Creates instances of the connection and command object
        Dim objConnection As New SqlConnection(mstrConnection)
        'Tell SQL server the name of the stored procedure
        Dim objCommand As New SqlDataAdapter(strUSPName, objConnection)
        Try
            'Sets the command type to stored procedure
            objCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            'Add parameters to stored procedure
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                objCommand.SelectCommand.Parameters.Add(New SqlParameter(CStr(aryParamNames(index)), CStr(aryParamValues(index))))
                index = index + 1
            Next

            'Clear dataset
            strDatasetName.Clear()

            'Open the connection and fill dataset
            objCommand.Fill(strDatasetName, strTableName)
            ' fill view
            strViewName.Table = strDatasetName.Tables(strTableName)

            'Print out each element of our arraylists if error occured
        Catch ex As Exception
            Dim strError As String = ""
            Dim index As Integer = 0
            For Each paramName As String In aryParamNames
                strError = strError & "ParamName: " & CStr(aryParamNames(index))
                strError = strError & " ParamValue: " & CStr(aryParamValues(index))
                index = index + 1
            Next
            Throw New Exception(strError & " error message is " & ex.Message)
        End Try
    End Sub

    Public Sub RunProcedure(ByVal strName As String)
        'Purpose: run any select query 
        'Arguments: strQuery 
        'Returns: filled dataset
        'Author: Aida Mojica
        'Date: 17 March 2015

        ' CREATES INSTANCES OF THE CONNECTION AND COMMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        ' Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strName, objConnection)
        Try
            ' SETS THE COMMAND TYPE TO "STORED PROCEDURE"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            ' clear dataset
            Me.mDatasetGenre.Clear()
            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetGenre, "tblGenre")
            ' copy dataset to dataview
            mMyViewGenre.Table = mDatasetGenre.Tables("tblGenre")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try
    End Sub


    Public Sub GetAllGenres()
        RunProcedure("usp_genre_get_all")
    End Sub

    Public Sub Search()

End Class
