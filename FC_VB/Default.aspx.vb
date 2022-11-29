Imports AjaxControlToolkit
Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Drawing
Imports System.Data.Common.CommandTrees.ExpressionBuilder
Imports System.Globalization
Imports System.IO

Public Class _Default
   Inherits Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

      If Session("Usuario") = "" Then
         Response.Redirect("~/Login.aspx")
      End If

      If Not IsPostBack Then
         LecturaEscritura(Session("Rol"), Session("Cargo"))
         Iniciarherramientas()
         Llenartablasmaestras()
         tbCardCode.Focus()
         Session("NuevoFichaSocio") = False
         Session("NuevoFichaEspecie") = False
         Session("NuevoFichaVentas") = False
         Session("NuevoFichaSociedades") = False
         Session("NuevoFichaAcuerdo") = False
      Else
         tbEvaluacion.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
         LabelWhiteOverGreen()
         If Session("NuevoFichaSocio") = True Then
            Grilla_Socios_Nuevo(ViewState("tmpFichaSocios"))
         Else
            Grilla_Socios_Llenado(tbCardCode.Text)
         End If
         If Session("NuevoFichaEspecie") = True Then
            Grilla_Especies_Nuevo(ViewState("tmpFichaEspecie"))
         Else
            Grilla_Especies_Llenado(tbCardCode.Text)
         End If
         If Session("NuevoFichaVenta") = True Then
            Grilla_Ventas_Nuevo(ViewState("tmpFichaVenta"))
         Else
            Grilla_Ventas_Llenado(tbCardCode.Text)
         End If
         If Session("NuevoFichaSociedades") = True Then
            Grilla_Sociedades_Nuevo(ViewState("tmpFichaSociedades"))
         Else
            Grilla_Sociedades_Llenado(tbCardCode.Text)
         End If

         If Session("NuevoFichaAcuerdo") = True Then
            Grilla_Acuerdos_Nuevo(ViewState("tmpFichaAcuerdo"))
         Else
            Grilla_Acuerdos_Llenado(tbCardCode.Text)
         End If
         'LblTotal.Text = CalculaTotalHectareas(tbCardCode.Text)

      End If
   End Sub

   Private Sub LecturaEscritura(ByVal sRol As String, ByVal sCargo As String)
      Dim strTipo As String
      Dim sBusca As String

      If sRol = "Admin" Then Exit Sub
      sBusca = "Finanzas"
      If sRol = "Finanzas" Then
         sBusca = "Comercial"
      End If

      'Se debe de habilitar el panel de acordión de ajax para que este código funcione
      For Each Cta In Page.Form.Controls ' (4).Controls 'recorre page
         For Each Ctb In Cta.Controls 'recorre forms
            For Each Ctc In Ctb.Controls 'recorre forms
               For Each Ctd In Ctc.Controls 'recorre forms
                  For Each Cte In Ctd.Controls 'recorre forms
                     strTipo = Cte.GetType.ToString
                     'Console.WriteLine(strTipo)
                     If TypeOf Cte Is TextBox Then
                        If CType(Cte, TextBox).ToolTip = sBusca Then
                           CType(Cte, TextBox).ReadOnly = True
                        End If
                        'Caso excepcional Alejandro Fernandez
                        If CType(Cte, TextBox).ToolTip = "GCOM" Then
                           If sCargo = "GCOM" Then
                              CType(Cte, TextBox).ReadOnly = False
                           End If
                        End If
                     ElseIf TypeOf Cte Is DropDownList Then
                        If CType(Cte, DropDownList).ToolTip = sBusca Then
                           CType(Cte, DropDownList).Enabled = False
                        End If
                     ElseIf TypeOf Cte Is ImageButton Then
                        If CType(Cte, ImageButton).ToolTip = sBusca Then
                           CType(Cte, ImageButton).Enabled = False
                        End If
                     ElseIf TypeOf Cte Is GridView Then
                        If CType(Cte, GridView).ToolTip = sBusca Then
                           CType(Cte, GridView).Enabled = False
                        End If
                     End If
                  Next
               Next
            Next
         Next
      Next

   End Sub

   Protected Overrides Sub InitializeCulture()
      Me.Culture = "en-US"
      Me.UICulture = "en-US"
      MyBase.InitializeCulture()
   End Sub

   Private Sub LabelWhiteOverGreen()
      Me.lblinfo.ForeColor = Color.White
      Me.lblinfo.BackColor = Color.Green
      Me.lblInfoSocio.ForeColor = Color.White
      Me.lblInfoSocio.BackColor = Color.Green
      Me.lblInfoEspecie.ForeColor = Color.White
      Me.lblInfoEspecie.BackColor = Color.Green
      Me.lblInfoVentas.ForeColor = Color.White
      Me.lblInfoVentas.BackColor = Color.Green
      Me.lblInfoSociedades.ForeColor = Color.White
      Me.lblInfoSociedades.BackColor = Color.Green
      Me.lblInfoAcuerdos.ForeColor = Color.White
      Me.lblInfoAcuerdos.BackColor = Color.Green
   End Sub

   Public Sub Llenartablasmaestras()
      'ddlNegocio.DataSource = GetTablaMaestra("Ficha_M_Negocio")
      ddlAntiguedad.DataSource = GetTablaMaestra("Ficha_M_Antiguedad")
      'ddlSegmento.DataSource = GetTablaMaestra("Ficha_M_Segmento")
      ddlCliente.DataSource = GetCliente()
      ddlEstadoCivilA.DataSource = GetEstadoCivil()
      ddlEstadoCivilB.DataSource = GetEstadoCivil()
      ddlNacionalidadA.DataSource = GetNacionalidad()
      ddlNacionalidadB.DataSource = GetNacionalidad()
      ddlCantidad.DataSource = GetCantidad()
      ddlClasifRiesgo.DataSource = GetClasificacionRiesgo()
      'ddlNegocio.DataBind()
      ddlAntiguedad.DataBind()
      'ddlSegmento.DataBind()
      ddlCliente.DataBind()
      ddlEstadoCivilA.DataBind()
      ddlEstadoCivilB.DataBind()
      ddlNacionalidadA.DataBind()
      ddlNacionalidadB.DataBind()
      ddlCantidad.DataBind()
      ddlClasifRiesgo.DataBind()

      'ddlPropiedadCampos.DataSource = GetTablaMaestra("Ficha_M_PropiedadCampos")
      'ddlPropiedadCampos.DataBind()

   End Sub

   Public Sub Iniciarherramientas()
      tbEvaluacion.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
      CalEvaluacion.SelectedDate = DateTime.Now
      CalEvaluacion.Enabled = False
      CalProxEvaluacion.SelectedDate = DateTime.Now
      If Session("Rol") = "Comercial" Then
         tbProxEvaluacion.Enabled = False
      End If
   End Sub

   Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged
      tbCardCode.Text = ddlCliente.SelectedValue
      BtnBuscar_Click(sender, e)
   End Sub

   Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

      Dim sCardCode As String = ""
      Dim sCliente As String = ""
      tbCardCode.Focus()

      Me.lblinfo.Text = ""
      btnRegistrar.Visible = False
      btnEliminar.Visible = False

      Limpiar()

      If tbCardCode.Text = "" Then

         Me.lblinfo.ForeColor = Color.White
         Me.lblinfo.BackColor = Color.Red
         Me.lblinfo.Text = "Favor indique el cardcode o el nombre del cliente... "

      Else

         If tbCardCode.Text <> "" Then

            If Right(tbCardCode.Text, 1) <> "C" And Right(tbCardCode.Text, 1) <> "X" Then
               Me.lblinfo.ForeColor = Color.White
               Me.lblinfo.BackColor = Color.Red
               Me.lblinfo.Text = "Recuerde que el cardcode debe terminar en C (de nacional) o X (de extranjero)..."
               Limpiar()
            Else
               sCardCode = tbCardCode.Text
               If Left(tbCardCode.Text, 1) <> "0" Then
                  sCardCode = "00" & tbCardCode.Text
               End If
               Limpiar()
               If Get_SN_SAP(sCardCode) = vbFalse Then
                  Me.lblinfo.ForeColor = Color.White
                  Me.lblinfo.BackColor = Color.Red
                  Me.lblinfo.Text = "Cliente no encontrado en SAP..."
               Else
                  'Cliente encontrado en SAP
                  If Get_SN_Ficha_Cliente(sCardCode) Then
                     Get_SN_Coberturas(sCardCode)
                     Get_SN_Ficha_Comercial(sCardCode)
                     Get_SN_Ficha_Dicom(sCardCode)
                     Get_SN_Ficha_SBIF(sCardCode)
                     Get_SN_Ficha_Situacion(sCardCode)
                     Get_SN_Ficha_Evaluacion(sCardCode)
                     Get_SN_Ficha_Representantes(sCardCode)
                     Grilla_Socios_Llenado(sCardCode)
                     Grilla_Especies_Llenado(sCardCode)
                     Grilla_Ventas_Llenado(sCardCode)
                     Grilla_Sociedades_Llenado(sCardCode)
                     Grilla_Acuerdos_Llenado(sCardCode)
                     If Session("Rol") = "Admin" Then
                        btnEliminar.Visible = True
                     End If
                     tbRiesgoPropioQuimetal.Text = (tbMaxExpo.Text - tbCoberturaContinental.Text).ToString("#.##")
                  Else
                     Me.lblinfo.ForeColor = Color.White
                     Me.lblinfo.BackColor = Color.Red
                     Me.lblinfo.Text = "Cliente encontrado en SAP, pero sin registro de Ficha Comercial..."
                  End If
                  If Session("Rol") <> "Invitado" Then btnRegistrar.Visible = True
                  LblTotal.Text = CalculaTotalHectareas(sCardCode)
               End If
            End If
         End If
      End If
   End Sub

   Private Sub Grilla_Socios_Llenado(ByVal sCardCode As String)
      GenerarEstructuraGrillaSocios()
      Dim tmpFichaSocios = GetSocios(sCardCode)
      GridViewSocios.DataSource = tmpFichaSocios
      ViewState("tmpFichaSocios") = tmpFichaSocios
      GridViewSocios.AutoGenerateColumns = False
      GridViewSocios.DataBind()
   End Sub

   Private Sub Grilla_Socios_Nuevo(ByVal tablasocio As List(Of TablaSocios))
      GenerarEstructuraGrillaSocios()
      GridViewSocios.DataSource = tablasocio
      ViewState("tmpFichaSocios") = tablasocio
      GridViewSocios.AutoGenerateColumns = False
      GridViewSocios.DataBind()
   End Sub

   Private Sub GenerarEstructuraGrillaSocios()

      GridViewSocios.Columns.Clear()
      GridViewSocios.DataSource = vbNullString
      GridViewSocios.AutoGenerateColumns = False
      GridViewSocios.DataKeyNames = New String() {"ID", "NombreSocio"}

      Dim btnEdit As ButtonField = New ButtonField()
      btnEdit.ButtonType = ButtonType.Image
      btnEdit.ImageUrl = "~/images/b_drop.png"
      btnEdit.Text = "Eliminar"
      btnEdit.CommandName = "RowKill"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Socios
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewSocios.Columns.Add(btnEdit)

      Dim btnSave As ButtonField = New ButtonField()
      btnSave.ButtonType = ButtonType.Image
      btnSave.ImageUrl = "~/images/edit.gif"
      btnSave.Text = "Guardar"
      btnSave.CommandName = "RowGuardar"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Socios
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnSave.Visible = False
      GridViewSocios.Columns.Add(btnSave)

      Dim ID As BoundField = New BoundField()
      ID.DataField = "ID"
      ID.HeaderText = "ID"
      ID.Visible = False
      GridViewSocios.Columns.Add(ID)

      Dim NombreSocio As BoundField = New BoundField()
      NombreSocio.HeaderText = "Socio"
      NombreSocio.DataField = "NombreSocio"
      GridViewSocios.Columns.Add(NombreSocio)

      Dim ddlDicom As BoundField = New BoundField()
      ddlDicom.HeaderText = "Problemas Dicom"
      ddlDicom.HeaderStyle.CssClass = "form-control text-center"
      ddlDicom.FooterStyle.CssClass = "form-control text-center"
      GridViewSocios.Columns.Add(ddlDicom)

      LimpiaInfos()

      GridViewSocios.DataBind()

   End Sub

   Protected Sub GridViewSocios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewSocios.RowCommand

      Try
         Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
         Dim Row As GridViewRow = GridViewSocios.Rows(rowIndex)

         If e.CommandName.Equals("RowGuardar") Then

            Dim ID = GridViewSocios.DataKeys(rowIndex)("ID").ToString()
            Dim sSocio = CType((GridViewSocios.Rows(rowIndex).FindControl("txtSocioNegocio" & ID)), TextBox).Text
            Dim sDicom = CType((GridViewSocios.Rows(rowIndex).FindControl("ddlDicom" & ID)), DropDownList).SelectedValue

            'Funcion Guardar
            If ID = 0 Then
               If New_Socio(tbCardCode.Text, ID, sSocio, sDicom) = True Then
                  Session("NuevoFichaSocio") = False
                  Grilla_Socios_Llenado(tbCardCode.Text)
                  Me.lblInfoSocio.Text = "Socio ingresado exitosamente..."
               End If
            Else
               Call Put_Socio(tbCardCode.Text, ID, sSocio, sDicom)
               Me.lblInfoSocio.Text = "Socio actualizado exitosamente..."
            End If

         ElseIf e.CommandName.Equals("RowKill") Then

            Dim ID = GridViewSocios.DataKeys(rowIndex)("ID").ToString()

            'Funcion Elimar
            Call Kill_Socio(tbCardCode.Text, ID)
            BtnBuscar_Click(sender, e)
            Me.lblInfoSocio.Text = "Socio eliminado exitosamente..."

         End If
      Catch ex As Exception
         PutErr("Mensaje: " & ex.Message & ". GridViewSocios_RowCommand", Session("Usuario"))
      End Try

   End Sub

   Private Sub GridViewSocios_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewSocios.RowDataBound

      If e.Row.RowType = DataControlRowType.DataRow Then

         Dim tmp = CType(ViewState("tmpFichaSocios"), List(Of TablaSocios))

         Dim tbSocioNegocio As TextBox = New TextBox()
         tbSocioNegocio.Attributes.Add("class", "form-control")
         tbSocioNegocio.AutoCompleteType = AutoCompleteType.Disabled
         tbSocioNegocio.MaxLength = 100
         tbSocioNegocio.ID = "txtSocioNegocio" & GridViewSocios.DataKeys(e.Row.RowIndex)("ID")

         If tmp.Count > 0 Then
            tbSocioNegocio.Text = tmp(e.Row.RowIndex).NombreSocio
         End If
         e.Row.Cells(3).Controls.Add(tbSocioNegocio)

         Dim drp As DropDownList = New DropDownList()
         drp.DataSource = GetSiNo()
         drp.DataTextField = "Valor"
         drp.DataValueField = "Codigo"
         drp.Attributes.Add("class", "form-control text-center")
         'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Socios
         If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then drp.Enabled = False
         drp.DataBind()

         drp.ID = "ddlDicom" & GridViewSocios.DataKeys(e.Row.RowIndex)("ID")
         If tmp.Count > 0 Then
            drp.SelectedValue = tmp(e.Row.RowIndex).Dicom
         Else
            drp.SelectedIndex = -1
         End If
         e.Row.Cells(4).Controls.Add(drp)
      End If

   End Sub

   Private Function New_Socio(ByVal sCardCode As String, ByVal sID As Int64, ByVal sSocio As String, ByVal sSino As String) As Boolean

      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Try
         sSql = "insert into [General_31].[dbo].[Ficha_Socios] ([CardCode], [NombreSocio], [Dicom]) Values " _
              & "('" & tbCardCode.Text & "', " _
                     & fCaracteres(sSocio) & ", " _
               & "'" & sSino & "')"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
         Return True
      Catch ex As Exception
         conn.Close()
         Me.lblinfo.Text = ex.Message
         PutErr("Mensaje: " & ex.Message & ". New_Socio", Session("Usuario"))
         Return False
      End Try

   End Function

   Private Sub Put_Socio(ByVal sCardCode As String, ByVal sID As Int64, ByVal sSocio As String, ByVal sSino As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "Update Ficha_Socios Set " _
                            & "NombreSocio = " & fCaracteres(sSocio) & ", " _
                            & "Dicom = '" & sSino & "' " _
                            & "where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         Me.lblinfo.Text = ex.Message
         PutErr("Mensaje: " & ex.Message & ". Put_Socio", Session("Usuario"))
      End Try
   End Sub

   Private Sub Kill_Socio(ByVal sCardCode As String, ByVal sID As Int64)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "delete from Ficha_Socios where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Kill_Socio", Session("Usuario"))
      End Try
   End Sub

   Protected Sub AgregarSocio_Click(sender As Object, e As ImageClickEventArgs) Handles AgregarSocio.Click
      If Session("Rol") = "Admin" Or Session("Rol") = "Finanzas" Then
         If tbCardCode.Text <> "" Then
            If Get_SN_Ficha_Cliente(tbCardCode.Text) Then
               'Insertar nuevo registro de Socio
               Dim TablaSocios As List(Of TablaSocios) = Nothing
               If ViewState("tmpFichaSocios") IsNot Nothing Then
                  TablaSocios = ViewState("tmpFichaSocios")
                  Dim c As TablaSocios = New TablaSocios()
                  c.ID = 0
                  c.NombreSocio = ""
                  c.Dicom = "N"
                  TablaSocios.Add(c)
                  Grilla_Socios_Nuevo(TablaSocios)
               Else
                  TablaSocios = New List(Of TablaSocios)()
                  Dim c As TablaSocios = New TablaSocios()
                  c.ID = 0
                  c.NombreSocio = ""
                  c.Dicom = "N"
                  TablaSocios.Add(c)
                  Grilla_Socios_Nuevo(TablaSocios)
               End If
               Session("NuevoFichaSocio") = True
            Else
               Me.lblInfoSocio.ForeColor = Color.White
               Me.lblInfoSocio.BackColor = Color.Red
               Me.lblInfoSocio.Text = "Cliente sin ficha comercial..."
            End If
         Else
            Me.lblInfoSocio.ForeColor = Color.White
            Me.lblInfoSocio.BackColor = Color.Red
            Me.lblInfoSocio.Text = "Identifique el Cliente... "
         End If
      Else
         Me.lblInfoSocio.ForeColor = Color.White
         Me.lblInfoSocio.BackColor = Color.Red
         Me.lblInfoSocio.Text = "Acceso denegado..."
      End If
   End Sub

   Public Shared Function GetSocios(ByVal sCardCode As String) As List(Of TablaSocios)
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select ID, NombreSocio, Dicom from Ficha_Socios where CardCode = '" + sCardCode + "' order by ID"
      Dim TablaSocios As List(Of TablaSocios) = New List(Of TablaSocios)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaSocios = New TablaSocios()
               c.ID = Convert.ToString(drNP("ID"))
               c.NombreSocio = Convert.ToString(drNP("NombreSocio"))
               c.Dicom = Convert.ToString(drNP("Dicom"))
               TablaSocios.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetSocios", "nn")
      End Try
      Return TablaSocios
   End Function

   Private Sub Grilla_Especies_Llenado(ByVal sCardCode As String)
      GenerarEstructuraGrillaEspecies()
      Dim tmpFichaEspecie = GetEspecie(sCardCode)
      GridViewEspecies.DataSource = tmpFichaEspecie
      ViewState("tmpFichaEspecie") = tmpFichaEspecie
      GridViewEspecies.AutoGenerateColumns = False
      GridViewEspecies.DataBind()
   End Sub

   Private Sub Grilla_Especies_Nuevo(ByVal tablaEspecie As List(Of TablaEspecies))
      GenerarEstructuraGrillaEspecies()
      GridViewEspecies.DataSource = tablaEspecie
      ViewState("tmpFichaEspecie") = tablaEspecie
      GridViewEspecies.AutoGenerateColumns = False
      GridViewEspecies.DataBind()
   End Sub

   Private Sub GenerarEstructuraGrillaEspecies()

      GridViewEspecies.Columns.Clear()
      GridViewEspecies.DataSource = vbNullString
      GridViewEspecies.AutoGenerateColumns = False
      GridViewEspecies.DataKeyNames = New String() {"ID", "EspecieCultivada"}

      Dim btnEdit As ButtonField = New ButtonField()
      btnEdit.ButtonType = ButtonType.Image
      btnEdit.ImageUrl = "~/images/b_drop.png"
      btnEdit.Text = "Eliminar"
      btnEdit.CommandName = "RowKill"
      'Si el rol es Comercial... finanzas no debe poder actualizar la grilla de Especies
      If Session("Rol") = "Finanzas" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewEspecies.Columns.Add(btnEdit)

      Dim btnSave As ButtonField = New ButtonField()
      btnSave.ButtonType = ButtonType.Image
      btnSave.ImageUrl = "~/images/edit.gif"
      btnSave.Text = "Guardar"
      btnSave.CommandName = "RowGuardar"
      'Si el rol es Comercial... finanzas no debe poder actualizar la grilla de Especies
      If Session("Rol") = "Finanzas" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewEspecies.Columns.Add(btnSave)

      Dim ID As BoundField = New BoundField()
      ID.DataField = "ID"
      ID.HeaderText = "ID"
      ID.Visible = False
      GridViewEspecies.Columns.Add(ID)

      Dim Parcela As BoundField = New BoundField()
      Parcela.HeaderText = "Parcela"
      Parcela.DataField = "Parcela"
      GridViewEspecies.Columns.Add(Parcela)

      Dim ddlEspecie As BoundField = New BoundField()
      ddlEspecie.HeaderText = "Especie"
      GridViewEspecies.Columns.Add(ddlEspecie)

      Dim CantidadHectareas As BoundField = New BoundField()
      CantidadHectareas.HeaderText = "Cantidad Hectareas"
      CantidadHectareas.DataField = "CantidadHectareas"
      GridViewEspecies.Columns.Add(CantidadHectareas)

      Dim Direccion As BoundField = New BoundField()
      Direccion.HeaderText = "Direccion"
      Direccion.DataField = "Direccion"
      GridViewEspecies.Columns.Add(Direccion)

      Dim GeoLocalizacion As BoundField = New BoundField()
      GeoLocalizacion.HeaderText = "GeoLocalizacion"
      GeoLocalizacion.DataField = "GeoLocalizacion"
      GridViewEspecies.Columns.Add(GeoLocalizacion)

      Dim ddlPropiedadCampos As BoundField = New BoundField()
      ddlPropiedadCampos.HeaderText = "Propiedad Campos"
      GridViewEspecies.Columns.Add(ddlPropiedadCampos)

      LimpiaInfos()

      GridViewEspecies.DataBind()

   End Sub

   Protected Sub GridViewEspecies_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewEspecies.RowCommand

      Try
         Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
         Dim Row As GridViewRow = GridViewEspecies.Rows(rowIndex)

         If e.CommandName.Equals("RowGuardar") Then

            Dim ID = GridViewEspecies.DataKeys(rowIndex)("ID").ToString()
            Dim sParcela = CType((GridViewEspecies.Rows(rowIndex).FindControl("txtParcela" & ID)), TextBox).Text
            Dim sEspecie = CType((GridViewEspecies.Rows(rowIndex).FindControl("ddlEspecie" & ID)), DropDownList).SelectedValue
            Dim sHectarea = CType((GridViewEspecies.Rows(rowIndex).FindControl("txtCantidadHectareas" & ID)), TextBox).Text
            Dim sDir = CType((GridViewEspecies.Rows(rowIndex).FindControl("txtDir" & ID)), TextBox).Text
            Dim sGeo = CType((GridViewEspecies.Rows(rowIndex).FindControl("txtGeo" & ID)), TextBox).Text
            Dim sPropiedadCampos = CType((GridViewEspecies.Rows(rowIndex).FindControl("ddlPropiedadCampos" & ID)), DropDownList).SelectedValue

            'Funcion Guardar
            If ID = 0 Then
               If New_Especie(tbCardCode.Text, ID, sParcela, sEspecie, sHectarea, sDir, sGeo, sPropiedadCampos) = True Then
                  Session("NuevoFichaEspecie") = False
                  Grilla_Especies_Llenado(tbCardCode.Text)
                  Me.LblTotal.Text = CalculaTotalHectareas(tbCardCode.Text)
                  Me.lblInfoEspecie.Text = "Especie ingresada exitosamente..."
               End If
            Else
               Call Put_Especie(tbCardCode.Text, ID, sParcela, sEspecie, sHectarea, sDir, sGeo, sPropiedadCampos)
               Me.LblTotal.Text = CalculaTotalHectareas(tbCardCode.Text)
               Me.lblInfoEspecie.Text = "Especie actualizada exitosamente..."
            End If

         ElseIf e.CommandName.Equals("RowKill") Then

            Dim ID = GridViewEspecies.DataKeys(rowIndex)("ID").ToString()

            'Funcion Elimar
            Call Kill_Especie(tbCardCode.Text, ID)
            Me.LblTotal.Text = CalculaTotalHectareas(tbCardCode.Text)
            BtnBuscar_Click(sender, e)
            Me.lblInfoEspecie.Text = "Especie eliminada exitosamente..."

         End If
      Catch ex As Exception
         PutErr("Mensaje: " & ex.Message & ". GridViewEspecies_RowCommand", Session("Usuario"))
      End Try

   End Sub

   Private Function CalculaTotalHectareas(ByVal sCardCode As String) As String
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select PropiedadCampos, IsNull(Sum(CantidadHectareas),0) Total from Ficha_Especies where CardCode = '" + sCardCode + "' Group By PropiedadCampos"
      Dim dValor As Decimal
      Dim sBanda As String = "Totales por Propiedad: "
      Dim sLinea As String = ""
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               dValor = drNP("Total")
               If Not IsDBNull(drNP("PropiedadCampos")) Then
                  sLinea = sLinea & drNP("PropiedadCampos").ToString & ": " & CStr(dValor) & ", "
               End If
            End If
         End While
         drNP.Close()
         conn.Close()
         If sLinea <> "" Then
            sBanda = sBanda & sLinea.Substring(0, Len(sLinea) - 3)
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". CalculaTotalHectareas", Session("Usuario"))
      End Try
      Return sBanda


   End Function

   Private Sub GridViewEspecies_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewEspecies.RowDataBound

      If e.Row.RowType = DataControlRowType.DataRow Then
         Dim tmp = CType(ViewState("tmpFichaEspecie"), List(Of TablaEspecies))

         Dim tbParcela As TextBox = New TextBox()
         tbParcela.Attributes.Add("class", "form-control")
         tbParcela.AutoCompleteType = AutoCompleteType.Disabled
         tbParcela.ID = "txtParcela" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")
         e.Row.Cells(3).Controls.Add(tbParcela)

         Dim ddlEspecie As DropDownList = New DropDownList()
         ddlEspecie.DataSource = GetCultivos()
         ddlEspecie.DataTextField = "Valor"
         ddlEspecie.DataValueField = "Codigo"
         ddlEspecie.Attributes.Add("class", "form-control")
         ddlEspecie.DataBind()

         ddlEspecie.ID = "ddlEspecie" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")
         If tmp.Count > 0 Then
            ddlEspecie.SelectedValue = tmp(e.Row.RowIndex).EspecieCultivada
         Else
            ddlEspecie.SelectedIndex = -1
         End If
         e.Row.Cells(4).Controls.Add(ddlEspecie)

         Dim tbCantidadHectareas As TextBox = New TextBox()
         tbCantidadHectareas.Attributes.Add("class", "form-control")
         tbCantidadHectareas.AutoCompleteType = AutoCompleteType.Disabled
         tbCantidadHectareas.CssClass = "form-control text-right"
         tbCantidadHectareas.ID = "txtCantidadHectareas" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")

         e.Row.Cells(5).Controls.Add(tbCantidadHectareas)

         If tmp.Count > 0 Then
            tbParcela.Text = tmp(e.Row.RowIndex).Parcela
            ddlEspecie.Text = tmp(e.Row.RowIndex).EspecieCultivada
            tbCantidadHectareas.Text = tmp(e.Row.RowIndex).CantidadHectareas
            'Si el rol es Comercial, Finanzas no debe poder actualizar la grilla de especies
            If Session("Rol") = "Finanzas" Or Session("Rol") = "Invitado" Then
               tbParcela.Enabled = False
               ddlEspecie.Enabled = False
               tbCantidadHectareas.Enabled = False
            End If
         End If

         Dim tbDir As TextBox = New TextBox()
         tbDir.Attributes.Add("class", "form-control")
         tbDir.MaxLength = 100
         tbDir.AutoCompleteType = AutoCompleteType.Disabled
         tbDir.ID = "txtDir" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")

         If tmp.Count > 0 Then
            tbDir.Text = tmp(e.Row.RowIndex).Direccion
         End If
         e.Row.Cells(6).Controls.Add(tbDir)

         Dim tbGeo As TextBox = New TextBox()
         tbGeo.Attributes.Add("class", "form-control")
         tbGeo.MaxLength = 50
         tbGeo.AutoCompleteType = AutoCompleteType.Disabled
         tbGeo.ID = "txtGeo" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")

         If tmp.Count > 0 Then
            tbGeo.Text = tmp(e.Row.RowIndex).GeoLocalizacion
         End If
         e.Row.Cells(7).Controls.Add(tbGeo)

         Dim ddlPropiedadCampos As DropDownList = New DropDownList()
         ddlPropiedadCampos.DataSource = GetPropiedadCampos() 'GetCultivos()
         ddlPropiedadCampos.DataTextField = "Valor"
         ddlPropiedadCampos.DataValueField = "Codigo"
         ddlPropiedadCampos.Attributes.Add("class", "form-control")
         ddlPropiedadCampos.DataBind()

         ddlPropiedadCampos.ID = "ddlPropiedadCampos" & GridViewEspecies.DataKeys(e.Row.RowIndex)("ID")
         If tmp.Count > 0 Then
            ddlPropiedadCampos.SelectedValue = tmp(e.Row.RowIndex).PropiedadCampos
         Else
            ddlPropiedadCampos.SelectedIndex = -1
         End If
         e.Row.Cells(8).Controls.Add(ddlPropiedadCampos)

      End If

   End Sub

   Private Function New_Especie(ByVal sCardCode As String, ByVal sID As Int64, ByVal sParcela As String, ByVal sEspecie As String, ByVal sHectarea As String, ByVal sDir As String, ByVal sGeo As String, ByVal sPropiedadCampos As String) As Boolean
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Try
         sSql = "insert into [General_31].[dbo].[Ficha_Especies] ([CardCode], [Parcela], [EspecieCultivada], [CantidadHectareas], [Direccion], [GeoLocalizacion], [PropiedadCampos]) Values (" _
              & "'" & tbCardCode.Text & "', " _
              & fCaracteres(sParcela) & ", " _
              & "'" & sEspecie & "', " _
              & sHectarea & ", " _
              & IIf(sDir = "", "Null", fCaracteres(sDir)) & ", " _
              & IIf(sGeo = "", "Null", fCaracteres(sGeo)) & ", " _
              & IIf(sPropiedadCampos = "", "Null", fCaracteres(sPropiedadCampos)) & ")"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
         Return True
      Catch ex As Exception
         conn.Close()
         Me.lblinfo.Text = ex.Message
         PutErr("Mensaje: " & ex.Message & ". New_Especie", Session("Usuario"))
         Return False
      End Try

   End Function

   Private Sub Put_Especie(ByVal sCardCode As String, ByVal sID As Int64, ByVal sParcela As String, ByVal sEspecie As String, ByVal sHectarea As String, ByVal sDir As String, ByVal sGeo As String, ByVal sPropiedadCampos As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "Update Ficha_Especies Set Parcela = " & fCaracteres(sParcela) & ", " _
                                             & "EspecieCultivada = '" & sEspecie & "', " _
                                             & "CantidadHectareas = " & sHectarea & ", " _
                                             & "Direccion = " & IIf(sDir = "", "Null", fCaracteres(sDir)) & ", " _
                                             & "GeoLocalizacion = " & IIf(sGeo = "", "Null", fCaracteres(sGeo)) & ", " _
                                             & "PropiedadCampos = " & IIf(sPropiedadCampos = "", "Null", fCaracteres(sPropiedadCampos)) & " " _
                            & "where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         Me.lblinfo.Text = ex.Message
         PutErr("Mensaje: " & ex.Message & ". Put_Especie", Session("Usuario"))
      End Try
   End Sub

   Private Function fCaracteres(ByRef Texto As String) As String
      Dim J As Long
      Dim Palabra, Caracter As String

      Palabra = "'"
      For J = 1 To Len(Texto)
         Caracter = Mid(Texto, J, 1)
         If Caracter = "'" Then
            Palabra = Palabra & Caracter & "'"
         Else
            Palabra = Palabra & Caracter
         End If
      Next J
      fCaracteres = Palabra & "'"
   End Function


   Private Sub Kill_Especie(ByVal sCardCode As String, ByVal sID As Int64)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "delete from Ficha_Especies where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Kill_Especie", Session("Usuario"))
         Me.lblinfo.Text = ex.Message

      End Try
   End Sub

   Protected Sub AgregarEspecie_Click(sender As Object, e As ImageClickEventArgs) Handles AgregarEspecie.Click
      If Session("Rol") = "Admin" Or Session("Rol") = "Comercial" Then
         If tbCardCode.Text <> "" Then
            If Get_SN_Ficha_Cliente(tbCardCode.Text) Then
               'Insertar nuevo registro de Especies
               Dim TablaEspecies As List(Of TablaEspecies) = Nothing
               If ViewState("tmpFichaEspecie") IsNot Nothing Then
                  TablaEspecies = ViewState("tmpFichaEspecie")
                  Dim c As TablaEspecies = New TablaEspecies()
                  c.ID = 0
                  c.Parcela = ""
                  c.EspecieCultivada = ""
                  c.CantidadHectareas = 0
                  c.Direccion = ""
                  c.GeoLocalizacion = ""
                  c.PropiedadCampos = ""
                  TablaEspecies.Add(c)
                  Grilla_Especies_Nuevo(TablaEspecies)
               Else
                  TablaEspecies = New List(Of TablaEspecies)()
                  Dim c As TablaEspecies = New TablaEspecies()
                  c.ID = 0
                  c.Parcela = ""
                  c.EspecieCultivada = ""
                  c.CantidadHectareas = 0
                  c.Direccion = ""
                  c.GeoLocalizacion = ""
                  c.PropiedadCampos = ""
                  TablaEspecies.Add(c)
                  Grilla_Especies_Nuevo(TablaEspecies)
               End If
               Session("NuevoFichaEspecie") = True
            Else
               Me.lblInfoEspecie.ForeColor = Color.White
               Me.lblInfoEspecie.BackColor = Color.Red
               Me.lblInfoEspecie.Text = "Cliente sin ficha comercial..."
            End If
         Else
            Me.lblInfoEspecie.ForeColor = Color.White
            Me.lblInfoEspecie.BackColor = Color.Red
            Me.lblInfoEspecie.Text = "Identifique el Cliente... "
         End If
      Else
         Me.lblInfoEspecie.ForeColor = Color.White
         Me.lblInfoEspecie.BackColor = Color.Red
         Me.lblInfoEspecie.Text = "Acceso denegado..."
      End If
   End Sub

   Public Shared Function GetEspecie(ByVal sCardCode As String) As List(Of TablaEspecies)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select ID, Parcela, EspecieCultivada, CantidadHectareas, Direccion, GeoLocalizacion, PropiedadCampos From Ficha_Especies where CardCode = '" + sCardCode + "' order by ID"
      Dim TablaEspecies As List(Of TablaEspecies) = New List(Of TablaEspecies)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaEspecies = New TablaEspecies()
               c.ID = Convert.ToString(drNP("ID"))
               c.Parcela = Convert.ToString(drNP("Parcela"))
               c.EspecieCultivada = Convert.ToString(drNP("EspecieCultivada"))
               c.CantidadHectareas = Convert.ToString(drNP("CantidadHectareas"))
               c.Direccion = Convert.ToString(drNP("Direccion"))
               c.GeoLocalizacion = Convert.ToString(drNP("GeoLocalizacion"))
               c.PropiedadCampos = Convert.ToString(drNP("PropiedadCampos"))
               TablaEspecies.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetEspecie", "nn")
      End Try

      Return TablaEspecies

   End Function

   Public Shared Sub PutErr(ByVal sMensaje As String, ByVal sUsuario As String)
      Dim path As String = "c:\temp\Log_errores.txt"
      sMensaje = sMensaje & ", " & Now().ToString & ", " & sUsuario

      If File.Exists(path) = False Then
         Using sw As StreamWriter = File.CreateText(path)
            sw.WriteLine(sMensaje)
         End Using
      Else
         Using sw As StreamWriter = File.AppendText(path)
            sw.WriteLine(sMensaje)
         End Using
      End If
   End Sub

   Private Sub Grilla_Ventas_Llenado(ByVal sCardCode As String)
      GenerarEstructuraGrillaVentas()
      Dim tmpFichaVenta = GetVenta(sCardCode)
      GridViewVentas.DataSource = tmpFichaVenta
      ViewState("tmpFichaVenta") = tmpFichaVenta
      GridViewVentas.AutoGenerateColumns = False
      GridViewVentas.DataBind()
   End Sub

   Private Sub Grilla_Ventas_Nuevo(ByVal tablaVenta As List(Of TablaVentas))
      GenerarEstructuraGrillaVentas()
      GridViewVentas.DataSource = tablaVenta
      ViewState("tmpFichaVenta") = tablaVenta
      GridViewVentas.AutoGenerateColumns = False
      GridViewVentas.DataBind()
   End Sub

   Private Sub GenerarEstructuraGrillaVentas()

      GridViewVentas.Columns.Clear()
      GridViewVentas.DataSource = vbNullString
      GridViewVentas.AutoGenerateColumns = False
      GridViewVentas.DataKeyNames = New String() {"ID", "Venta"}

      Dim btnEdit As ButtonField = New ButtonField()
      btnEdit.ButtonType = ButtonType.Image
      btnEdit.ImageUrl = "~/images/b_drop.png"
      btnEdit.Text = "Eliminar"
      btnEdit.CommandName = "RowKill"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Ventas
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewVentas.Columns.Add(btnEdit)

      Dim btnSave As ButtonField = New ButtonField()
      btnSave.ButtonType = ButtonType.Image
      btnSave.ImageUrl = "~/images/edit.gif"
      btnSave.Text = "Guardar"
      btnSave.CommandName = "RowGuardar"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Ventas
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewVentas.Columns.Add(btnSave)

      Dim ID As BoundField = New BoundField()
      ID.DataField = "ID"
      ID.HeaderText = "ID"
      ID.Visible = False
      GridViewVentas.Columns.Add(ID)

      Dim Venta As BoundField = New BoundField()
      Venta.HeaderText = "Venta"
      Venta.DataField = "Venta"
      'Venta.ItemStyle.CssClass = "colGrid"
      GridViewVentas.Columns.Add(Venta)

      Dim MontoML As BoundField = New BoundField()
      MontoML.HeaderText = "Monto"
      MontoML.DataField = "MontoML"
      MontoML.ItemStyle.CssClass = "#GridViewVentas"
      'MontoML.HeaderStyle.CssClass("")
      GridViewVentas.Columns.Add(MontoML)

      LimpiaInfos()

      GridViewVentas.DataBind()

   End Sub

   Protected Sub GridViewVentas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewVentas.RowCommand

      Try
         Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
         Dim Row As GridViewRow = GridViewVentas.Rows(rowIndex)

         If e.CommandName.Equals("RowGuardar") Then

            Dim ID = GridViewVentas.DataKeys(rowIndex)("ID").ToString()
            Dim sVenta = CType((GridViewVentas.Rows(rowIndex).FindControl("txtVenta" & ID)), TextBox).Text
            Dim sMonto = CType((GridViewVentas.Rows(rowIndex).FindControl("txtMontoML" & ID)), TextBox).Text

            'Funcion Guardar
            If ID = 0 Then
               If New_Venta(tbCardCode.Text, ID, sVenta, sMonto) = True Then
                  Session("NuevoFichaVenta") = False
                  Grilla_Ventas_Llenado(tbCardCode.Text)
                  Me.lblInfoVentas.Text = "Ventas ingresado exitosamente..."
               End If
            Else
               Call Put_Venta(tbCardCode.Text, ID, sVenta, sMonto)
               Me.lblInfoVentas.Text = "Ventas actualizado exitosamente..."
            End If

         ElseIf e.CommandName.Equals("RowKill") Then

            Dim ID = GridViewVentas.DataKeys(rowIndex)("ID").ToString()

            'Funcion Elimar
            Call Kill_Venta(tbCardCode.Text, ID)
            BtnBuscar_Click(sender, e)
            Me.lblInfoVentas.Text = "Ventas eliminado exitosamente..."

         End If
      Catch ex As Exception
         PutErr("Mensaje: " & ex.Message & ". GridViewVentas_RowCommand", Session("Usuario"))
      End Try

   End Sub

   Private Sub GridViewVentas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewVentas.RowDataBound

      If e.Row.RowType = DataControlRowType.DataRow Then

         Dim tmp = CType(ViewState("tmpFichaVenta"), List(Of TablaVentas))

         Dim tbVenta As TextBox = New TextBox()
         tbVenta.Attributes.Add("class", "form-control")
         tbVenta.AutoCompleteType = AutoCompleteType.Disabled
         tbVenta.ID = "txtVenta" & GridViewVentas.DataKeys(e.Row.RowIndex)("ID")

         Dim tbMontoML As TextBox = New TextBox()
         tbMontoML.Attributes.Add("class", "form-control")
         tbMontoML.AutoCompleteType = AutoCompleteType.Disabled
         tbMontoML.CssClass = "form-control text-right"
         tbMontoML.ID = "txtMontoML" & GridViewVentas.DataKeys(e.Row.RowIndex)("ID")

         If tmp.Count > 0 Then
            tbVenta.Text = tmp(e.Row.RowIndex).Venta
            tbMontoML.Text = tmp(e.Row.RowIndex).MontoML
            'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Socios
            If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then
               tbVenta.Enabled = False
               tbMontoML.Enabled = False
            End If
         End If
         e.Row.Cells(3).Controls.Add(tbVenta)
         e.Row.Cells(4).Controls.Add(tbMontoML)

      End If

   End Sub

   Private Function New_Venta(ByVal sCardCode As String, ByVal sID As Int64, ByVal sVenta As String, ByVal sMonto As Double) As Boolean

      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Try
         sSql = "insert into [General_31].[dbo].[Ficha_Ventas] ([CardCode], [Venta], [MontoML]) Values ('" & tbCardCode.Text & "'," & fCaracteres(sVenta) & ", " & sMonto & ")"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
         Return True
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". New_Venta", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
         Return False
      End Try

   End Function

   Private Sub Put_Venta(ByVal sCardCode As String, ByVal sID As Int64, ByVal sVenta As String, ByVal sMonto As Double)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "Update Ficha_Ventas Set Venta = " & fCaracteres(sVenta) & ", MontoML = " & sMonto & " where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Put_Venta", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Private Sub Kill_Venta(ByVal sCardCode As String, ByVal sID As Int64)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "delete from Ficha_Ventas where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Kill_Venta", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Protected Sub AgregarVenta_Click(sender As Object, e As ImageClickEventArgs) Handles AgregarVenta.Click
      If Session("Rol") = "Admin" Or Session("Rol") = "Finanzas" Then
         If tbCardCode.Text <> "" Then
            If Get_SN_Ficha_Cliente(tbCardCode.Text) Then
               'Insertar nuevo registro de Ventas
               Dim TablaVentas As List(Of TablaVentas) = Nothing
               If ViewState("tmpFichaVenta") IsNot Nothing Then
                  TablaVentas = ViewState("tmpFichaVenta")
                  Dim c As TablaVentas = New TablaVentas()
                  c.ID = 0
                  c.Venta = ""
                  c.MontoML = 0
                  TablaVentas.Add(c)
                  Grilla_Ventas_Nuevo(TablaVentas)
               Else
                  TablaVentas = New List(Of TablaVentas)()
                  Dim c As TablaVentas = New TablaVentas()
                  c.ID = 0
                  c.Venta = ""
                  c.MontoML = 0
                  TablaVentas.Add(c)
                  Grilla_Ventas_Nuevo(TablaVentas)
               End If
               Session("NuevoFichaVenta") = True
            Else
               Me.lblInfoVentas.ForeColor = Color.White
               Me.lblInfoVentas.BackColor = Color.Red
               Me.lblInfoVentas.Text = "Cliente sin ficha comercial..."
            End If
         Else
            Me.lblInfoVentas.ForeColor = Color.White
            Me.lblInfoVentas.BackColor = Color.Red
            Me.lblInfoVentas.Text = "Identifique el Cliente... "
         End If
      Else
         Me.lblInfoVentas.ForeColor = Color.White
         Me.lblInfoVentas.BackColor = Color.Red
         Me.lblInfoVentas.Text = "Acceso denegado..."
      End If
   End Sub

   Public Shared Function GetVenta(ByVal sCardCode As String) As List(Of TablaVentas)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select ID, Venta, MontoML from Ficha_Ventas where CardCode = '" + sCardCode + "' order by ID"
      Dim TablaVentas As List(Of TablaVentas) = New List(Of TablaVentas)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaVentas = New TablaVentas()
               c.ID = Convert.ToString(drNP("ID"))
               c.Venta = Convert.ToString(drNP("Venta"))
               c.MontoML = Convert.ToString(drNP("MontoML"))
               TablaVentas.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetVenta", "nn")
      End Try
      Return TablaVentas
   End Function

   Private Sub Grilla_Sociedades_Llenado(ByVal sCardCode As String)
      GenerarEstructuraGrillaSociedades()
      Dim tmpFichaSociedades = GetSociedad(sCardCode)
      GridViewSociedades.DataSource = tmpFichaSociedades
      ViewState("tmpFichaSociedades") = tmpFichaSociedades
      GridViewSociedades.AutoGenerateColumns = False
      GridViewSociedades.DataBind()
   End Sub

   Private Sub Grilla_Sociedades_Nuevo(ByVal TablaSociedades As List(Of TablaSociedades))
      GenerarEstructuraGrillaSociedades()
      GridViewSociedades.DataSource = TablaSociedades
      ViewState("tmpFichaSociedades") = TablaSociedades
      GridViewSociedades.AutoGenerateColumns = False
      GridViewSociedades.DataBind()
   End Sub

   Private Sub GenerarEstructuraGrillaSociedades()

      GridViewSociedades.Columns.Clear()
      GridViewSociedades.DataSource = vbNullString
      GridViewSociedades.AutoGenerateColumns = False
      GridViewSociedades.DataKeyNames = New String() {"ID", "Sociedad"}

      Dim btnEdit As ButtonField = New ButtonField()
      btnEdit.ButtonType = ButtonType.Image
      btnEdit.ImageUrl = "~/images/b_drop.png"
      btnEdit.Text = "Eliminar"
      btnEdit.CommandName = "RowKill"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Sociedades
      'btnEdit.Visible = True
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewSociedades.Columns.Add(btnEdit)

      Dim btnSave As ButtonField = New ButtonField()
      btnSave.ButtonType = ButtonType.Image
      btnSave.ImageUrl = "~/images/edit.gif"
      btnSave.Text = "Guardar"
      btnSave.CommandName = "RowGuardar"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Sociedades
      'btnSave.Visible = True
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewSociedades.Columns.Add(btnSave)

      Dim ID As BoundField = New BoundField()
      ID.DataField = "ID"
      ID.HeaderText = "ID"
      ID.Visible = False
      GridViewSociedades.Columns.Add(ID)

      Dim Sociedad As BoundField = New BoundField()
      Sociedad.HeaderText = "Sociedad"
      Sociedad.DataField = "Sociedad"
      'Sociedad.ItemStyle.CssClass = "colGrid"
      GridViewSociedades.Columns.Add(Sociedad)

      Dim ddlDicom As BoundField = New BoundField()
      ddlDicom.HeaderText = "Dicom"
      GridViewSociedades.Columns.Add(ddlDicom)

      LimpiaInfos()

      GridViewSociedades.DataBind()

   End Sub

   Protected Sub GridViewSociedades_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewSociedades.RowCommand

      Try

         Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
         Dim Row As GridViewRow = GridViewSociedades.Rows(rowIndex)

         If e.CommandName.Equals("RowGuardar") Then

            Dim ID = GridViewSociedades.DataKeys(rowIndex)("ID").ToString()
            Dim sSociedad = CType((GridViewSociedades.Rows(rowIndex).FindControl("txtSociedad" & ID)), TextBox).Text
            Dim sDicom = CType((GridViewSociedades.Rows(rowIndex).FindControl("ddlDicom" & ID)), DropDownList).SelectedValue

            'Funcion Guardar
            If ID = 0 Then
               If New_Sociedad(tbCardCode.Text, ID, sSociedad, sDicom) = True Then
                  Session("NuevoFichaSociedades") = False
                  Grilla_Sociedades_Llenado(tbCardCode.Text)
                  Me.lblInfoSociedades.Text = "Sociedad ingresada exitosamente..."
               End If
            Else
               Call Put_Sociedad(tbCardCode.Text, ID, sSociedad, sDicom)
               Me.lblInfoSociedades.Text = "Sociedad actualizada exitosamente..."
            End If

         ElseIf e.CommandName.Equals("RowKill") Then

            Dim ID = GridViewSociedades.DataKeys(rowIndex)("ID").ToString()

            'Funcion Elimar
            Call Kill_Sociedad(tbCardCode.Text, ID)
            BtnBuscar_Click(sender, e)
            Me.lblInfoSociedades.Text = "Sociedad eliminada exitosamente..."

         End If
      Catch ex As Exception
         PutErr("Mensaje: " & ex.Message & ". GridViewSociedades_RowCommand", Session("Usuario"))
      End Try

   End Sub

   Private Sub GridViewSociedades_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewSociedades.RowDataBound

      Dim sDicom As String = Nothing
      Dim sNombreSocio As String = Nothing

      If e.Row.RowType = DataControlRowType.DataRow Then

         Dim tmp = CType(ViewState("tmpFichaSociedades"), List(Of TablaSociedades))

         Dim tbSociedad As TextBox = New TextBox()
         tbSociedad.Attributes.Add("class", "form-control")
         tbSociedad.AutoCompleteType = AutoCompleteType.Disabled
         tbSociedad.ID = "txtSociedad" & GridViewSociedades.DataKeys(e.Row.RowIndex)("ID")

         If tmp.Count > 0 Then
            tbSociedad.Text = tmp(e.Row.RowIndex).Sociedad
         End If
         e.Row.Cells(3).Controls.Add(tbSociedad)

         Dim drp As DropDownList = New DropDownList()
         drp.DataSource = GetSiNo()
         drp.DataTextField = "Valor"
         drp.DataValueField = "Codigo"
         drp.Attributes.Add("class", "form-control")
         'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Sociedades
         If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then drp.Enabled = False
         drp.DataBind()

         drp.ID = "ddlDicom" & GridViewSociedades.DataKeys(e.Row.RowIndex)("ID")
         If tmp.Count > 0 Then
            drp.SelectedValue = tmp(e.Row.RowIndex).Dicom
         Else
            drp.SelectedIndex = -1
         End If
         e.Row.Cells(4).Controls.Add(drp)

      End If

   End Sub

   Private Function New_Sociedad(ByVal sCardCode As String, ByVal sID As Int64, ByVal sSociedad As String, ByVal sSino As String) As Boolean
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Try
         sSql = "insert into [General_31].[dbo].[Ficha_Sociedades] ([CardCode], [Sociedad], [Dicom]) Values ('" & tbCardCode.Text & "', " & fCaracteres(sSociedad) & ", '" & sSino & "')"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         Return True
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". New_Sociedad", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
         Return False
      End Try
   End Function

   Private Sub Put_Sociedad(ByVal sCardCode As String, ByVal sID As Int64, ByVal sSociedad As String, ByVal sSino As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "Update Ficha_Sociedades Set Sociedad = " & fCaracteres(sSociedad) & ", Dicom = '" & sSino & "' where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Put_Sociedad", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Private Sub Kill_Sociedad(ByVal sCardCode As String, ByVal sID As Int64)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "delete from Ficha_Sociedades where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Kill_Sociedad", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Protected Sub AgregarSociedades_Click(sender As Object, e As ImageClickEventArgs) Handles AgregarSociedades.Click
      If Session("Rol") = "Admin" Or Session("Rol") = "Finanzas" Then
         If tbCardCode.Text <> "" Then
            If Get_SN_Ficha_Cliente(tbCardCode.Text) Then

               'Insertar nuevo registro de Socio
               Dim TablaSociedades As List(Of TablaSociedades) = Nothing
               If ViewState("tmpFichaSociedades") IsNot Nothing Then
                  TablaSociedades = ViewState("tmpFichaSociedades")
                  Dim c As TablaSociedades = New TablaSociedades()
                  c.ID = 0
                  c.Sociedad = ""
                  c.Dicom = "N"
                  TablaSociedades.Add(c)
                  Grilla_Sociedades_Nuevo(TablaSociedades)
               Else
                  TablaSociedades = New List(Of TablaSociedades)()
                  Dim c As TablaSociedades = New TablaSociedades()
                  c.ID = 0
                  c.Sociedad = ""
                  c.Dicom = "N"
                  TablaSociedades.Add(c)
                  Grilla_Sociedades_Nuevo(TablaSociedades)
               End If
               Session("NuevoFichaSociedades") = True
            Else
               Me.lblInfoSociedades.ForeColor = Color.White
               Me.lblInfoSociedades.BackColor = Color.Red
               Me.lblInfoSociedades.Text = "Cliente sin ficha comercial..."
            End If
         Else
            Me.lblInfoSociedades.ForeColor = Color.White
            Me.lblInfoSociedades.BackColor = Color.Red
            Me.lblInfoSociedades.Text = "Identifique el Cliente... "
         End If
      Else
         Me.lblInfoSociedades.ForeColor = Color.White
         Me.lblInfoSociedades.BackColor = Color.Red
         Me.lblInfoSociedades.Text = "Acceso denegado..."
      End If
   End Sub

   Public Shared Function GetSociedad(ByVal sCardCode As String) As List(Of TablaSociedades)
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select ID, Sociedad, Dicom from Ficha_Sociedades where CardCode = '" + sCardCode + "' order by ID"
      Dim TablaSociedades As List(Of TablaSociedades) = New List(Of TablaSociedades)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaSociedades = New TablaSociedades()
               c.ID = Convert.ToString(drNP("ID"))
               c.Sociedad = Convert.ToString(drNP("Sociedad"))
               c.Dicom = Convert.ToString(drNP("Dicom"))
               TablaSociedades.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetSociedad", "nn")
      End Try
      Return TablaSociedades
   End Function

   Private Sub Grilla_Acuerdos_Llenado(ByVal sCardCode As String)
      GenerarEstructuraGrillaAcuerdos()
      Dim tmpFichaAcuerdo = GetAcuerdo(sCardCode)
      GridViewAcuerdos.DataSource = tmpFichaAcuerdo
      ViewState("tmpFichaAcuerdo") = tmpFichaAcuerdo
      GridViewAcuerdos.AutoGenerateColumns = False
      GridViewAcuerdos.DataBind()
   End Sub

   Private Sub Grilla_Acuerdos_Nuevo(ByVal tablaAcuerdo As List(Of TablaAcuerdos))
      GenerarEstructuraGrillaAcuerdos()
      GridViewAcuerdos.DataSource = tablaAcuerdo
      ViewState("tmpFichaAcuerdo") = tablaAcuerdo
      GridViewAcuerdos.AutoGenerateColumns = False
      GridViewAcuerdos.DataBind()
   End Sub

   Private Sub GenerarEstructuraGrillaAcuerdos()

      GridViewAcuerdos.Columns.Clear()
      GridViewAcuerdos.DataSource = vbNullString
      GridViewAcuerdos.AutoGenerateColumns = False
      GridViewAcuerdos.DataKeyNames = New String() {"ID", "Acuerdo"}

      Dim btnEdit As ButtonField = New ButtonField()
      btnEdit.ButtonType = ButtonType.Image
      btnEdit.ImageUrl = "~/images/b_drop.png"
      btnEdit.Text = "Eliminar"
      btnEdit.CommandName = "RowKill"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Acuerdos
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewAcuerdos.Columns.Add(btnEdit)

      Dim btnSave As ButtonField = New ButtonField()
      btnSave.ButtonType = ButtonType.Image
      btnSave.ImageUrl = "~/images/edit.gif"
      btnSave.Text = "Guardar"
      btnSave.CommandName = "RowGuardar"
      'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Acuerdos
      If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then btnEdit.Visible = False
      GridViewAcuerdos.Columns.Add(btnSave)

      Dim ID As BoundField = New BoundField()
      ID.DataField = "ID"
      ID.HeaderText = "ID"
      ID.Visible = False
      GridViewAcuerdos.Columns.Add(ID)

      Dim Acuerdo As BoundField = New BoundField()
      Acuerdo.HeaderText = "Acuerdo"
      Acuerdo.DataField = "Acuerdo"
      'Acuerdo.ItemStyle.CssClass = "colGrid"
      GridViewAcuerdos.Columns.Add(Acuerdo)

      Dim Fecha As BoundField = New BoundField()
      Fecha.HeaderText = "Fecha"
      Fecha.DataField = "Fecha"
      'Fecha.HeaderText = "dd/mm/aaaa"
      'Fecha.ApplyFormatInEditMode = True
      'Fecha.DataFormatString = "{0:d}"
      GridViewAcuerdos.Columns.Add(Fecha)

      LimpiaInfos()

      GridViewAcuerdos.DataBind()

   End Sub

   Protected Sub GridViewAcuerdos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewAcuerdos.RowCommand

      Try
         Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
         Dim Row As GridViewRow = GridViewAcuerdos.Rows(rowIndex)

         If e.CommandName.Equals("RowGuardar") Then

            Dim ID = GridViewAcuerdos.DataKeys(rowIndex)("ID").ToString()
            Dim sAcuerdo = CType((GridViewAcuerdos.Rows(rowIndex).FindControl("txtAcuerdo" & ID)), TextBox).Text
            Dim sFecha = CType((GridViewAcuerdos.Rows(rowIndex).FindControl("txtFecha" & ID)), TextBox).Text

            'Funcion Guardar
            If ID = 0 Then
               If New_Acuerdo(tbCardCode.Text, ID, sAcuerdo, sFecha) = True Then
                  Session("NuevoFichaAcuerdo") = False
                  Grilla_Acuerdos_Llenado(tbCardCode.Text)
                  Me.lblInfoAcuerdos.Text = "Acuerdos ingresado exitosamente..."
               End If
            Else
               Call Put_Acuerdo(tbCardCode.Text, ID, sAcuerdo, sFecha)
               Me.lblInfoAcuerdos.Text = "Acuerdos actualizado exitosamente..."
            End If

         ElseIf e.CommandName.Equals("RowKill") Then

            Dim ID = GridViewAcuerdos.DataKeys(rowIndex)("ID").ToString()

            'Funcion Elimar
            Call Kill_Acuerdo(tbCardCode.Text, ID)
            BtnBuscar_Click(sender, e)
            Me.lblInfoAcuerdos.Text = "Acuerdos eliminado exitosamente..."

         End If
      Catch ex As Exception
         PutErr("Mensaje: " & ex.Message & ". GridViewAcuerdos_RowCommand", Session("Usuario"))
      End Try

   End Sub

   Private Sub GridViewAcuerdos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewAcuerdos.RowDataBound

      'Dim sDicom As String = Nothing
      'Dim sNombreAcuerdo As String = Nothing

      If e.Row.RowType = DataControlRowType.DataRow Then

         Dim tmp = CType(ViewState("tmpFichaAcuerdo"), List(Of TablaAcuerdos))
         Dim tbAcuerdo As TextBox = New TextBox()

         tbAcuerdo.Attributes.Add("class", "form-control")
         tbAcuerdo.AutoCompleteType = AutoCompleteType.Disabled
         tbAcuerdo.ID = "txtAcuerdo" & GridViewAcuerdos.DataKeys(e.Row.RowIndex)("ID")

         Dim tbFecha As TextBox = New TextBox()
         tbFecha.Attributes.Add("class", "form-control")
         tbFecha.AutoCompleteType = AutoCompleteType.Disabled
         tbFecha.ID = "txtFecha" & GridViewAcuerdos.DataKeys(e.Row.RowIndex)("ID")

         'CalendarExtender birthdateCalendar = New CalendarExtender();
         'birthdateCalendar.ID = "calendarExtender" + Guid.NewGuid().ToString();
         'birthdateCalendar.TargetControlID = "editableTextBoxBirthday";

         Dim birthdateCalendar As CalendarExtender = New CalendarExtender()
         birthdateCalendar.ID = "calendarExtender" + GridViewAcuerdos.DataKeys(e.Row.RowIndex)("ID").ToString
         birthdateCalendar.TargetControlID = tbFecha.ID
         birthdateCalendar.Format = "dd/MM/yyyy"

         If tmp.Count > 0 Then
            tbAcuerdo.Text = tmp(e.Row.RowIndex).Acuerdo
            tbFecha.Text = tmp(e.Row.RowIndex).Fecha
            'Si el rol es finanzas, Comercial no debe poder actualizar la grilla de Socios
            If Session("Rol") = "Comercial" Or Session("Rol") = "Invitado" Then
               tbAcuerdo.Enabled = False
               tbFecha.Enabled = False
            End If
         End If
         e.Row.Cells(3).Controls.Add(tbAcuerdo)
         e.Row.Cells(4).Controls.Add(tbFecha)
         e.Row.Cells(4).Controls.Add(birthdateCalendar)
      End If

   End Sub

   Private Function New_Acuerdo(ByVal sCardCode As String, ByVal sID As Int64, ByVal sAcuerdo As String, ByVal sFecha As String) As Boolean

      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Try
         sSql = "insert into [General_31].[dbo].[Ficha_Acuerdos] ([CardCode], [Acuerdo], [Fecha]) Values ('" & tbCardCode.Text & "', " & fCaracteres(sAcuerdo) & ", Convert(Varchar(20),'" & sFecha & "',103))"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
         Return True
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". New_Acuerdo", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
         Return False
      End Try

   End Function

   Private Sub Put_Acuerdo(ByVal sCardCode As String, ByVal sID As Int64, ByVal sAcuerdo As String, ByVal sFecha As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "Update Ficha_Acuerdos Set Acuerdo = " & fCaracteres(sAcuerdo) & ", Fecha = Convert(Varchar(20),'" & sFecha & "',103) where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Put_Acuerdo", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Private Sub Kill_Acuerdo(ByVal sCardCode As String, ByVal sID As Int64)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         Dim sSql As String = "delete from Ficha_Acuerdos where CardCode = '" + sCardCode + "' and Id = " & sID
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Kill_Acuerdo", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Protected Sub AgregarAcuerdos_Click(sender As Object, e As ImageClickEventArgs) Handles AgregarAcuerdos.Click
      If Session("Rol") = "Admin" Or Session("Rol") = "Finanzas" Then
         If tbCardCode.Text <> "" Then
            If Get_SN_Ficha_Cliente(tbCardCode.Text) Then
               'Insertar nuevo registro de Acuerdos
               Dim TablaAcuerdos As List(Of TablaAcuerdos) = Nothing
               If ViewState("tmpFichaAcuerdo") IsNot Nothing Then
                  TablaAcuerdos = ViewState("tmpFichaAcuerdo")
                  Dim c As TablaAcuerdos = New TablaAcuerdos()
                  c.ID = 0
                  c.Acuerdo = ""
                  c.Fecha = ""
                  TablaAcuerdos.Add(c)
                  Grilla_Acuerdos_Nuevo(TablaAcuerdos)
               Else
                  TablaAcuerdos = New List(Of TablaAcuerdos)()
                  Dim c As TablaAcuerdos = New TablaAcuerdos()
                  c.ID = 0
                  c.Acuerdo = ""
                  c.Fecha = ""
                  TablaAcuerdos.Add(c)
                  Grilla_Acuerdos_Nuevo(TablaAcuerdos)
               End If
               Session("NuevoFichaAcuerdo") = True
            Else
               Me.lblInfoAcuerdos.ForeColor = Color.White
               Me.lblInfoAcuerdos.BackColor = Color.Red
               Me.lblInfoAcuerdos.Text = "Cliente sin ficha comercial..."
            End If
         Else
            Me.lblInfoAcuerdos.ForeColor = Color.White
            Me.lblInfoAcuerdos.BackColor = Color.Red
            Me.lblInfoAcuerdos.Text = "Identifique el Cliente... "
         End If
      Else
         Me.lblInfoAcuerdos.ForeColor = Color.White
         Me.lblInfoAcuerdos.BackColor = Color.Red
         Me.lblInfoAcuerdos.Text = "Acceso denegado..."
      End If
   End Sub

   Public Shared Function GetAcuerdo(ByVal sCardCode As String) As List(Of TablaAcuerdos)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select ID, Acuerdo, Convert(Varchar(20), Fecha, 103) Fecha from Ficha_Acuerdos where CardCode = '" + sCardCode + "' order by ID"
      Dim TablaAcuerdos As List(Of TablaAcuerdos) = New List(Of TablaAcuerdos)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaAcuerdos = New TablaAcuerdos()
               c.ID = Convert.ToString(drNP("ID"))
               c.Acuerdo = Convert.ToString(drNP("Acuerdo"))
               c.Fecha = Convert.ToString(drNP("Fecha"))
               TablaAcuerdos.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetAcuerdo", "nn")
      End Try
      Return TablaAcuerdos
   End Function

   Private Sub LimpiaInfos()
      Me.lblInfoSocio.Text = ""
      Me.lblInfoEspecie.Text = ""
      Me.lblInfoVentas.Text = ""
      Me.lblInfoSociedades.Text = ""
      Me.lblInfoAcuerdos.Text = ""
   End Sub

   Private Function Get_SN_SAP(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select T0.CardCode, T0.CardName, T0.LicTradNum Rut, T0.Notes Giro, T1.Street as Direccion, T1.City Ciudad, T1.County as Comuna , T2.Name as Estado, T3.name as País, T4.SlpName as Vendedor, T5.PymntGroup as CondPago, SBO_31.dbo.GetFC_MonFxC (T0.CardCode, '31/12/2008', Convert(varchar(10), GetDate(), 103)) As [Monedas], " _
                                   & "(select Descr from ufd1 where tableid ='OCRD' and fieldid = 34 and FldValue = u_segmento)  Segmento," _
                                   & "(Select Descr from ufd1 where tableid ='OCRD' and fieldid = 35 and FldValue = U_Categoria) Categoria " _
                         & "from OCRD T0 " _
                         & "inner join      CRD1 T1 On T0.CardCode = T1.CardCode And T0.BillToDef = T1.Address " _
                         & "left outer join OCST T2 On T1.State    = T2.Code     And T2.Country   = T1.Country " _
                         & "inner join      OCRY T3 On T1.Country  = T3.Code " _
                         & "inner join      OSLP T4 On T0.SlpCode  = T4.SlpCode " _
                         & "inner join      OCTG T5 On T0.GroupNum = T5.GroupNum " _
                         & "where T0.CardCode Like '%[CX]' and T1.AdresType = 'B'  and T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=SBO_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbCardCode.Text = drNP("CardCode").ToString
               ddlCliente.SelectedValue = drNP("CardCode").ToString
               tbRut.Text = drNP("Rut").ToString
               tbGiro.Text = drNP("Giro").ToString
               tbDireccion.Text = drNP("Direccion").ToString
               tbCiudad.Text = drNP("Ciudad").ToString
               tbComuna.Text = drNP("Comuna").ToString
               If Not drNP.IsDBNull(drNP.GetOrdinal("Estado")) Then
                  tbRegion.Text = drNP("Estado").ToString & "/" & drNP("País").ToString
               Else
                  tbRegion.Text = drNP("País").ToString
               End If
               tbVendedor.Text = drNP("Vendedor").ToString
               tbCondVta.Text = drNP("CondPago").ToString
               tbMonDeuda.Text = drNP("Monedas").ToString
               tbSegmento.text = drNP("Segmento").ToString
               tbCategoria.Text = drNP("Categoria").ToString
               Me.DataBind()
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_SAP", Session("Usuario"))
      End Try
      Return bOK

   End Function

   Private Function Get_SN_Coberturas(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "EXEC SegurosClientesCoberturasySaldos_FichaComercial '" & sCardCode & "', '', '', '','N'"
      Dim bOK As Boolean = vbFalse
      Dim dDeudaVencida As Decimal
      Dim dDeudaVigente As Decimal
      Dim dDeudaTotal As Decimal

      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=SBO_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               dDeudaTotal = drNP("Deuda Consolidada")
               tbDeudaTotal.Text = dDeudaTotal.ToString("#.##")
               dDeudaVencida = drNP("DeudaVencida").ToString
               tbDeudaVencida.Text = dDeudaVencida.ToString("#.##")
               dDeudaVigente = (Val(tbDeudaTotal.Text) - dDeudaVencida)
               If dDeudaVigente = 0 Then
                  tbDeudaVigente.Text = "0.00"
               Else
                  tbDeudaVigente.Text = dDeudaVigente.ToString("#.##")
               End If
               tbCoberturaContinental.Text = drNP("Seguro Continental").ToString
               Me.DataBind()
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Coberturas", Session("Usuario"))
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Cliente(ByVal sCardCode As String) As Boolean

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select [Rut], [CardCode], [Negocio], [Segmento], [GrupoEmpresas], [Antiguedad], [AñosCliente], [PlazoExtFirmado], [Protesto], [Cheque_Fecha], [Otros] from [General_31].[dbo].[Ficha_Cliente] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbRut.Text = drNP("Rut").ToString
               'ddlNegocio.SelectedValue = drNP("Negocio").ToString
               'ddlSegmento.SelectedValue = drNP("Segmento").ToString
               tbGrupoEmpresas.Text = drNP("GrupoEmpresas").ToString
               ddlAntiguedad.SelectedValue = drNP("Antiguedad").ToString
               tbAñosCliente.Text = drNP("AñosCliente").ToString
               ddlPlazoExtFirmado.SelectedValue = drNP("PlazoExtFirmado").ToString
               ddlProtesto.SelectedValue = drNP("Protesto").ToString
               ddlChequesAFecha.SelectedValue = drNP("Cheque_Fecha").ToString
               tbOtros.Text = drNP("Otros").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
         If bOK Then
            Me.lblinfo.Text = "Cliente encontrado en SAP y en Ficha Comercial..."
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Cliente", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Comercial(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader

      '[PropiedadCampos] desaparece y se fusiona en la grilla de socios

      Dim sSql As String = "select[PrincipalesClientes], [OtrosDatosRelevantes], [OtrosContactosEnQI] from [General_31].[dbo].[Ficha_Comercial] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               'ddlPropiedadCampos.SelectedValue = drNP("PropiedadCampos").ToString
               tbPrincipalesClientes.Text = drNP("PrincipalesClientes").ToString
               tbOtrosDatosRelevantes.Text = drNP("OtrosDatosRelevantes").ToString
               tbOtrosContactosQuimetal.Text = drNP("OtrosContactosEnQI").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
         If bOK Then
            Me.lblinfo.Text = "Cliente encontrado en SAP y en Ficha Comercial..."
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Comercial", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Dicom(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select [Calificador], [Protestos], [ConsultaSegUlt6mes], [MontoPropiedadesML], [MontoProtestos], [Cantidad10], [CantidadPropiedades] from [General_31].[dbo].[Ficha_DICOM] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbCalificador.Text = drNP("Calificador").ToString
               ddlProtestos.SelectedValue = drNP("Protestos").ToString
               ddlConsultasSeg6Mes.SelectedValue = drNP("ConsultaSegUlt6mes").ToString
               tbMontoPropiedades.Text = drNP("MontoPropiedadesML").ToString
               tbMontosProtestos.Text = drNP("MontoProtestos").ToString
               ddlCantidad.SelectedValue = drNP("Cantidad10").ToString
               tbCantidadPropiedades.Text = drNP("CantidadPropiedades").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
         If bOK Then
            'Me.lblinfo.Text = "Cliente encontrado en SAP y en Ficha Dicom..."
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Dicom", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_SBIF(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select [MontoSistFinancieroML], [CreditosComerciales], [ClasificacionRiesgo], [Observacion] from [General_31].[dbo].[Ficha_SBIF] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbMontoSistemaFinaciero.Text = drNP("MontoSistFinancieroML").ToString
               tbCreditosComerciales.Text = drNP("CreditosComerciales").ToString
               If tbMontoPropiedades.Text <> "" Then
                  If Val(tbMontoPropiedades.Text) > 0 Then
                     tbDeudaActivos.Text = ((Val(tbMontoSistemaFinaciero.Text) + Val(tbCreditosComerciales.Text)) / Val(tbMontoPropiedades.Text)).ToString("#.#")
                  End If
               End If
               ddlClasifRiesgo.SelectedValue = drNP("ClasificacionRiesgo").ToString
               tbObservacion.Text = drNP("Observacion").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_SBIF", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Situacion(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select [VentasUlt3Temp], [ProtestoCheques], [ProrrogasUlt3Temp], [Siniestros] from [General_31].[dbo].[Ficha_Situacion] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbVtasUlt3Temp.Text = drNP("VentasUlt3Temp").ToString
               ddlProtestosCheques.SelectedValue = drNP("ProtestoCheques").ToString
               ddlProrrogasUlt3Temp.SelectedValue = drNP("ProrrogasUlt3Temp").ToString
               ddlSiniestros.SelectedValue = drNP("Siniestros").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
         If bOK Then
            'Me.lblinfo.Text = "Cliente encontrado en SAP y en Ficha Dicom..."
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Situacion", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Evaluacion(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select Convert(varchar(20),[ActualizacionInfo],103) + ' ' + Convert(varchar(20),[ActualizacionInfo],108) as [ActualizacionInfo], [VentasPlanificadas], [MaximaExposicion], Convert(varchar(10),[ProximaEvaluacion],103) [ProximaEvaluacion], Convert(varchar(10),[ProximaEvaluacion],101) [Cal], [CantSolContinental] from [General_31].[dbo].[Ficha_Evaluacion] T0 where T0.CardCode = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbEvaluacion.Text = drNP("ActualizacionInfo").ToString
               tbVentasPlanificadas.Text = drNP("VentasPlanificadas").ToString
               tbMaxExpo.Text = drNP("MaximaExposicion").ToString
               tbProxEvaluacion.Text = drNP("ProximaEvaluacion").ToString
               CalProxEvaluacion.SelectedDate = DateTime.Parse(drNP("Cal").ToString)
               tbCantSolContinental.Text = drNP("CantSolContinental").ToString
            End If
         End While
         drNP.Close()
         conn.Close()
         If bOK Then
            'Me.lblinfo.Text = "Cliente encontrado en SAP y en Ficha Dicom..."
         End If
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Evaluacion", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Function Get_SN_Ficha_Representantes(ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select [CardCode], [A_Nombre], [B_Nombre], [A_Rut], [B_Rut], [A_Direccion], [B_Direccion], [A_Comuna], [B_Comuna], [A_Nacionalidad], [B_Nacionalidad], " _
                                            & "[A_EstadoCivil], [B_EstadoCivil], [A_Profesion], [B_Profesion], [A_Correo], [B_Correo], [Recibido], [Subido] " _
                         & "From [General_31].[dbo].[Ficha_Representantes] " _
                         & "Where [CardCode] = '" + sCardCode + "'"
      Dim bOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               bOK = vbTrue
               tbNombreRepresentanteA.Text = drNP("A_Nombre").ToString
               tbNombreRepresentanteB.Text = drNP("B_Nombre").ToString
               tbRutRepresentanteA.Text = drNP("A_Rut").ToString
               tbRutRepresentanteB.Text = drNP("B_RUt").ToString
               tbDireccionA.Text = drNP("A_Direccion").ToString
               tbDireccionB.Text = drNP("B_Direccion").ToString
               tbComunaA.Text = drNP("A_Comuna").ToString
               tbComunaB.Text = drNP("B_Comuna").ToString
               ddlNacionalidadA.SelectedValue = drNP("A_Nacionalidad").ToString
               ddlNacionalidadB.SelectedValue = drNP("B_Nacionalidad").ToString
               ddlEstadoCivilA.Text = drNP("A_EstadoCivil").ToString
               ddlEstadoCivilB.Text = drNP("B_EstadoCivil").ToString
               tbProfesionA.Text = drNP("A_Profesion").ToString
               tbProfesionB.Text = drNP("B_Profesion").ToString
               tbCorreoA.Text = drNP("A_Correo").ToString
               tbCorreoB.Text = drNP("B_Correo").ToString
               If Not IsDBNull(drNP("Recibido").ToString) And drNP("Recibido").ToString <> "" Then
                  ddlRecibido.SelectedValue = drNP("Recibido").ToString
               End If
               If Not IsDBNull(drNP("Subido").ToString) And drNP("Subido").ToString <> "" Then
                  ddlSubido.SelectedValue = drNP("Subido").ToString
                  tbSubido.Text = drNP("Subido").ToString
               End If
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". Get_SN_Ficha_Representantes", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return bOK
   End Function

   Private Sub RegistrarLog(ByVal sTabla As String, ByVal sCardCode As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String
      Dim sFicha As String
      Try
         sFicha = sTabla & "_Log"
         sSql = "Insert Into " & sFicha & " Select GetDate(), '" & Session("Usuario") & "', * From " & sTabla & " where CardCode = '" & sCardCode & "'"
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = sFicha & " del cliente ingresado exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". RegistrarLog", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
      Dim sSql As String

      If Session("Usuario") = "" Then

         Me.lblinfo.Text = "Sesión deshabilitada, favor cerrar sesión y volver a logearse, gracias."

      Else


         '& "Negocio = " & ddlNegocio.SelectedValue & ", "
         '& "Segmento = " & ddlSegmento.SelectedValue & ", " _
         '& "', " & ddlNegocio.SelectedValue
         '& ", " & ddlSegmento.SelectedValue _

         'Ficha Cliente
         If ExisteFicha("Ficha_Cliente", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Cliente] set " _
                     & "Rut = '" & tbRut.Text & "', " _
                     & "GrupoEmpresas = " & IIf(tbGrupoEmpresas.Text = "", "Null", fCaracteres(tbGrupoEmpresas.Text)) & ", " _
                     & "Antiguedad = " & ddlAntiguedad.SelectedValue & ", " _
                     & "AñosCliente = " & IIf(tbAñosCliente.Text = "", 0, tbAñosCliente.Text) & ", " _
                     & "PlazoExtFirmado = '" & ddlPlazoExtFirmado.SelectedValue & "', " _
                     & "Protesto = '" & ddlProtesto.SelectedValue & "', " _
                     & "Cheque_Fecha = '" & ddlChequesAFecha.SelectedValue & "', " _
                     & "Otros = " & IIf(tbOtros.Text = "", "Null", fCaracteres(tbOtros.Text)) & ", " _
                     & "UserU = '" & Session("Usuario") & "', " _
                     & "UserUDate = GetDate() " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            '[Negocio], [Segmento], 
            sSql = "insert into [General_31].[dbo].[Ficha_Cliente] " _
                  & "([Rut], [CardCode], [GrupoEmpresas], [Antiguedad], [AñosCliente], [PlazoExtFirmado], [Protesto], [Cheque_Fecha], [Otros], [UserA], [UserADate], [UserU], [UserUDate]) " _
                  & "Values ('" & tbRut.Text _
                  & "', '" & tbCardCode.Text _
                  & ", " & IIf(tbGrupoEmpresas.Text = "", "Null", fCaracteres(tbGrupoEmpresas.Text)) _
                  & ", " & ddlAntiguedad.SelectedValue _
                  & ", " & IIf(tbAñosCliente.Text = "", 0, tbAñosCliente.Text) _
                  & ", '" & ddlPlazoExtFirmado.SelectedValue _
                  & "', '" & ddlProtesto.SelectedValue _
                  & "', '" & ddlChequesAFecha.SelectedValue _
                  & "', " & IIf(tbOtros.Text = "", "Null", fCaracteres(tbOtros.Text)) _
                  & ", '" & Session("Usuario") & "', GetDate(),Null,Null)"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Cliente", tbCardCode.Text)

         'Ficha Comercial
         '& "PropiedadCampos = " & ddlPropiedadCampos.SelectedValue & ", " 
         If ExisteFicha("Ficha_Comercial", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Comercial] set " _
                     & "PrincipalesClientes = " & IIf(tbPrincipalesClientes.Text = "", "Null", fCaracteres(tbPrincipalesClientes.Text)) & ", " _
                     & "OtrosDatosRelevantes = " & IIf(tbOtrosDatosRelevantes.Text = "", "Null", fCaracteres(tbOtrosDatosRelevantes.Text)) & ", " _
                     & "OtrosContactosEnQI = " & IIf(tbOtrosContactosQuimetal.Text = "", "Null", fCaracteres(tbOtrosContactosQuimetal.Text)) & " " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            '[PropiedadCampos] desaparece y se fuiosna en la grilla de socios
            ''& ddlPropiedadCampos.SelectedValue & "', " 
            sSql = "insert into [General_31].[dbo].[Ficha_Comercial] " _
                  & "([CardCode], [PrincipalesClientes], [OtrosDatosRelevantes], [OtrosContactosEnQI]) " _
                  & "Values ('" & tbCardCode.Text & "', " _
                  & IIf(tbPrincipalesClientes.Text = "", "Null", fCaracteres(tbPrincipalesClientes.Text)) & ", " _
                  & IIf(tbOtrosDatosRelevantes.Text = "", "Null", fCaracteres(tbOtrosDatosRelevantes.Text)) & ", " _
                  & IIf(tbOtrosContactosQuimetal.Text = "", "Null", fCaracteres(tbOtrosContactosQuimetal.Text)) & ")"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Comercial", tbCardCode.Text)

         'Ficha Dicom
         If ExisteFicha("Ficha_Dicom", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Dicom] set " _
                     & "Calificador = " & IIf(tbCalificador.Text = "", 0, tbCalificador.Text) & ", " _
                     & "Protestos = '" & ddlProtestos.SelectedValue & "', " _
                     & "ConsultaSegUlt6mes = '" & ddlConsultasSeg6Mes.SelectedValue & "', " _
                     & "MontoPropiedadesML = " & IIf(tbMontoPropiedades.Text = "", 0, tbMontoPropiedades.Text) & ", " _
                     & "MontoProtestos = " & IIf(tbMontosProtestos.Text = "", 0, tbMontosProtestos.Text) & ", " _
                     & "Cantidad10 = " & IIf(ddlCantidad.SelectedValue = "", "Null", "'" & ddlCantidad.SelectedValue & "'") & ", " _
                     & "CantidadPropiedades = " & IIf(tbCantidadPropiedades.Text = "", 0, tbCantidadPropiedades.Text) & " " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            sSql = "insert into [General_31].[dbo].[Ficha_Dicom] " _
                  & "([CardCode], [Calificador], [Protestos], [ConsultaSegUlt6mes], [MontoPropiedadesML], [MontoProtestos], [Cantidad10], [CantidadPropiedades]) " _
                  & "Values ('" & tbCardCode.Text & "', " _
                  & IIf(tbCalificador.Text = "", 0, tbCalificador.Text) _
                  & ", '" & ddlProtestos.SelectedValue _
                  & "', '" & ddlConsultasSeg6Mes.SelectedValue _
                  & "', " & IIf(tbMontoPropiedades.Text = "", 0, tbMontoPropiedades.Text) _
                  & ", " & IIf(tbMontoPropiedades.Text = "", 0, tbMontoPropiedades.Text) _
                  & ", " & IIf(ddlCantidad.SelectedValue = "", "Null", "'" & ddlCantidad.SelectedValue & "'") _
                  & ", " & IIf(tbCantidadPropiedades.Text = "", 0, tbCantidadPropiedades.Text) & ")"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Dicom", tbCardCode.Text)

         'Ficha SBIF
         If ExisteFicha("Ficha_SBIF", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_SBIF] set " _
                     & "MontoSistFinancieroML = " & IIf(tbMontoSistemaFinaciero.Text = "", 0, tbMontoSistemaFinaciero.Text) & ", " _
                     & "CreditosComerciales = " & IIf(tbCreditosComerciales.Text = "", 0, tbCreditosComerciales.Text) & ", " _
                     & "ClasificacionRiesgo = " & IIf(ddlClasifRiesgo.SelectedValue = "", "Null", fCaracteres(ddlClasifRiesgo.SelectedValue)) & ", " _
                     & "Observacion = " & IIf(tbObservacion.Text = "", "Null", fCaracteres(tbObservacion.Text)) & " " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            sSql = "insert into [General_31].[dbo].[Ficha_SBIF] " _
                  & "([CardCode], [MontoSistFinancieroML], [CreditosComerciales] ,[ClasificacionRiesgo], [Observacion]) " _
                  & "Values ('" & tbCardCode.Text & "'" _
                  & ", " & IIf(tbMontoSistemaFinaciero.Text = "", 0, tbMontoSistemaFinaciero.Text) _
                  & ", " & IIf(tbCreditosComerciales.Text = "", 0, tbCreditosComerciales.Text) _
                  & ", " & IIf(ddlClasifRiesgo.SelectedValue = "", "Null", fCaracteres(ddlClasifRiesgo.SelectedValue)) _
                  & ", " & IIf(tbObservacion.Text = "", "Null", fCaracteres(tbObservacion.Text)) & ") "
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_SBIF", tbCardCode.Text)

         'Ficha Representantes
         If ExisteFicha("Ficha_Representantes", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Representantes] set " _
                     & "A_Nombre = " & IIf(tbNombreRepresentanteA.Text = "", "Null", fCaracteres(tbNombreRepresentanteA.Text)) & ", " _
                     & "B_Nombre = " & IIf(tbNombreRepresentanteB.Text = "", "Null", fCaracteres(tbNombreRepresentanteB.Text)) & ", " _
                     & "A_Rut = " & IIf(tbRutRepresentanteA.Text = "", "Null", "'" & tbRutRepresentanteA.Text & "'") & ", " _
                     & "B_Rut = " & IIf(tbRutRepresentanteB.Text = "", "Null", "'" & tbRutRepresentanteB.Text & "'") & ", " _
                     & "A_Direccion = " & IIf(tbDireccionA.Text = "", "Null", fCaracteres(tbDireccionA.Text)) & ", " _
                     & "B_Direccion = " & IIf(tbDireccionB.Text = "", "Null", fCaracteres(tbDireccionB.Text)) & ", " _
                     & "A_Comuna = " & IIf(tbComunaA.Text = "", "Null", fCaracteres(tbComunaA.Text)) & ", " _
                     & "B_Comuna = " & IIf(tbComunaB.Text = "", "Null", fCaracteres(tbComunaB.Text)) & ", " _
                     & "A_Nacionalidad = " & IIf(ddlNacionalidadA.SelectedValue = "", "Null", "'" & ddlNacionalidadA.SelectedValue & "'") & ", " _
                     & "B_Nacionalidad = " & IIf(ddlNacionalidadB.SelectedValue = "", "Null", "'" & ddlNacionalidadB.SelectedValue & "'") & ", " _
                     & "A_EstadoCivil = " & IIf(ddlEstadoCivilA.SelectedValue = "", "Null", "'" & ddlEstadoCivilA.SelectedValue & "'") & ", " _
                     & "B_EstadoCivil = " & IIf(ddlEstadoCivilB.SelectedValue = "", "Null", "'" & ddlEstadoCivilB.SelectedValue & "'") & ", " _
                     & "A_Profesion = " & IIf(tbProfesionA.Text = "", "Null", fCaracteres(tbProfesionA.Text)) & ", " _
                     & "B_Profesion = " & IIf(tbProfesionB.Text = "", "Null", fCaracteres(tbProfesionB.Text)) & ", " _
                     & "A_Correo = " & IIf(tbCorreoA.Text = "", "Null", "'" & tbCorreoA.Text & "'") & ", " _
                     & "B_Correo = " & IIf(tbCorreoB.Text = "", "Null", "'" & tbCorreoB.Text & "'") & ", " _
                     & "Recibido = " & IIf(ddlRecibido.SelectedValue = "", "Null", "'" & ddlRecibido.SelectedValue & "'") & ", " _
                     & "Subido = " & IIf(ddlSubido.SelectedValue = "", "Null", "'" & ddlSubido.SelectedValue & "'") & " " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            sSql = "insert into [General_31].[dbo].[Ficha_Representantes] " _
                  & "([CardCode], [A_Nombre], [B_Nombre], [A_Rut], [B_Rut], [A_Direccion], [B_Direccion], [A_Comuna], [B_Comuna], [A_Nacionalidad], [B_Nacionalidad], " _
                               & "[A_EstadoCivil], [B_EstadoCivil], [A_Profesion], [B_Profesion], [A_Correo], [B_Correo], [Recibido], [Subido]) " _
                  & "Values ('" & tbCardCode.Text & "', " _
                  & IIf(tbNombreRepresentanteA.Text = "", "Null", fCaracteres(tbNombreRepresentanteA.Text)) & ", " _
                  & IIf(tbNombreRepresentanteB.Text = "", "Null", fCaracteres(tbNombreRepresentanteB.Text)) & ", " _
                  & IIf(tbRutRepresentanteA.Text = "", "Null", "'" & tbRutRepresentanteA.Text & "'") & ", " _
                  & IIf(tbRutRepresentanteB.Text = "", "Null", "'" & tbRutRepresentanteB.Text & "'") & ", " _
                  & IIf(tbDireccionA.Text = "", "Null", fCaracteres(tbDireccionA.Text)) & ", " _
                  & IIf(tbDireccionB.Text = "", "Null", fCaracteres(tbDireccionB.Text)) & ", " _
                  & IIf(tbComunaA.Text = "", "Null", fCaracteres(tbComunaA.Text)) & ", " _
                  & IIf(tbComunaB.Text = "", "Null", fCaracteres(tbComunaB.Text)) & ", " _
                  & IIf(ddlNacionalidadA.SelectedValue = "", "Null", "'" & ddlNacionalidadA.SelectedValue & "'") & ", " _
                  & IIf(ddlNacionalidadB.SelectedValue = "", "Null", "'" & ddlNacionalidadB.SelectedValue & "'") & ", " _
                  & IIf(ddlEstadoCivilA.SelectedValue = "", "Null", "'" & ddlEstadoCivilA.SelectedValue & "'") & ", " _
                  & IIf(ddlEstadoCivilB.SelectedValue = "", "Null", "'" & ddlEstadoCivilB.SelectedValue & "'") & ", " _
                  & IIf(tbProfesionA.Text = "", "Null", fCaracteres(tbProfesionA.Text)) & ", " _
                  & IIf(tbProfesionB.Text = "", "Null", fCaracteres(tbProfesionB.Text)) & ", " _
                  & IIf(tbCorreoA.Text = "", "Null", "'" & tbCorreoA.Text & "'") & ", " _
                  & IIf(tbCorreoB.Text = "", "Null", "'" & tbCorreoB.Text & "'") & ", " _
                  & IIf(ddlRecibido.SelectedValue = "", "Null", "'" & ddlRecibido.SelectedValue & "'") & ", " _
                  & IIf(ddlSubido.SelectedValue = "", "Null", "'" & ddlSubido.SelectedValue & "'") & ")"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Representantes", tbCardCode.Text)

         'Ficha Situacion
         If ExisteFicha("Ficha_Situacion", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Situacion] set " _
                     & "VentasUlt3Temp = " & IIf(tbVtasUlt3Temp.Text = "", 0, tbVtasUlt3Temp.Text) & ", " _
                     & "ProtestoCheques = '" & ddlProtestosCheques.SelectedValue & "', " _
                     & "ProrrogasUlt3Temp = '" & ddlProrrogasUlt3Temp.SelectedValue & "', " _
                     & "Siniestros = '" & ddlSiniestros.SelectedValue & "' " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            sSql = "insert into [General_31].[dbo].[Ficha_Situacion] " _
                  & "([CardCode], [VentasUlt3Temp], [ProtestoCheques], [ProrrogasUlt3Temp], [Siniestros] ) " _
                  & "Values ('" & tbCardCode.Text & "'" _
                  & ", " & IIf(tbVtasUlt3Temp.Text = "", 0, tbVtasUlt3Temp.Text) _
                  & ", '" & ddlProtestosCheques.SelectedValue _
                  & "', '" & ddlProrrogasUlt3Temp.SelectedValue _
                  & "', '" & ddlSiniestros.SelectedValue & "')"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Situacion", tbCardCode.Text)

         'Ficha Evaluacion
         tbEvaluacion.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
         Dim sProxEval As Date = Date.ParseExact(tbProxEvaluacion.Text, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)

         If ExisteFicha("Ficha_Evaluacion", tbCardCode.Text) Then
            sSql = "update [General_31].[dbo].[Ficha_Evaluacion] set " _
                     & "ActualizacionInfo = Convert(DateTime,'" & tbEvaluacion.Text & "', 103), " _
                     & "VentasPlanificadas = " & IIf(tbVentasPlanificadas.Text = "", 0, tbVentasPlanificadas.Text) & ", " _
                     & "MaximaExposicion = " & IIf(tbMaxExpo.Text = "", 0, tbMaxExpo.Text) & ", " _
                     & "ProximaEvaluacion = convert(datetime,'" & sProxEval.ToString("dd/MM/yyyy") & "', 103), " _
                     & "CantSolContinental = " & IIf(tbCantSolContinental.Text = "", 0, tbCantSolContinental.Text) & " " _
             & "where  (CardCode  = '" & tbCardCode.Text & "')"
            ActualizaFicha(sSql)
         Else
            sSql = "insert into [General_31].[dbo].[Ficha_Evaluacion] " _
                  & "([CardCode], [ActualizacionInfo], [VentasPlanificadas], [MaximaExposicion], [ProximaEvaluacion], [CantSolContinental]) " _
                  & "Values ('" & tbCardCode.Text & "', " _
                  & "convert(datetime,'" & tbEvaluacion.Text & "', 103), " _
                  & IIf(tbVentasPlanificadas.Text = "", 0, tbVentasPlanificadas.Text) & ", " _
                  & IIf(tbMaxExpo.Text = "", 0, tbMaxExpo.Text) & ", " _
                  & "convert(datetime,'" & sProxEval.ToString("dd/MM/yyyy") & "', 103), " _
                  & IIf(tbCantSolContinental.Text = "", 0, tbCantSolContinental.Text) & ")"
            IngresaFicha(sSql)
         End If
         RegistrarLog("Ficha_Evaluacion", tbCardCode.Text)

         'Actualiza datos modificados y registrados en pantalla
         tbSubido.Text = ddlSubido.SelectedValue
         If tbMontoPropiedades.Text <> "" Then
            If Val(tbMontoPropiedades.Text) > 0 Then
               tbDeudaActivos.Text = ((Val(tbMontoSistemaFinaciero.Text) + Val(tbCreditosComerciales.Text)) / Val(tbMontoPropiedades.Text)).ToString("#.#")
            End If
         End If

      End If


   End Sub

   Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

      'Ficha Cliente
      If ExisteFicha("Ficha_Cliente", tbCardCode.Text) Then
         EliminaFicha("Ficha_Cliente", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha del cliente, imposible eliminar..."
      End If

      'Ficha Comercial
      If ExisteFicha("Ficha_Comercial", tbCardCode.Text) Then
         EliminaFicha("Ficha_Comercial", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha comercial del cliente, imposible eliminar..."
      End If

      'Ficha Dicom
      If ExisteFicha("Ficha_Dicom", tbCardCode.Text) Then
         EliminaFicha("Ficha_Dicom", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha dicom del cliente, imposible eliminar..."
      End If

      'Ficha SBIF
      If ExisteFicha("Ficha_SBIF", tbCardCode.Text) Then
         EliminaFicha("Ficha_SBIF", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha SBIF del cliente, imposible eliminar..."
      End If

      'Ficha Situacion
      If ExisteFicha("Ficha_Situacion", tbCardCode.Text) Then
         EliminaFicha("Ficha_Situacion", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha Situacion del cliente, imposible eliminar..."
      End If

      'Ficha Evaluacion
      If ExisteFicha("Ficha_Evaluacion", tbCardCode.Text) Then
         EliminaFicha("Ficha_Evaluacion", tbCardCode.Text)
      Else
         'Me.lblinfo.Text = "No encontrado en ficha Situacion del cliente, imposible eliminar..."
      End If

      'Ficha Representantes
      If ExisteFicha("Ficha_Representantes", tbCardCode.Text) Then
         EliminaFicha("Ficha_Representantes", tbCardCode.Text)
      End If

      'Ficha Socios
      If ExisteFicha("Ficha_Socios", tbCardCode.Text) Then
         EliminaFicha("Ficha_Socios", tbCardCode.Text)
      End If

      'Ficha Especie
      If ExisteFicha("Ficha_Especies", tbCardCode.Text) Then
         EliminaFicha("Ficha_Especies", tbCardCode.Text)
      End If

      'Ficha Ventas
      If ExisteFicha("Ficha_Ventas", tbCardCode.Text) Then
         EliminaFicha("Ficha_Ventas", tbCardCode.Text)
      End If

      'Ficha Sociedades
      If ExisteFicha("Ficha_Sociedades", tbCardCode.Text) Then
         EliminaFicha("Ficha_Sociedades", tbCardCode.Text)
      End If

      'Ficha Sociedades
      If ExisteFicha("Ficha_Acuerdos", tbCardCode.Text) Then
         EliminaFicha("Ficha_Acuerdos", tbCardCode.Text)
      End If

      Limpiar()
      GenerarEstructuraGrillaSocios()
      GenerarEstructuraGrillaEspecies()
      GenerarEstructuraGrillaVentas()
      GenerarEstructuraGrillaSociedades()
      GenerarEstructuraGrillaAcuerdos()

      Me.lblinfo.Text = "Cliente " & tbCardCode.Text & " eliminado exitosamente de la ficha comercial..."

   End Sub

   Private Function ExisteFicha(ByVal sTabla As String, ByVal sCardCode As String) As Boolean
      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select T0.cardcode from " & sTabla & " T0 where (T0.cardcode = '" & sCardCode & "')"
      Dim vbOK As Boolean = vbFalse
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         drNP.Read()
         If drNP.HasRows Then
            vbOK = vbTrue
         End If
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". ExisteFicha", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
      Return vbOK
   End Function

   Private Sub IngresaFicha(ByVal sSql As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         Me.lblinfo.Text = "Ficha comercial del cliente ingresada exitosamente..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". IngresaFicha", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Private Sub ActualizaFicha(ByVal sSql As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         Me.lblinfo.Text = "Cliente actualizado exitosamente de la ficha comercial..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". ActualizaFicha", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Private Sub EliminaFicha(ByVal sTabla As String, ByVal sCardCode As String)
      Dim conn As New SqlConnection
      Dim iInt As Integer
      Dim sSql As String = "delete from " & sTabla & " where (cardcode = '" & sCardCode & "')"
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         iInt = cmdNP.ExecuteNonQuery()
         conn.Close()
         'Me.lblinfo.Text = "Cliente " & sCardCode & " eliminado exitosamente de la " & sTabla & " ..."
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". EliminaFicha", Session("Usuario"))
         Me.lblinfo.Text = ex.Message
      End Try
   End Sub

   Public Shared Function GetCliente() As List(Of TablaOCRD)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select null as CardCode, null as CardName Union Select T0.CardCode, T0.CardName from OCRD T0 where T0.cardcode like '%[CX]' Select T0.CardCode, T0.CardName from OCRD T0 where T0.cardcode like '%[CX]' order by T0.CardName"
      Dim TablaOCRD As List(Of TablaOCRD) = New List(Of TablaOCRD)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=SBO_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaOCRD = New TablaOCRD()
               c.CardCode = Convert.ToString(drNP("CardCode"))
               c.CardName = Convert.ToString(drNP("CardName"))
               TablaOCRD.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetCliente", "nn")
      End Try
      Return TablaOCRD
   End Function

   Public Shared Function GetEstadoCivil() As List(Of TablaEstCivil)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select null as Estado, null as Nombre Union Select Estado, Nombre from General_31.dbo.Ficha_EstadoCivil order by Estado"
      Dim TablaEstCivil As List(Of TablaEstCivil) = New List(Of TablaEstCivil)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaEstCivil = New TablaEstCivil()
               c.Estado = Convert.ToString(drNP("Estado"))
               c.Nombre = Convert.ToString(drNP("Nombre"))
               TablaEstCivil.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetEstadoCivil", "nn")
      End Try
      Return TablaEstCivil
   End Function

   Public Shared Function GetNacionalidad() As List(Of TablaNacionalidad)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select Null as [Code] , Null as [Name] Union  SELECT T0.[Code], T0.[Name] FROM OCRY T0 order by Name"
      Dim TablaNacionalidad As List(Of TablaNacionalidad) = New List(Of TablaNacionalidad)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=SBO_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaNacionalidad = New TablaNacionalidad()
               c.Codigo = Convert.ToString(drNP("Name"))
               c.Pais = Convert.ToString(drNP("Name"))
               TablaNacionalidad.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetNacionalidad", "nn")
      End Try
      Return TablaNacionalidad
   End Function

   Public Shared Function GetCantidad() As List(Of TablaCantidad)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "Select Null as [Code] , Null as [Name] Union  SELECT T0.[Code], T0.[Name] FROM Ficha_Cantidad T0 "
      Dim TablaCantidad As List(Of TablaCantidad) = New List(Of TablaCantidad)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaCantidad = New TablaCantidad()
               c.Code = Convert.ToString(drNP("Code"))
               c.Name = Convert.ToString(drNP("Name"))
               TablaCantidad.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetCantidad", "nn")
      End Try
      Return TablaCantidad
   End Function

   Public Shared Function GetTablaMaestra(ByVal sTabla As String) As List(Of TablaMaestra)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select id, descripcion from " + sTabla + " where activo = 1 order by id"
      Dim TablaMaestra As List(Of TablaMaestra) = New List(Of TablaMaestra)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaMaestra = New TablaMaestra()
               c.Id = Convert.ToString(drNP("Id"))
               c.Descripcion = Convert.ToString(drNP("Descripcion"))
               TablaMaestra.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetTablaMaestra", "nn")
      End Try
      Return TablaMaestra
   End Function

   Public Shared Function GetSiNo() As List(Of TablaSiNo)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select 'S' Codigo, 'Si' Valor union  select 'N' Codigo, 'No' Valor "
      Dim TablaSiNo As List(Of TablaSiNo) = New List(Of TablaSiNo)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaSiNo = New TablaSiNo()
               c.Codigo = Convert.ToString(drNP("Codigo"))
               c.Valor = Convert.ToString(drNP("Valor"))
               TablaSiNo.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetSiNo", "nn")
      End Try
      Return TablaSiNo
   End Function

   Public Shared Function GetCultivos() As List(Of TablaCultivos)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select Codigo, Valor From Ficha_Cultivos Order By Codigo"
      Dim TablaCultivos As List(Of TablaCultivos) = New List(Of TablaCultivos)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaCultivos = New TablaCultivos()
               c.Codigo = Convert.ToString(drNP("Codigo"))
               c.Valor = Convert.ToString(drNP("Valor"))
               TablaCultivos.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetCultivos", "nn")
      End Try
      Return TablaCultivos
   End Function

   Public Shared Function GetPropiedadCampos() As List(Of TablaPropiedadCampos)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select Codigo, Valor From Ficha_PropiedadCampos Order By Codigo"
      Dim TablaPropiedadCampos As List(Of TablaPropiedadCampos) = New List(Of TablaPropiedadCampos)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaPropiedadCampos = New TablaPropiedadCampos()
               c.Codigo = Convert.ToString(drNP("Codigo"))
               c.Valor = Convert.ToString(drNP("Valor"))
               TablaPropiedadCampos.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetPropiedadCampos", "nn")
      End Try
      Return TablaPropiedadCampos
   End Function

   Public Shared Function GetClasificacionRiesgo() As List(Of TablaClasificacionRiesgo)

      Dim conn As New SqlConnection
      Dim drNP As SqlDataReader
      Dim sSql As String = "select Codigo, Valor From Ficha_ClasificacionRiesgo Order By Codigo"
      Dim TablaClasificacionRiesgo As List(Of TablaClasificacionRiesgo) = New List(Of TablaClasificacionRiesgo)()
      Try
         conn.ConnectionString = "Data Source=MARTE;Initial Catalog=General_31;Integrated Security=False;User ID=usersap;password=sapo1234"
         Dim cmdNP As New SqlCommand(sSql, conn)
         conn.Open()
         drNP = cmdNP.ExecuteReader()
         While drNP.Read
            If drNP.HasRows Then
               Dim c As TablaClasificacionRiesgo = New TablaClasificacionRiesgo()
               c.Codigo = Convert.ToString(drNP("Codigo"))
               c.Valor = Convert.ToString(drNP("Valor"))
               TablaClasificacionRiesgo.Add(c)
            End If
         End While
         drNP.Close()
         conn.Close()
      Catch ex As Exception
         conn.Close()
         PutErr("Mensaje: " & ex.Message & ". GetClasificacionRiesgo", "nn")
      End Try
      Return TablaClasificacionRiesgo
   End Function


   Private Sub Limpiar()

      'Seccion 1
      tbRut.Text = ""
      'ddlNegocio.SelectedValue = 1
      ddlPlazoExtFirmado.SelectedValue = "No"
      tbVendedor.Text = ""
      tbSubido.Text = ""
      'ddlSegmento.SelectedValue = 1
      tbGiro.Text = ""
      tbGrupoEmpresas.Text = ""
      ddlProtesto.SelectedValue = "No"
      tbDireccion.Text = ""
      ddlAntiguedad.SelectedValue = "1"
      ddlChequesAFecha.SelectedValue = "No"
      tbComuna.Text = ""
      tbAñosCliente.Text = "0"
      tbOtros.Text = ""
      tbCiudad.Text = ""
      tbCondVta.Text = ""
      tbRegion.Text = ""

      'Seccion 2
      LblTotal.Text = ""
      tbCalificador.Text = "0"
      ddlProtestos.SelectedValue = "No"
      tbPrincipalesClientes.Text = ""
      ddlConsultasSeg6Mes.SelectedValue = "No"
      tbOtrosDatosRelevantes.Text = ""
      tbMontoPropiedades.Text = "0"
      tbOtrosContactosQuimetal.Text = ""
      tbMontosProtestos.Text = "0"
      ddlCantidad.SelectedValue = ""
      tbCantidadPropiedades.Text = "0"
      tbMontoSistemaFinaciero.Text = "0"
      tbCreditosComerciales.Text = "0"
      tbDeudaActivos.Text = "0"
      ddlClasifRiesgo.SelectedValue = ""
      tbObservacion.Text = ""


      'Representantes
      tbNombreRepresentanteA.Text = ""
      tbNombreRepresentanteB.Text = ""
      tbRutRepresentanteA.Text = ""
      tbRutRepresentanteB.Text = ""
      tbDireccionA.Text = ""
      tbDireccionB.Text = ""
      tbComunaA.Text = ""
      tbComunaB.Text = ""
      ddlNacionalidadA.SelectedValue = "Chile"
      ddlNacionalidadB.SelectedValue = "Chile"
      ddlEstadoCivilA.SelectedValue = ""
      ddlEstadoCivilB.SelectedValue = ""
      tbProfesionA.Text = ""
      tbProfesionB.Text = ""
      tbCorreoA.Text = ""
      tbCorreoB.Text = ""
      ddlRecibido.SelectedValue = "No"
      ddlSubido.SelectedValue = "No"

      'Seccion 3
      tbDeudaTotal.Text = "0"
      tbVtasUlt3Temp.Text = "0"
      tbDeudaVigente.Text = "0"
      ddlProtestosCheques.SelectedValue = "No"
      tbDeudaVencida.Text = "0"
      ddlProrrogasUlt3Temp.SelectedValue = "No"
      ddlSiniestros.SelectedValue = "No"

      'Seccion 4
      tbEvaluacion.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
      tbCoberturaContinental.Text = "0"
      tbCantSolContinental.Text = "0"
      tbVentasPlanificadas.Text = "0"
      tbMaxExpo.Text = "0"
      tbRiesgoPropioQuimetal.Text = "0"
      'tbAcuerdos.Text = ""
      tbProxEvaluacion.Text = Date.Now

      Me.lblInfoSocio.Text = ""
      Me.lblInfoEspecie.Text = ""
      Me.lblInfoVentas.Text = ""
      Me.lblInfoSociedades.Text = ""

      DataBind()

   End Sub


End Class