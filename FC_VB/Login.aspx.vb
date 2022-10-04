Imports System.Web
Imports System.Data.SqlClient

Public Class Login
   Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Dim Usuario As String = ""
      Dim Rol As String = ""
      Dim Cargo As String = ""
      Dim sM As String = ConfigurationManager.AppSettings("EnMantencion")

      If Not IsPostBack Then
         If sM = "SI" Then
            Response.Redirect("~/Mantenimiento.html")
         Else
            Try
               If Session("Usuario") <> "" Then
                  Usuario = Session("Usuario").ToString()
                  Rol = Session("Rol").ToString()
                  Rol = Session("Cargo").ToString()
               Else
                  Session("Usuario") = ""
                  Session("Rol") = ""
                  Session("Cargo") = ""
                  Me.usuario.Text = ""
                  Me.clave.Text = ""
               End If
            Catch ex As Exception
               If Usuario.Trim().Length > 1 Then
                  Session("Usuario") = ""
                  Session("Rol") = ""
                  Session("Cargo") = ""
                  Me.usuario.Text = ""
                  Me.clave.Text = ""
               End If
            End Try
         End If
      End If
   End Sub

   Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

      Dim usuario As String = Me.usuario.Text.Replace(";", "").Replace("--", "")
      Dim clave As String = Me.clave.Text.Replace(";", "").Replace("--", "")

      If ExisteLogin(usuario, clave) Then
         Session("Usuario") = obtenerUsuario(usuario, clave, "Usuario")
         Session("Rol") = obtenerUsuario(usuario, clave, "Rol")
         Session("Cargo") = obtenerUsuario(usuario, clave, "Cargo")
         Response.Redirect("~/Default.aspx")
      Else
         lblMensaje.Text = "Usuario/Contraseña incorrecta verifique por favor."
      End If

   End Sub

   Private Function ExisteLogin(ByVal sUsuario As String, ByVal sClave As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select [ID], [usuario], [ClaveO365], [Rol], [Cargo] FROM [General_31].[dbo].[Ficha_Usuarios] Where [Usuario] = '" + sUsuario + "' and [ClaveO365] = '" + sClave + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
      End Try
      Return bOK
   End Function

   Private Function obtenerUsuario(ByVal sUsuario As String, ByVal sClave As String, ByVal sCampo As String) As String
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "SELECT " + sCampo + " FROM [General_31].[dbo].[Ficha_Usuarios] Where [Usuario] = '" + sUsuario + "' and [ClaveO365] = '" + sClave + "'"
      Dim sValor As String = ""
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               sValor = drNP(0).ToString
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
      End Try
      Return sValor
   End Function

End Class