Public Class ManageCustomerAccountEmployee
    Inherits System.Web.UI.Page
    Dim DB As New ClassCustomerDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure employee is logged on 
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")
        If strEmpID = "" Then
            'employee did not log on 
            Response.Redirect("Login.aspx")
            Exit Sub
        End If

        'check to see if this is theh first time the page loads 
        If IsPostBack = False Then
            'if it is the first time, load the ddl 
            'Show customer name in ddl 
            LoadDDL()
            FillTextboxes()
        End If
    End Sub



    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        Dim intRow As Integer
        intRow = ddlCustomer.SelectedIndex
        FillTextboxes()

        'clear message
        lblError.Text = ""
        lblDisableError.Text = ""

    End Sub

    Public Sub FillTextboxes()
        'Purpose: populate textboxes from dl 
        'Arguments: customer
        'Returns: populated textboxes 
        'Author: Aida Mojica
        'Date: 25 February 2015
        DB.GetAllCustomers()

        'declare variables 
        Dim intRow As Integer

        'find the selected index
        intRow = ddlCustomer.SelectedIndex

        'populate data from user in the textboxes
        txtEmail.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("EmailAddr").ToString
        txtFName.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("FirstName").ToString
        txtMI.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("MI").ToString
        txtLName.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("LastName").ToString
        txtAddress.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("Address").ToString
        TxtZip.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("ZipCode").ToString
        txtPassword.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("Password").ToString
        txtPhone.Text = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("Phone").ToString

        Dim DBZip As New ClassZipDB
        DBZip.GetAllZip()
        DBZip.SearchByZip(DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("ZipCode").ToString)
        If DBZip.MyView Is Nothing Then
            'zip code was not found 
            lblError.Text = "Zipcode not found"
            Exit Sub
        Else
            'fill in city and state textbox 
            txtCityState.Text = DBZip.MyView(0).Item("City").ToString & ", " & DBZip.MyView(0).Item("State").ToString

        End If

    End Sub


    Private Sub LoadDDL()
        'Purpose: load data ddl
        'Arguments: N/A
        'Returns: populate ddl  
        'Author: Aida Mojica
        'Date: 25 February 2015
        DB.GetAllCustomers()

        ddlCustomer.DataSource = DB.CustDataset
        ddlCustomer.DataTextField = "EmailAddr"
        ddlCustomer.DataValueField = "EmailAddr"
        ddlCustomer.DataBind()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim valid As New ClassValidate
        Dim strEmpID As String
        Dim intIndex As Integer

        'pull up that employees data into row filter via empID
        DB.GetAllCustomers()
        'DB.SearchByEmpID(strEmpID)
        DB.SearchByEmail(ddlCustomer.SelectedItem.ToString)
        strEmpID = ddlCustomer.SelectedItem.ToString
        intIndex = ddlCustomer.SelectedIndex

        'check to see if all fields are blank
        If valid.CheckIfBlank(txtEmail.Text) = True And valid.CheckIfBlank(txtFName.Text) = True And valid.CheckIfBlank(txtLName.Text) = True And valid.CheckIfBlank(txtAddress.Text) = True And valid.CheckIfBlank(TxtZip.Text) = True And valid.CheckIfBlank(txtPhone.Text) = True And valid.CheckIfBlank(txtPassword.Text) = True Then
            'all boxes are empty, give an error message
            lblError.Text = "Please populate at least one box"
            Exit Sub
        End If

        'check to see if Email is blank, if not validate and update
        If valid.CheckIfBlank(txtEmail.Text) = False Then
            'check to see if email already exists or hasn't changed 
            If txtEmail.Text <> ddlCustomer.SelectedItem.ToString Then
                'user updated email address 
                DB.SearchByEmail(txtEmail.Text)
                If DB.MyView.Count <> 0 Then
                    'email is taken give error
                    lblError.Text = "Email already taken"
                    Exit Sub
                End If
            End If
            'passed all the test, update email
            DB.UpdateEmail(txtEmail.Text, strEmpID)
            lblError.Text = "Email Successfully Updated"
            strEmpID = txtEmail.Text
        End If

        'check to see if FName is blank if not validate and update
        If valid.CheckIfBlank(txtFName.Text) = False Then
            'run whatever validation
            'update fname in db 
            DB.UpdateFName(txtFName.Text, strEmpID)
            lblError.Text = "First Name Successfully updated"
        End If

        'check tosee if MI is blank if not validate and update 
        If valid.CheckIfBlank(txtMI.Text) = False Then
            'run whatever validation
            If valid.CheckMI(txtMI.Text) = False Then
                lblError.Text = "MI invalid"
                Exit Sub
            End If
            'update fname in db 
            DB.UpdateMI(txtMI.Text, strEmpID)
            lblError.Text = "MI Successfully updated"
        End If

        'CheckBox to see if LNamame is blank if not validate and update 
        If valid.CheckIfBlank(txtLName.Text) = False Then
            'run whatever validation
            'update fname in db 
            DB.UpdateLName(txtLName.Text, strEmpID)
            lblError.Text = "Last Name Successfully updated"
        End If

        'check to if Address is Blank, if not validate
        If valid.CheckIfBlank(txtAddress.Text) = False Then
            'Run whatever address validation 
            'Update address field in DB
            DB.UpdateAddress(txtAddress.Text, strEmpID)
            'give completion message 
            lblError.Text = "Address successfully updated"
        End If

        'check to see if Zip is blank, if not validate 
        If valid.CheckIfBlank(TxtZip.Text) = False Then
            'validate 
            If valid.CheckZip(TxtZip.Text) = False Then
                lblError.Text = "Zip not valid"
                Exit Sub
            End If

            'check to make sure zip in db 
            Dim DBZip As New ClassZipDB
            DBZip.GetAllZip()
            DBZip.SearchByZip(TxtZip.Text)
            If DBZip.MyView Is Nothing Then
                'zip code was not found 
                lblError.Text = "Zipcode not found"
                Exit Sub
            Else
                'fill in city and state textbox 
                txtCityState.Text = DBZip.MyView(0).Item("City").ToString & ", " & DBZip.MyView(0).Item("State").ToString

            End If

            'Update Zip in DB 
            DB.UpdateZip(TxtZip.Text, strEmpID)



            'give competion message
            lblError.Text = "Zip successfully updated"
        End If

        'check to see if phone is blank, if not validate 
        If valid.CheckIfBlank(txtPhone.Text) = False Then
            'validate 
            If valid.CheckPhone(txtPhone.Text) = False Then
                lblError.Text = "Phone invalid format"
                Exit Sub
            End If
            'update phone in DB 
            DB.UpdatePhone(txtPhone.Text, strEmpID)
            'give completion meesage
            lblError.Text = "Phone successfully updated"
        End If

        'check to see if password is blank, if not validate 
        If valid.CheckIfBlank(txtPassword.Text) = False Then
            'make sure password is in proper format or not the same 

            'if old password is correct, update password 
            DB.UpdatePassword(txtPassword.Text, strEmpID)
            lblError.Text = "Password successfully updated"

        End If

        'user updated one then more field successfully, give completion message
        lblError.Text = "Information successfully updated "

        'save record ID of the current customer 
   

        'reload DS
        DB.GetAllCustomers()

        'reload DDL
        LoadDDL()

        'point to the last customer
        ddlCustomer.SelectedValue = strEmpID
    End Sub


    Protected Sub btnHireFire_Click(sender As Object, e As EventArgs) Handles btnHireFire.Click

        lblDisableError.Text = ""
        lblError.Text = ""

        DB.GetAllCustomers()

        'declare variables 
        Dim intRow As Integer
        Dim strEmail As String

        'find the selected index
        intRow = ddlCustomer.SelectedIndex

        'populate data from user in the textboxes
        strEmail = DB.CustDataset.Tables("tblCustomer").Rows(intRow).Item("EmailAddr").ToString

  

        If radHireFire.SelectedItem.ToString = "Disable" Then
            'change Enabled to N
            DB.UpdateEnabled("N", strEmail)
            lblDisableError.Text = "Customer " & strEmail & " successfully disabled"
        End If

        If radHireFire.SelectedItem.ToString = "Enable" Then
            'chase enabled to Y
            DB.UpdateEnabled("Y", strEmail)
            lblDisableError.Text = "Customer " & strEmail & " successfully enabled"
        End If

    End Sub




End Class