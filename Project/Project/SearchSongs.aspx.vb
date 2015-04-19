﻿Public Class SearchSongs
    Inherits System.Web.UI.Page
    Dim db As New ClassSearchDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Run sub to get genres
        db.GetAllGenres()

        'Load genres into checkbox list
        cbxList.DataSource = db.GenreDataset.Tables("tblGenre")
        cbxList.DataTextField = "Genre"
        cbxList.DataValueField = "GenreID"
        cbxList.DataBind()
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        db.GetSongbyTitle(txtSearchsong.Text)

        gvSongResults.DataSource = db.ResultView

        gvSongResults.DataBind()






    End Sub
End Class