Public Class ManageProductsHomepage
    Inherits System.Web.UI.Page
    Dim DB As New ClassEmployeeDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure manager is logged on 
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

    Protected Sub LinkButton15_Click(sender As Object, e As EventArgs) Handles LinkButton15.Click
        'take user to manage featured item 
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageFeatured.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub LinkButton16_Click(sender As Object, e As EventArgs) Handles LinkButton16.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageItemPrice.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub LinkButton17_Click(sender As Object, e As EventArgs) Handles LinkButton17.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageSongs.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub LinkButton18_Click(sender As Object, e As EventArgs) Handles LinkButton18.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageAlbums=" & strEmpID)
    End Sub

    Protected Sub LinkButton19_Click(sender As Object, e As EventArgs) Handles LinkButton19.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageArtists.aspx?EmpID=" & strEmpID)
    End Sub

    Protected Sub LinkButton20_Click(sender As Object, e As EventArgs) Handles LinkButton20.Click
        Dim strEmpID As String

        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        Response.Redirect("ManageAlbumPrice.aspx?EmpID=" & strEmpID)
    End Sub
End Class