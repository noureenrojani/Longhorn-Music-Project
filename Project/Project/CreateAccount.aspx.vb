Public Class CreateAccount
    Inherits System.Web.UI.Page

    'Instantiate classes
    Dim CustDB As New ClassCustomerDB
    Dim Valid As New ClassValidate
    Dim Format As New ClassFormat

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        'To stop the add from working IF built in validators are incorrect
        If Me.IsValid = False Then
            Exit Sub
        End If

        'Initial validator error message
        If txtMI.Text <> "" Then
            If Valid.CheckMI(txtMI.Text) = False Then
                lblError.Text = "Invalid Initial"
                Exit Sub
            End If
        End If

        'Zipcode validator error message
        If txtZipCode.Text <> "" Then
            If Valid.CheckZip(txtZipCode.Text) = False Then
                lblError.Text = "Invalid Zipcode"
                Exit Sub
            End If
        End If

        'Email handled by built in validator

        'Phone validator error message
        If txtPhone.Text <> "" Then
            If Valid.CheckPhone(txtPhone.Text) = False Then
                lblError.Text = "Invalid Phone Number"
                Exit Sub
            End If
        End If

        'Add a new account
        CustDB.AddAccount(txtEmailAddr.Text, txtPassword.Text, txtFirstName.Text, txtMI.Text, txtLastName.Text, txtAddress.Text, txtZipCode.Text, txtPhone.Text, txtEnabled.Text)
        lblError.Text = "Account Created!"
    End Sub

End Class