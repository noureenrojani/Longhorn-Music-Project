Public Class ManageFeatured
    Inherits System.Web.UI.Page

    Dim DBFeat As New ClassFeaturedDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'make sure user is a manager 
        ''Dim strEmpID As String

        ' ''get EmpID in the URL 
        ''strEmpID = Request.QueryString("EmpID")


    End Sub

    Protected Sub btnFeatured_Click(sender As Object, e As EventArgs) Handles btnFeatured.Click
        lblError.Text = ""

        'make sure at least one field isn't empty 
        If txtAlbum.Text = "" Or txtArtist.Text = "" Or txtSong.Text = "" Then
            lblError.Text = "Please enter at least one field"
            Exit Sub
        End If

        'validate that the song, album, or artist is already in the db

        'input is good delete what was in tblFeatured 
        DBFeat.UpdateFeatured(txtArtist.Text, txtSong.Text, txtAlbum.Text, txtURL.Text)

        'maybe add the option to view changes before actually updating it 

        'give completion message
        lblError.Text = "Featured item was updated"


    End Sub
End Class