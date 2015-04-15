'Author: Aida Mojica
'Assignment: ASP6
'Date: 17 March 2015
'Program Description: Connect to database and check username and password 
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class ClassCustomerDB
    'Purpose: connect to tblCustomers and create dataset 
    'Arguments: tblCustomer fields
    'Returns: Dataset containing information from tblCustomersASP4 
    'Author: Aida Mojica
    'Date: 17 March 2015


    ' these module variables are internal to object
    Dim mDatasetCustomer As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team14;user id=msbcn211;password=Aida90210"

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property CustDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetCustomer
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
            Me.mDatasetCustomer.Clear()
            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetCustomer, "tblCustomer")
            ' copy dataset to dataview
            mMyView.Table = mDatasetCustomer.Tables("tblCustomer")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try
    End Sub

    Public Sub GetAllCustomers()
        'Purpose: get all customers
        'Arguments: usp_customers_get_all
        'Returns: all customers from tblCustomers
        'Author: Aida Mojica
        'Date: 17 March 2015

        RunProcedure("usp_customer_get_all")
    End Sub

    Public Sub SearchByEmail(strIn As String)
        mMyView.RowFilter = "EmailAddr ='" & strIn & "'"
    End Sub

    Public Sub AddAccount(ByVal strEmailAddr As String, ByVal strPassword As String, ByVal strFirstName As String, ByVal strMI As String, ByVal strLastName As String, ByVal strAddress As String, ByVal strZipCode As String, ByVal strPhone As String, ByVal strEnabled As String)
        'Purpose: To add a customer account
        'Parameters: String values
        'Returns: None
        'Author: Noureen Rojani
        'Date: February 18, 2015

        'Add new record
        'Build INSERT query
        mstrQuery = "INSERT INTO tblCustomer (EmailAddr, Password, FirstName, MI, LastName, Address, ZipCode, Phone, Enabled) VALUES (" & _
      "'" & strEmailAddr & "', " & _
      "'" & strPassword & "', " & _
      "'" & strFirstName & "', " & _
      "'" & strMI & "', " & _
      "'" & strLastName & "', " & _
      "'" & strAddress & "', " & _
      "'" & strZipCode & "', " & _
      "'" & strPhone & "', " & _
      "'" & strEnabled & "')"

        'Run query to insert record
        UpdateDB(mstrQuery)
    End Sub

    Public Sub UpdateDB(ByVal strQuery As String)
        'Purpose: Run given query to update database
        'Parameter: One string (any SQL statement)
        'Return: Nothing
        Try
            'Make connection using the connection string above
            mdbConn = New SqlConnection(mstrConnection)
            Dim dbCommand As New SqlCommand(strQuery, mdbConn)

            'Open the connection
            mdbConn.Open()

            'Run the query
            dbCommand.ExecuteNonQuery()

            'Close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("Query is " & strQuery.ToString & " error is " & ex.Message)
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

    Public Sub UpdateFeatured(strEmailAddr As String, strPassword As String, strFirstName As String, strMI As String, strLastName As String, strAddress As String, strZipCode As String, strPhone As String)
        Dim aryNames As New ArrayList
        Dim aryValues As New ArrayList

        'update tblFeatured with new song 
        aryNames.Add("@EmailAddr")
        aryNames.Add("@Password")
        aryNames.Add("@FirstName")
        aryNames.Add("@MI")
        aryNames.Add("@LastName")
        aryNames.Add("@Address")
        aryNames.Add("@ZipCode")
        aryNames.Add("@Phone")

        aryValues.Add(strEmailAddr)
        aryValues.Add(strPassword)
        aryValues.Add(strFirstName)
        aryValues.Add(strMI)
        aryValues.Add(strLastName)
        aryValues.Add(strAddress)
        aryValues.Add(strZipCode)
        aryValues.Add(strPhone)

        'call the SP to insert the record
        UseSPforInsertOrUpdateQuery("usp_customer_insert", aryNames, aryValues)
    End Sub
End Class

