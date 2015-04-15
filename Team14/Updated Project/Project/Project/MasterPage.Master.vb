Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strEmpID As String
        Dim strCustEmail As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        'get customer email in URL
        strCustEmail = Request.QueryString("Email")

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
    End Sub

End Class