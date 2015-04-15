Public Class Homepage

    Inherits System.Web.UI.Page
    Dim DBFeat As New ClassFeaturedDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strEmpID As String
        Dim strCustEmail As String


        'get EmpID in the URL 
        strEmpID = Request.QueryString("EmpID")

        'get customer email in URL
        strCustEmail = Request.QueryString("Email")
        'check to see who is logged on and welcome
        If strCustEmail <> "" Then
            'cust is logged on welcome them 
            lblEmail.Visible = True
            lblEmail.Text = "Welcome " & strCustEmail
            ShowFeatured()
        ElseIf strEmpID <> "" Then
            'cust is logged on welcome them 
            lblEmail.Visible = True
            lblEmail.Text = "Welcome Amployee " & strEmpID
        Else
            'nobody is logged on 
            lblEmail.Text = ""
            lblEmail.Visible = False
            ShowFeatured()
        End If
    End Sub

    Public Sub ShowFeatured()

        DBFeat.GetAllFeatured()
        If DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("song").ToString <> "" Then
            'there is a featured song 
            lblFeatured.Text = "The Featured Song is " & DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("song").ToString
        ElseIf DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("album").ToString <> "" Then
            'there is a featured album 
            lblFeatured.Text = "The Featured Album is " & DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("album").ToString
        Else
            'there is a featured Artist
            lblFeatured.Text = "The featured Artist is" & DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("artist").ToString
        End If

        FeatImage.ImageUrl = DBFeat.FeatDataset.Tables("tblFeatured").Rows(0).Item("URL").ToString
    End Sub
End Class

