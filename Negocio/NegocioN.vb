Imports AccesoDatos
Imports Entidad
Imports System
Imports System.Collections.Generic

Namespace Negocios

   Public Class NegocioN

      Private Shared objAreaN As NegocioN = Nothing

      Private Sub New()
      End Sub

      Public Shared Function getIntance() As NegocioN
         If objAreaN Is Nothing Then objAreaN = New NegocioN()
         Return objAreaN
      End Function

      Public Function obtenerNegocios() As List(Of NegocioN)
         Try
            Return NegocioN.getIntance().obtenerNegocios()
         Catch ex As Exception
            Throw ex
         End Try
      End Function

   End Class
End Namespace
