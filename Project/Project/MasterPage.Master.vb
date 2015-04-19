Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strCustEmail As String
        Dim strEmpID As String

        'get customer email in URL
        strCustEmail = Request.QueryString("Email")
        strEmpID = Request.QueryString("EmpID")

        '''''
        Dim strEmpIDSession As String
        strEmpIDSession = Convert.ToString(Session("EmpID"))
        Session("EmpID") = strEmpID

        '''''''
        'check to see which is blank to determine which panel to show 
        If strEmpID <> "" Then
            'employee is logged on, show employee panel
            pnlNotLoggedOn.Visible = False
            pnlEmployeeLoggedOn.Visible = True
            pnlCustomerLoggedIn.Visible = False
        ElseIf strCustEmail <> "" Then
            pnlNotLoggedOn.Visible = False
            pnlEmployeeLoggedOn.Visible = False
            pnlCustomerLoggedIn.Visible = True
        Else
            pnlNotLoggedOn.Visible = True
            pnlEmployeeLoggedOn.Visible = False
            pnlCustomerLoggedIn.Visible = False
        End If

<<<<<<< HEAD
    End Sub

    Protected Sub LinkButton7_Click(sender As Object, e As EventArgs) Handles LinkButton7.Click

        Response.Redirect("ManageAccountsHomepage.aspx?EmpID=" & Convert.ToString(Session("EmpID")))
    End Sub

=======
    End Sub

    Protected Sub LinkButton7_Click(sender As Object, e As EventArgs) Handles LinkButton7.Click

        Response.Redirect("ManageAccountsHomepage.aspx?EmpID=" & Convert.ToString(Session("EmpID")))
    End Sub

>>>>>>> d81be794ee9d8a9a47f178f1ac6dad353610c831
    Protected Sub LinkButton6_Click(sender As Object, e As EventArgs) Handles LinkButton6.Click
        Response.Redirect("LogOut.aspx")
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("LogOut.aspx")
    End Sub
<<<<<<< HEAD
=======

    Protected Sub LinkButton14_Click(sender As Object, e As EventArgs) Handles LinkButton14.Click

    End Sub

    Protected Sub LinkButton8_Click(sender As Object, e As EventArgs) Handles LinkButton8.Click
        'go to manageproductshomepage 
        Response.Redirect("ManageProductsHomepage.aspx?EmpID=" & Convert.ToString(Session("EmpID")))
    End Sub
>>>>>>> d81be794ee9d8a9a47f178f1ac6dad353610c831
End Class