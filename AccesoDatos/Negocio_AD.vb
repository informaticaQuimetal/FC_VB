Imports Entidad
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace AccesoDatos

    Public Class Negocio_AD

        '#Region SINGLETON

        Private Shared dNegocios As Negocio_AD = Nothing

        Private Sub New()

        End Sub

        Public Shared Function getIntance() As Negocio_AD
            If dNegocios Is Nothing Then dNegocios = New Negocio_AD()
            Return dNegocios
        End Function

        '#EndRegion

        Public Function obtenerNegocios() As List(Of Negocio)
            Dim conexion As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim lstNegocio As List(Of Negocio) = New List(Of Negocio)()
            Dim sp As String = "Ficha_ObtenerNegocios"

            Try
                conexion = AccesoDatos.Conexion.getIntance().ConexionBD()
                cmd = New SqlCommand(sp, conexion)
                cmd.CommandType = CommandType.StoredProcedure
                'cmd.Parameters.AddWithValue("@CodSucursal", pCodSucursal)
                'cmd.Parameters.AddWithValue("@ID", pCodArea)
                'cmd.Parameters.AddWithValue("@Vista", pVista)
                conexion.Open()
                dr = cmd.ExecuteReader()
                While dr.Read()
                    Dim tmpNegocio As Negocio = New Negocio()
                    tmpNegocio.Id = Convert.ToInt32(dr("Id").ToString())
                    tmpNegocio.Descripcion = dr("Descripcion").ToString()
                    lstNegocio.Add(tmpNegocio)
                End While
                Return lstNegocio
            Catch ex As Exception
                Return Nothing
                Throw ex
            Finally
                conexion.Close()
            End Try
        End Function

    End Class

End Namespace
