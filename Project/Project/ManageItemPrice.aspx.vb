Public Class ManageItemPrice
    Inherits System.Web.UI.Page
    Dim valid As New ClassValidate
    Dim DB As New ClassSongDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to make sure employee is logged on 

        DB.GetAllSongs()
        DB.SearchBySongID(Session("SongID"))

        'populate the textboxes 
        txtSong.Text = DB.SongDataset.Tables("tblSong").Rows(0).Item("Song").ToString
        txtAlbum.Text = DB.SongDataset.Tables("tblSong").Rows(0).Item("Album").ToString
        txtArtist.Text = DB.SongDataset.Tables("tblSong").Rows(0).Item("Artist").ToString
        txtDiscountPrice.Text = DB.SongDataset.Tables("tblSong").Rows(0).Item("PriceDiscount").ToString
        txtRegularPrice.Text = DB.SongDataset.Tables("tblSong").Rows(0).Item("PriceRegular").ToString

        
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongs.SelectedIndexChanged
        'grab the song ID 
        Session("strSongID") = gvSongs.SelectedRow.Cells(1).Text.ToString()



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If valid.CheckIfBlank(txtRegularPrice.Text) = True Then
            lblError.Text = "Regular price cannot be empty"
            Exit Sub
        End If

        If valid.CheckDecimal(txtRegularPrice.Text) = -1 Then
            lblError.Text = "Invalid regular price format"
            Exit Sub
        End If
        If valid.CheckDecimal(txtDiscountPrice.Text) = -1 Then
            lblError.Text = "Invalid discount price format"
            Exit Sub
        End If

        If txtDiscountPrice.Text >= txtRegularPrice.Text Then
            lblError.Text = "Discount cannot be greater than regular price"
            Exit Sub
        End If
        'data s good, update price 

        lblError.Text = "Price successfully updated"

    End Sub
End Class