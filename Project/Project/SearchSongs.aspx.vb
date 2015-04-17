Public Class SearchSongs
    Inherits System.Web.UI.Page
    Dim db As New ClassSearchDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Run get genres sub
        db.GetAllGenres()

        '
        cbxList.DataSource = db.GenreDataset.Tables("tblGenre")
        cbxList.DataTextField = "Genre"
        cbxList.DataValueField = "GenreID"
        cbxList.DataBind()
    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

    End Sub
End Class