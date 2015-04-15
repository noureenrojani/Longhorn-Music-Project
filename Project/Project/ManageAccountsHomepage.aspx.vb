Public Class ManageAccountsHomepage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure that employee is logged on 
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        If strEmpID = "" Then 'employee is not logged on 
            Response.Redirect("Homepage.aspx")
        End If

        If strEmpID.Substring(1, 2) = "2" Then 'is a manager
            'check to see if manager, if so display manage employee account link 
            lnkManageAnEmployeeAccount.Visible = True
        End If


    End Sub

End Class