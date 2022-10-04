Public Class SiteMaster
    Inherits MasterPage
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If Session("Usuario") <> "" Then
         lblSesion.Text = Session("Usuario")
      End If
   End Sub
End Class