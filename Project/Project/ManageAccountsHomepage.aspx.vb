Public Class ManageAccountsHomepage
    Inherits System.Web.UI.Page

    Dim db As New ClassEmployeeDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure that employee is logged on 
        ''check to make sure that employee is logged on 
   

        'If strEmpID = "" Then 'employee is not logged on 
        '    Response.Redirect("Homepage.aspx")
        '    Exit Sub
        'End If

        'If Session("EmpID") Is Nothing Then
        '    Response.Redirect("Homepage.aspx")
        '    Exit Sub
        'End If

        'check to see if EmpType is 102 if manager 
        db.GetAllEmployee()

        ''''        
        '' Dim strEmpIDSession As Double
        ''strEmpIDSession = Convert.ToDouble(Session("EmpID"))
        ''''

        db.SearchByEmpID(Convert.ToString(Session("EmpID")))
        ''db.SearchByEmpID(strEmpIDSession)


        Dim strEmpType As String
        strEmpType = db.MyView(0).Item("EmpType").ToString
        If strEmpType.Substring(2, 1) = "2" Then 'is a manager
            'check to see if manager, if so display manage employee account link 
            lnkManageAnEmployeeAccount.Visible = True
        End If



    End Sub


    Protected Sub lnkManageYourOwnEmpAccount_Click(sender As Object, e As EventArgs) Handles lnkManageYourOwnEmpAccount.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageOwnAccountEmployee.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub lnkManageCustomerAccount_Click(sender As Object, e As EventArgs) Handles lnkManageCustomerAccount.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageCustomerAccountEmployee.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub lnkManageAnEmployeeAccount_Click(sender As Object, e As EventArgs) Handles lnkManageAnEmployeeAccount.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageEmployeeAccountManager.aspx?EmpID=" & strEmpID)
    End Sub
End Class