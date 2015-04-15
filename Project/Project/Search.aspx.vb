Public Class Search
    Inherits System.Web.UI.Page
    Dim db As New ClassSearchDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        db.UseSP("usp_genre_get_all", )


    End Sub

End Class