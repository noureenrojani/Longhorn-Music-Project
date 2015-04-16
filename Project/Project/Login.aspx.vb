Public Class Login
    Inherits System.Web.UI.Page
    Dim DBCust As New ClassCustomerDB
    Dim DBEmp As New ClassEmployeeDB
    Dim valid As New ClassValidate

    Dim mintCountCust As Integer
    Dim mintCountEmp As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Purpose: keep count of login attempts when page loads
        'Arguments: number of times user fails to log in correctly 
        'Returns: disables login button if user fails to login after 3 attempts 
        'Author: Aida Mojica
        'Date: 17 March 2015

        'if it's the first time the page has loaded set the count to 0 
        If IsPostBack = False Then
            Session("CustCount") = 0
            Session("EmpCout") = 0
        End If

        'check to see if Cust has tried to login before 
        If Session("CustCount") = 2 Then
            'user has had 3 attempts, disable login button 
            btnCustomerLogin.Enabled = False
            lblLoginCust.Text = "Login Disabled"
            Exit Sub
        End If

        'check to see if Emp has tried to login before 
        If Session("EmpCount") = 2 Then
            'user has had 3 attempts, disable login button 
            btnEmployeeLogin.Enabled = False
            lblLoginEmp.Text = "Login Disabled"
            Exit Sub
        End If
    End Sub

    Protected Sub btnCustomerLogin_Click(sender As Object, e As EventArgs) Handles btnCustomerLogin.Click
        'clear out error message
        lblCustomerError.Text = ""

        'check built in validators, both fields not blank  
        If IsValid = False Then
            AddToLoginCountCust()
            Exit Sub
        End If

        'get all customers from database
        DBCust.GetAllCustomers()

        'check to see if email is in the dataview 
        DBCust.SearchByEmail(txtCustomerEmail.Text)
        If DBCust.MyView.Count = 0 Then
            'username does not exist 
            lblCustomerError.Text = "Email not found"
            AddToLoginCountCust()
            Exit Sub
        End If


        'check to see if password matches 
        If txtCustomerPassword.Text <> DBCust.MyView(0).Item("password").ToString Then
            'password is incorrect 
            lblCustomerError.Text = "Invalid password"
            AddToLoginCountCust()
            Exit Sub
        End If

        'login successful, redirect to homepage where you will now show CustPanel and store email in url 
        lblCustomerError.Text = "login successful"
        Response.Redirect("Homepage.aspx?Email=" & txtCustomerEmail.Text)
        Session("CustEmail") = txtCustomerEmail.Text

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        'clear out error message
        lblEmployeeError.Text = ""

        'check built in validators, both fields not blank  
        If IsValid = False Then
            AddToLoginCountEmp()
            Exit Sub
        End If

        'get all customers from database
        DBEmp.GetAllEmployee()

        'validate username 
        'check to see if digits 
        If valid.CheckForDigits(txtEmpID.Text) = False Then
            lblEmployeeError.Text = "Invalid Username"
            AddToLoginCountEmp()
            Exit Sub
        End If

        'check to see if username is in the dataview 
        DBEmp.SearchByEmpID(txtEmpID.Text)
        If DBEmp.MyView.Count = 0 Then
            'username does not exist 
            lblEmployeeError.Text = "Invalid Username"
            AddToLoginCountEmp()
            Exit Sub
        End If

        'check to see if employee is fired 
        If DBCust.MyView(0).Item("IsFired").ToString = "Y" Then
            'employee is fired 
            lblEmployeeError.Text = "You were fired"
            Exit Sub
        End If
        'check to see if password matches 
        If txtEmpPassword.Text <> DBEmp.MyView(0).Item("password").ToString Then
            'password is incorrect 
            lblEmployeeError.Text = "Invalid password"
            AddToLoginCountEmp()
            Exit Sub
        End If

        'login successful, redirect to homepage where you will now show EmpPanel and store emp id in url 
        lblEmployeeError.Text = "login successful"
        Response.Redirect("Homepage.aspx?EmpID=" & txtEmpID.Text)
        ''''added session variable 
        Session("EmpID") = txtEmpID.Text

    End Sub

    Public Sub AddToLoginCountCust()
        'Purpose: add to login count for each bad login attempt
        'Arguments: mintCount
        'Returns: N/A, adds 1 to mintCount and puts session back on server
        'Author: Aida Mojica
        'Date: 2 March 2015

        'add to login attempt
        mintCountCust = Session("CustCount")
        mintCountCust += 1
        'put session back on server 
        Session("CustCount") = mintCountCust
    End Sub

    Public Sub AddToLoginCountEmp()
        'Purpose: add to login count for each bad login attempt
        'Arguments: mintCount
        'Returns: N/A, adds 1 to mintCount and puts session back on server
        'Author: Aida Mojica
        'Date: 2 March 2015

        'add to login attempt
        mintCountEmp = Session("EmpCount")
        mintCountEmp += 1
        'put session back on server 
        Session("EmpCount") = mintCountEmp
    End Sub
End Class