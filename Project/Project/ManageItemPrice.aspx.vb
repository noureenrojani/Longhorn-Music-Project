'Public Class ManageItemPrice
'    Inherits System.Web.UI.Page
'    Dim valid As New ClassValidate
'    Dim DB As New ClassSongDB
'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        'check to make sure employee is logged on 

'        If IsPostBack = False Then
'            UpdateGV()
'        End If




'    End Sub



'    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSongs.SelectedIndexChanged
'        'grab the song ID 
'        Session("SongID") = gvSongs.SelectedRow.Cells(1).Text.ToString
'        Dim strIndex As String
'        strIndex = gvSongs.SelectedIndex
'        DB.GetAllSongOrder()
'        DB.SearchBySongID(Session("SongID"))

'        'populate the textboxes 
'        txtSong.Text = DB.MyView(0).Item("Song").ToString
'        txtAlbum.Text = DB.MyView(0).Item("Album").ToString
'        txtArtist.Text = DB.MyView(0).Item("Artist").ToString
'        txtDiscountPrice.Text = DB.MyView(0).Item("PriceDiscount").ToString
'        txtRegularPrice.Text = DB.MyView(0).Item("PriceRegular").ToString



'    End Sub

'    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        If valid.CheckIfBlank(txtRegularPrice.Text) = True Then
'            lblError.Text = "Regular price cannot be empty"
'            Exit Sub
'        End If

'        If valid.CheckDecimal(txtRegularPrice.Text) = -1 Then
'            lblError.Text = "Invalid regular price format"
'            Exit Sub
'        End If
'        If valid.CheckIfBlank(txtDiscountPrice.Text) = False Then
'            If valid.CheckDecimal(txtDiscountPrice.Text) = -1 Then
'                lblError.Text = "Invalid discount price format"
'                Exit Sub
'            End If

'            If txtDiscountPrice.Text >= txtRegularPrice.Text Then
'                lblError.Text = "Discount cannot be greater than regular price"
'                Exit Sub
'            End If
'        End If

'        'data s good, update price 
'        DB.UpdateSongPrice(txtRegularPrice.Text, txtDiscountPrice.Text, Session("SongID"))

'        lblError.Text = "Price successfully updated"
'        'update gb
'        UpdateGV()


'    End Sub

'    Protected Sub btnDisable_Click(sender As Object, e As EventArgs) Handles btnDisable.Click
'        lblRadError.Text = ""
'        lblError.Text = ""

'        DB.GetAllSongs()
'        If txtSong.Text = "" Then
'            'user didn't select an item to edit 
'            lblRadError.Text = "please select a song below to enable/disable"
'            Exit Sub
'        End If

'        If txtDiscountPrice.Text = "" Then
'            'cannot enable or disable song where there is no discount
'            lblRadError.Text = "cannot enable or disable song where there is no discount price"
'            Exit Sub
'        End If


'        If radDisable.SelectedItem.ToString = "Disable" Then
'            'change Enabled to N
'            DB.UpdateEnabled("N", Session("SongID"))
'            lblRadError.Text = "Customer " & Session("SongID") & " successfully disabled"
'        End If

'        If radDisable.SelectedItem.ToString = "Enable" Then
'            'chase enabled to Y
'            DB.UpdateEnabled("Y", Session("SongID"))
'            lblRadError.Text = "Customer " & Session("SongID") & " successfully enabled"
'        End If

'        'update enabled in DB
'        UpdateGV()

'    End Sub

'    Public Sub UpdateGV()
'        'get all customers from database
'        DB.GetAllSongOrder()

'        'set up grid view
'        gvSongs.DataSource = DB.SongDataset
'        gvSongs.DataBind()
'    End Sub
'End Class