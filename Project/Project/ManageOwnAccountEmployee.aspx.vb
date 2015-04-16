Public Class ManageOwnAccountEmployee
    Inherits System.Web.UI.Page

    Dim valid As New ClassValidate
    Dim DB As New ClassEmployeeDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure an employee is logged on, else redirect 
        'check to make sure that employee is logged on 



        'If Session("EmpID") Is Nothing Then 'employee is not logged on 
        '    Response.Redirect("Homepage.aspx")
        'End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Define variables 
        Dim strEmpID As String
        Dim strOldPassword As String
        '''
        Dim strEmpIDSession As Double
        strEmpIDSession = Convert.ToString(Session("EmpID"))

        '''
        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")
        lblError.Text = strEmpID
        'pull up that employees data into row filter via empID
        DB.GetAllEmployee()
        'DB.SearchByEmpID(strEmpID)
        DB.SearchByEmpID(Convert.ToString(Session("EmpID")))
        strOldPassword = DB.MyView(0).Item("Password").ToString

        'check to see if all fields are blank
        If valid.CheckIfBlank(txtAddress.Text) = True And valid.CheckIfBlank(txtZip.Text) = True And valid.CheckIfBlank(txtPhone.Text) = True And valid.CheckIfBlank(txtPassword.Text) = True Then
            'all boxes are empty, give an error message
            lblError.Text = "Please populate at least one box"
            Exit Sub
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
        If valid.CheckIfBlank(txtZip.Text) = False Then
            'validate 
            If valid.CheckZip(txtZip.Text) = False Then
                lblError.Text = "Zip not valid"
                Exit Sub
            End If

            'check to make sure zip in db 
            Dim DBZip As New ClassZipDB
            DBZip.GetAllZip()
            DBZip.SearchByZip(txtZip.Text)
            If DBZip.MyView Is Nothing Then
                'zip code was not found 
                lblError.Text = "Zipcode not found"
                Exit Sub
            Else
                'fill in city and state textbox 
                txtCityState.Text = DBZip.MyView(0).Item("City").ToString & ", " & DBZip.MyView(0).Item("State").ToString

            End If

            'Update Zip in DB 
            DB.UpdateZip(txtZip.Text, strEmpID)

            

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
            'If txtOldPassword.Text = strOldPassword Then
            '    lblError.Text = "Cannot use old password"
            '    Exit Sub
            'End If

            'make old password lbl and txtbox appear 
            txtOldPassword.Visible = True
            lblEnterOldPassword.Visible = True

            'make sure old password is not blank 
            If valid.CheckIfBlank(txtOldPassword.Text) = True Then
                'give an error message 
                lblError.Text = "Old Password cannot be blank"
                Exit Sub
            End If

            'make sure employee correctly enters old password, if not give error message 
            If txtOldPassword.Text <> strOldPassword Then
                lblError.Text = "Incorrect Old Password"
                Exit Sub
            End If
            'if old password is correct, update password 
            DB.UpdatePassword(txtPassword.Text, strEmpID)
            lblError.Text = "Password successfully updated"

        End If

        'user updated one then more field successfully, give completion message
        lblError.Text = "Information successfully updated "
    End Sub
End Class