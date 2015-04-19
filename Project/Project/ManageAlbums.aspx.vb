Public Class ManageAlbums
    Inherits System.Web.UI.Page

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
    End Sub

End Class