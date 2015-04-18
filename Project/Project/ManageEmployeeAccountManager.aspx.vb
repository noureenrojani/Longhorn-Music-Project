Public Class ManageEmployeeAccountManager
    Inherits System.Web.UI.Page
    Dim DB As New ClassEmployeeDB
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

        'check to see if manager is logged on 
        DB.SearchByEmpID(strEmpID)

        Dim strEmpType As String
        strEmpType = DB.MyView(0).Item("EmpType").ToString
        If strEmpType.Substring(2, 1) <> "2" Then 'is not a manager
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnHireFire.Click
        lblFireError.Text = ""
        DB.GetAllEmployee()

        'declare variables 
        Dim intRow As Integer
        Dim strEmpID As String

        'find the selected index
        intRow = ddlEmployee.SelectedIndex

        'populate data from user in the textboxes
        strEmpID = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("EmpID").ToString

        If radHireFire.SelectedItem.ToString <> "Rehire" And radHireFire.SelectedItem.ToString <> "Fire" Then
            'user didn't select an item 
            lblFireError.Text = "Please select rehire or fire"
            Exit Sub
        End If

        If radHireFire.SelectedItem.ToString = "Rehire" Then
            'change IsFired to N 
            DB.UpdateIsFired("N", strEmpID)
            lblFireError.Text = "Employee " & strEmpID & " successfully rehired"
        End If

        If radHireFire.SelectedItem.ToString = "Fire" Then
            'chase IsFire to Y 
            DB.UpdateIsFired("Y", strEmpID)
            lblFireError.Text = "Employee " & strEmpID & " successfully fired"
        End If

    End Sub

    Protected Sub ddlEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmployee.SelectedIndexChanged
        Dim intRow As Integer
        intRow = ddlEmployee.SelectedIndex
        FillTextboxes()

        'clear message
        lblError.Text = ""
        lblFireError.Text = ""
        lblPromoteError.Text = ""
    End Sub

    Public Sub FillTextboxes()
        'Purpose: populate textboxes from dl 
        'Arguments: customer
        'Returns: populated textboxes 
        'Author: Aida Mojica
        'Date: 25 February 2015
        DB.GetAllEmployee()

        'declare variables 
        Dim intRow As Integer

        'find the selected index
        intRow = ddlEmployee.SelectedIndex

        'populate data from user in the textboxes
        txtFName.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("FirstName").ToString
        txtMI.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("MI").ToString
        txtLName.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("LastName").ToString
        txtAddress.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("Address").ToString
        TxtZip.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("ZipCode").ToString
        txtPassword.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("Password").ToString
        txtPhone.Text = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("Phone").ToString

        Dim DBZip As New ClassZipDB
        DBZip.GetAllZip()
        DBZip.SearchByZip(DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("ZipCode").ToString)
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
        DB.GetAllEmployee()

        ddlEmployee.DataSource = DB.EmployeeDataset
        ddlEmployee.DataTextField = "EmpID"
        ddlEmployee.DataValueField = "EmpID"
        ddlEmployee.DataBind()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim valid As New ClassValidate
        Dim strEmpID As String
        'pull up that employees data into row filter via empID
        DB.GetAllEmployee()
        'DB.SearchByEmpID(strEmpID)
        DB.SearchByEmpID(ddlEmployee.SelectedItem.ToString)
        strEmpID = ddlEmployee.SelectedItem.ToString


        'check to see if all fields are blank
        If valid.CheckIfBlank(txtFName.Text) = True And valid.CheckIfBlank(txtLName.Text) = True And valid.CheckIfBlank(txtAddress.Text) = True And valid.CheckIfBlank(TxtZip.Text) = True And valid.CheckIfBlank(txtPhone.Text) = True And valid.CheckIfBlank(txtPassword.Text) = True Then
            'all boxes are empty, give an error message
            lblError.Text = "Please populate at least one box"
            Exit Sub
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
        Dim strRecordID As String
        strRecordID = ddlEmployee.SelectedValue.ToString

        'reload DS
        DB.GetAllEmployee()

        'reload DDL
        LoadDDL()

        'point to the last customer
        ddlEmployee.SelectedValue = strRecordID
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        lblPromoteError.Text = ""
        DB.GetAllEmployee()

        'declare variables 
        Dim intRow As Integer
        Dim strEmpID As String

        'find the selected index
        intRow = ddlEmployee.SelectedIndex

        'populate data from user in the textboxes
        strEmpID = DB.EmployeeDataset.Tables("tblEmployee").Rows(intRow).Item("EmpID").ToString

        If radPromoteDemote.SelectedItem.ToString <> "Promote" And radPromoteDemote.SelectedItem.ToString <> "Demote" Then
            'user didn't select an item 
            lblFireError.Text = "Please select promote or demote"
            Exit Sub
        End If

        If radPromoteDemote.SelectedItem.ToString = "Promote" Then
            'change emp type tp 102
            DB.UpdateEmpType("102", strEmpID)
            lblFireError.Text = "Employee " & strEmpID & " successfully promoted"
        End If

        If radPromoteDemote.SelectedItem.ToString = "Demote" Then
            'chase IsFire to Y 
            DB.UpdateEmpType("101", strEmpID)
            lblPromoteError.Text = "Employee " & strEmpID & " successfully demoted"
        End If
    End Sub
End Class