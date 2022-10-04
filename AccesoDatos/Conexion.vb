Imports System.Configuration
Imports System.Data.SqlClient

Namespace AccesoDatos
    Public Class Conexion
        Private Shared conexion As Conexion = Nothing

        Private Sub New()
        End Sub

        Public Shared Function getIntance() As Conexion
            If conexion Is Nothing Then conexion = New Conexion()
            Return conexion
        End Function

        Public Function ConexionBD() As SqlConnection
            Dim conexion As SqlConnection = New SqlConnection()
            conexion.ConnectionString = ConfigurationManager.AppSettings("GRL_31")
            Return conexion
        End Function
    End Class

End Namespace