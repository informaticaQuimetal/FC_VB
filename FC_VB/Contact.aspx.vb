Public Class Contact
    Inherits Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      Session("Usuario") = ""
      Session("Rol") = ""
      Response.Redirect("~/Login.aspx")
   End Sub
End Class