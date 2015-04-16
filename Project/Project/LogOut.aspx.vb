Public Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'clear out session variables and query string 
        Session("CustEmail") = ""
        Session("EmpID") = ""
        'pull out query strings if available 
        Dim strCustEmail As String
        Dim strEmpID As String

        'get customer email in URL
        strCustEmail = Request.QueryString("Email")
        strEmpID = Request.QueryString("EmpID")
    End Sub

End Class