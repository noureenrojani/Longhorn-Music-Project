Public Class ManageAlbumPrice
    Inherits System.Web.UI.Page

    Dim db As New ClassAlbumDB
    Dim valid As New ClassValidate

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

        If IsPostBack = False Then
            UpdateGV()
        End If
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
        If valid.CheckIfBlank(txtDiscountPrice.Text) = False Then
            If valid.CheckDecimal(txtDiscountPrice.Text) = -1 Then
                lblError.Text = "Invalid discount price format"
                Exit Sub
            End If

            If txtDiscountPrice.Text >= txtRegularPrice.Text Then
                lblError.Text = "Discount cannot be greater than regular price"
                Exit Sub
            End If
        End If

        'data s good, update price 
        db.UpdateAlbumPrice(txtRegularPrice.Text, txtDiscountPrice.Text, Session("AlbumID"))

        lblError.Text = "Price successfully updated"
        'update gb
        UpdateGV()
    End Sub

    Protected Sub gvAlbum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAlbum.SelectedIndexChanged
        'grab the AlbumID
        Session("AlbumID") = gvAlbum.SelectedRow.Cells(1).Text.ToString
        Dim strSongID As String
        strSongID = gvAlbum.SelectedRow.Cells(1).Text.ToString
        Dim strIndex As String
        strIndex = gvAlbum.SelectedIndex
        db.GetAllAlbumOrder()
        db.SearchByAlbumID(strSongID)

        'populate the textboxes 
        txtAlbum.Text = DB.MyView(0).Item("Album").ToString
        txtArtist.Text = DB.MyView(0).Item("Artist").ToString
        txtDiscountPrice.Text = DB.MyView(0).Item("PriceDiscount").ToString
        txtRegularPrice.Text = DB.MyView(0).Item("PriceRegular").ToString
    End Sub

    Protected Sub btnDisable_Click(sender As Object, e As EventArgs) Handles btnDisable.Click
        lblRadError.Text = ""
        lblError.Text = ""

        db.GetAllAlbumOrder()
        If txtAlbum.Text = "" Then
            'user didn't select an item to edit 
            lblRadError.Text = "please select a song below to enable/disable"
            Exit Sub
        End If

        If txtDiscountPrice.Text = "" Then
            'cannot enable or disable song where there is no discount
            lblRadError.Text = "cannot enable or disable song where there is no discount price"
            Exit Sub
        End If


        If radDisable.SelectedItem.ToString = "Disable" Then
            'change Enabled to N
            db.UpdateEnabled("N", Session("AlbumID"))
            lblRadError.Text = "Customer " & Session("AlbumID") & " successfully disabled"
        End If

        If radDisable.SelectedItem.ToString = "Enable" Then
            'chase enabled to Y
            db.UpdateEnabled("Y", Session("AlbumID"))
            lblRadError.Text = "AlbumID " & Session("AlbumID") & " successfully enabled"
        End If

        'update enabled in DB
        UpdateGV()
    End Sub

    Public Sub UpdateGV()
        'get all customers from database
        db.GetAllAlbumOrder()

        'set up grid view
        gvAlbum.DataSource = db.AlbumDataset
        gvAlbum.DataBind()
    End Sub
End Class