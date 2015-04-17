Public Class ManageProductsHomepage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure manager is logged on 
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
End Class