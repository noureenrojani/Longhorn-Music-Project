Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class ClassAlbumDB

    'Purpose: connect to tblAlbum and create dataset 
    'Arguments: tblAlbum fields
    'Returns: Dataset containing information from tblAlbumASP4 
    'Author: Aida Mojica
    'Date: 17 March 2015


    ' these module variables are internal to object
    Dim mDatasetAlbum As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team14;user id=msbcn211;password=Aida90210"

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property AlbumDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetAlbum
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView
        Get
            'return dataview to user 
            Return mMyView
        End Get
    End Property

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
            Me.mDatasetAlbum.Clear()
            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetAlbum, "tblAlbum")
            ' copy dataset to dataview
            mMyView.Table = mDatasetAlbum.Tables("tblAlbum")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Protected Sub UseSPforInsertOrUpdateQuery(ByVal strUSPName As String, ByVal aryParamNames As ArrayList, ByVal aryParamValues As ArrayList)
        'Purpose: Sort the dataview by the argument (general sub)
        'Arguments: Stored procedure name, Arraylist of parameter names, and  arraylist of parameter values
        'Returns: Nothing
        'Author: Rick Byars
        'Date: 4/03/12

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

            ' OPEN CONNECTION AND RUN INSERT/UPDATE QUERY
            objCommand.SelectCommand.Connection = objConnection
            objConnection.Open()
            objCommand.SelectCommand.ExecuteNonQuery()
            objConnection.Close()

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

    Public Sub GetAllAlbum()
        'Purpose: get all Album
        'Arguments: usp_Album_get_all
        'Returns: all Album from tblAlbum
        'Author: Aida Mojica
        'Date: 17 March 2015

        RunProcedure("usp_album_get_all")
    End Sub
    Public Sub GetAllAlbumOrder()
        RunProcedure("usp_album_get_price")
    End Sub

    Public Sub SearchByAlbumID(strIn As String)
        mMyView.RowFilter = "AlbumID ='" & strIn & "'"
    End Sub

    Public Sub UpdateEnabled(strIn As String, strEmpID As String)
        Dim aryNames As New ArrayList
        Dim aryValues As New ArrayList

        aryNames.Add("@DiscountEnabled")
        aryNames.Add("@AlbumID")

        aryValues.Add(strIn)
        aryValues.Add(strEmpID)

        'call the SP to insert the record
        UseSPforInsertOrUpdateQuery("usp_album_update_enabled", aryNames, aryValues)
    End Sub

    Public Sub UpdateAlbumPrice(strPriceRegular As String, strPriceDiscount As String, strAlbumID As String)
        Dim aryNames As New ArrayList
        Dim aryValues As New ArrayList

        aryNames.Add("@PriceRegular")
        aryNames.Add("@PriceDiscount")
        aryNames.Add("@AlbumID")

        aryValues.Add(strPriceRegular)
        aryValues.Add(strPriceDiscount)
        aryValues.Add(strAlbumID)

        'call the SP to insert the record
        UseSPforInsertOrUpdateQuery("usp_album_update_price", aryNames, aryValues)
    End Sub
End Class
