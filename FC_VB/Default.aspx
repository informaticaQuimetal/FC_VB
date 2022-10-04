<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="FC_VB._Default" Debug="True" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        body {
            font-family: Verdana;
            font-size: 14px;
        }
        /* Accordion */
        .accordionHeader {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #2E4d7B;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        #master_content .accordionHeader a {
            color: #FFFFFF;
            background: none;
            text-decoration: none;
        }

            #master_content .accordionHeader a:hover {
                background: none;
                text-decoration: underline;
            }

        .accordionHeaderSelected {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

    <script>
        $('.search').chosen();
    </script>

    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40"
        TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">

        <Panes>

            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">

                <Header>
                    <span class="accordionLink">Informaci&oacute;n Cliente</span>
                </Header>

                <Content>

                    <div class="container-fluid mx-auto">

                        <section id="Identificaci&oacute;n Cliente" class="mx-auto">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group row text-left">
                                        <label for="lbl" class="col-sm-12">
                                            <h3>Informaci&oacute;n Cliente:</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbRut" class="col-sm-3">Rut</label>
                                        <asp:TextBox ID="tbRut" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlNegocio" class="col-sm-4">Negocio</label>
                                        <asp:DropDownList runat="server" ID="ddlNegocio" class="form-control col-sm-8" DataValueField="Id" DataTextField="Descripcion" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlPlazoExtFirmado" class="col-sm-4">Plazo Ext. Firmado</label>
                                        <asp:DropDownList runat="server" ID="ddlPlazoExtFirmado" class="form-control col-sm-8" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" ToolTip="Comercial">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbCardCode" class="col-sm-3">CardCode</label>
                                        <asp:TextBox ID="tbCardCode" runat="server" class="form-control col-sm-9" placeholder="..."></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbVendedor" class="col-sm-4">Vendedor</label>
                                        <asp:TextBox ID="tbVendedor" runat="server" class="form-control col-sm-8" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbSubido" class="col-sm-4">Subido al Ministerio de econom&iacute;a</label>
                                        <asp:TextBox ID="tbSubido" runat="server" class="form-control col-sm-8" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlCliente" class="col-sm-3">Cliente</label>
                                        <asp:DropDownList runat="server" ID="ddlCliente" class="form-control col-sm-9 search" DataValueField="CardCode" DataTextField="CardName" AutoPostBack="true" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlSegmento" class="col-sm-4">Segmento</label>
                                        <asp:DropDownList runat="server" ID="ddlSegmento" class="form-control col-sm-8" DataValueField="Id" DataTextField="Descripcion" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas" />
                                    </div>
                                </div>

                                <div class="form-group col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbDocCustodia" class="col-sm-12" style="text-decoration: underline">Documentos en custodia:</label>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbGiro" class="col-sm-3">Giro</label>
                                        <asp:TextBox ID="tbGiro" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbGrupoEmpresas" class="col-sm-4">Grupo Empresas</label>
                                        <asp:TextBox ID="tbGrupoEmpresas" runat="server" class="form-control col-sm-8" placeholder="..." Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlProtesto" class="col-sm-4">Protestos</label>
                                        <asp:DropDownList runat="server" ID="ddlProtesto" class="form-control col-sm-8" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbDireccion" class="col-sm-3">Direcci&oacute;n</label>
                                        <asp:TextBox ID="tbDireccion" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlAntiguedad" class="col-sm-4">Antiguedad</label>
                                        <asp:DropDownList runat="server" ID="ddlAntiguedad" class="form-control col-sm-8" DataValueField="Id" DataTextField="Descripcion" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" ToolTip="Comercial" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="ddlChequesAFecha" class="col-sm-4">Cheques a Fecha</label>
                                        <asp:DropDownList runat="server" ID="ddlChequesAFecha" class="form-control col-sm-8" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbComuna" class="col-sm-3">Comuna</label>
                                        <asp:TextBox ID="tbComuna" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbAñosCliente" class="col-sm-4">Años como Cliente</label>
                                        <asp:TextBox ID="tbAñosCliente" runat="server" class="form-control col-sm-8" Style="text-align: right; left: 0px; top: 0px; border-color: chartreuse; background-color: Azure" placeholder="0" Text="0" ToolTip="Comercial"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbAñosCliente" runat="server" TargetControlID="tbAñosCliente" FilterType="Numbers" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbOtros" class="col-sm-4">Otros</label>
                                        <asp:TextBox ID="tbOtros" runat="server" class="form-control col-sm-8" placeholder="..." Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbCiudad" class="col-sm-3">Ciudad</label>
                                        <asp:TextBox ID="tbCiudad" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbCondVta" class="col-sm-4">Condici&oacute;n de Venta</label>
                                        <asp:TextBox ID="tbCondVta" runat="server" class="form-control col-sm-8" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-md-6 col-lg-4"></div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbRegion" class="col-sm-3">Pa&iacute;s/Regi&oacute;n</label>
                                        <asp:TextBox ID="tbRegion" runat="server" class="form-control col-sm-9" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-4">
                                    <div class="form-group row">
                                        <label for="tbMonDeuda" class="col-sm-4">Moneda de la deuda Vigente </label>
                                        <asp:TextBox ID="tbMonDeuda" runat="server" class="form-control col-sm-8" placeholder="..." ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group col-md-6 col-lg-4">
                                    <table style="">
                                        <tbody>
                                            <tr>
                                                <td style="width: 33%;">
                                                    <asp:Button type="button" runat="server" ID="btnBuscar" class="btn btn-outline-primary" Text="Buscar" Visible="true"></asp:Button></td>
                                                <td style="width: 33%;">
                                                    <asp:Button type="button" runat="server" ID="btnRegistrar" Class="btn btn-outline-primary" Text="Registrar" Visible="false"></asp:Button></td>
                                                <td style="width: 33%;">
                                                    <asp:Button type="button" runat="server" ID="btnEliminar" Class="btn btn-outline-primary" Text="Eliminar" Visible="false"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-6 col-lg-4"></div>
                                <div class="col-md-6 col-lg-8">
                                    <asp:Label ID="lblinfo" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                </div>

                            </div>

                        </section>

                    </div>

                </Content>

            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">

                <Header>
                    <span class="accordionLink">Informaci&oacute;n Comercial</span>
                </Header>


                <Content>

                    <div class="container-fluid mx-auto">

                        <section id="Identificacion Comercial" class="mx-auto">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group row text-left">
                                        <label for="lbl" class="col-sm-12">
                                            <h3>Informaci&oacute;n Comercial:</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <%--<section id="InformacionComercial-Parcelas" class="mx-auto">--%>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="gvEspecias" class="col-sm-6">Car&aacute;cter&iacute;sticas Productivas</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:UpdatePanel ID="uplPanelParcelas" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-md-10">
                                                        <asp:GridView ID="GridViewEspecies" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="table table-bordered table-striped" HeaderStyle-CssClass="header" EmptyDataText="Sin registros" ToolTip="Comercial" />
                                                        <asp:ImageButton ID="AgregarEspecie" type="button" runat="server" BorderWidth="1" CommandName="BtnAgregar" ImageUrl="~/images/mas.png" />
                                                        <asp:Label ID="lblInfoEspecie" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Label ID="LblTotal" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                     </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                   <%-- </section>--%>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-12">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12"><h3>Otros Comentarios:</h3></label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-12">
                                    <div class="form-group row">
                                        <label for="tbPrincipalesClientes" class="col-sm-3">Principales Clientes</label>
                                        <asp:TextBox ID="tbPrincipalesClientes" runat="server"  class="form-control col-sm-9 textMax" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                
                            <div class="row">
                                <div class="col-md-6 col-lg-12">
                                    <div class="form-group row">
                                        <label for="tbOtrosDatosRelevantes" class="col-sm-3">Otros datos relevantes</label>
                                        <asp:TextBox ID="tbOtrosDatosRelevantes" runat="server" class="form-control col-sm-9 textMax" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-12">
                                    <div class="form-group row">
                                        <label for="tbOtrosContactosQuimetal" class="col-sm-3">Otros contactos en Quimetal</label>
                                        <asp:TextBox ID="tbOtrosContactosQuimetal" runat="server" class="form-control col-sm-9 textMax" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </section>

                    </div>

                </Content>

            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">

                <Header>
                    <span class="accordionLink">Informaci&oacute;n Financiera</span>
                </Header>

                <Content>

                    <div class="container-fluid mx-auto">

                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group row text-left">
                                    <label for="lbl" class="col-sm-12">
                                        <h3>Informaci&oacute;n Financiera:</h3>
                                    </label>
                                </div>
                            </div>

                            <div class="col-md-6" style="left: 0px; top: 0px">

                                <section id="InformacionFinanciera" class="mx-auto">

                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <div class="form-group row">
                                                <label for="lbSocios" class="col-sm-6">Socios y/o Due&ntilde;os</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <asp:UpdatePanel ID="uplPanelSocios" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-10">
                                                    <asp:GridView ID="GridViewSocios" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="table table-bordered table-striped" HeaderStyle-CssClass="header" EmptyDataText="Sin registros" ToolTip="Finanzas" />
                                                    <asp:ImageButton ID="AgregarSocio" type="button" runat="server" BorderWidth="1" CommandName="BtnAgregar" ImageUrl="~/images/mas.png" ToolTip="Finanzas" />
                                                    <asp:Label ID="lblInfoSocio" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </section>

                            </div>

                            <div class="col-md-6" style="left: 0px; top: 0px">

                                <section id="InformacionComercial-Ventas" class="mx-auto">

                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <div class="form-group row">
                                                <label for="gv>VentasUltimos12mes" class="col-sm-12">Ventas &uacute;ltimos 12 meses (millones de pesos) seg&uacute;n carpeta tributaria</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-10">
                                                    <asp:GridView ID="GridViewVentas" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="table table-bordered table-striped" HeaderStyle-CssClass="header" EmptyDataText="Sin registros" ToolTip="Finanzas" />
                                                    <asp:ImageButton ID="AgregarVenta" type="button" runat="server" BorderWidth="1" CommandName="BtnAgregar" ImageUrl="~/images/mas.png" />
                                                    <asp:Label ID="lblInfoVentas" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </section>

                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6" style="left: 0px; top: 0px">

                                <section id="InformacionComercial-Sociedades" class="mx-auto">

                                    <div class="row">
                                        <div class="col-md-12 text-center">
                                            <div class="form-group row">
                                                <label for="lbSociedades" class="col-sm-6">Sociedades</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-10">
                                                    <asp:GridView ID="GridViewSociedades" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="table table-bordered table-striped" HeaderStyle-CssClass="header" EmptyDataText="Sin registros" ToolTip="Finanzas" />
                                                    <asp:ImageButton ID="AgregarSociedades" type="button" runat="server" BorderWidth="1" CommandName="BtnAgregar" ImageUrl="~/images/mas.png" ToolTip="Finanzas" />
                                                    <asp:Label ID="lblInfoSociedades" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </section>

                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="container-fluid mx-auto">

                                <section id="InformacionComercial-Dicom" class="mx-auto">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label for="lbl" class="col-sm-12" style="text-decoration: underline">Descripci&oacute;n DICOM:</label>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label for="lbl" class="col-sm-12" style="text-decoration: underline">Deuda SBIF:</label>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbCalificador" class="col-sm-7">Calificador</label>
                                                <asp:TextBox ID="tbCalificador" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="ftbTotal" runat="server" FilterType="Numbers" TargetControlID="tbCalificador" />
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbMontoSistemaFinaciero" class="col-sm-7">Monto Sistema Finaciero (millones de pesos)</label>
                                                <asp:TextBox ID="tbMontoSistemaFinaciero" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteMontoSistemaFinaciero" runat="server" TargetControlID="tbMontoSistemaFinaciero" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>


                                    </div>

                                    <div class="row">

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="ddlProtestos" class="col-sm-7">Protestos</label>
                                                <asp:DropDownList runat="server" ID="ddlProtestos" class="form-control col-sm-5" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                                    <asp:ListItem Text="Si" />
                                                    <asp:ListItem Text="No" Selected="True" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbCreditosComerciales" class="col-sm-7">Cr&eacute;ditos Comerciales (millones de pesos)</label>
                                                <asp:TextBox ID="tbCreditosComerciales" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteCreditosComerciales" runat="server" TargetControlID="tbCreditosComerciales" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="ddlConsultasSeg6Mes" class="col-sm-7">Consultas de compañ&iacute;as de seguros en &uacute;ltimos 6 meses</label>
                                                <asp:DropDownList runat="server" ID="ddlConsultasSeg6Mes" class="form-control col-sm-5" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                                    <asp:ListItem Text="Si" />
                                                    <asp:ListItem Text="No" Selected="True" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbDeudaActivos" class="col-sm-7">Deuda/Activos (millones de pesos)</label>
                                                <asp:TextBox ID="tbDeudaActivos" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: lightyellow; background-color: seashell" placeholder="0.0" ReadOnly="true" ToolTip="Monto Sistema Finaciero + Créditos Comerciales / Monto Propiedades "></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteDeudaActivos" runat="server" TargetControlID="tbDeudaActivos" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbMontoPropiedades" class="col-sm-7">Monto Propiedades (millones de pesos)</label>
                                                <asp:TextBox ID="tbMontoPropiedades" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteMontoPropiedades" runat="server" TargetControlID="tbMontoPropiedades" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>

                                        <%--<div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbClasifRiesgo" class="col-sm-7">Clasificaci&oacute;n de Riesgo</label>
                                                <asp:TextBox ID="tbClasifRiesgo" runat="server" class="form-control col-sm-5" Style="text-align: left; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="..." ToolTip="Finanzas"></asp:TextBox>
                                            </div>
                                        </div>--%>

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="ddlClasifRiesgo" class="col-sm-7">Clasificaci&oacute;n de Riesgo</label>
                                                <asp:DropDownList runat="server" ID="ddlClasifRiesgo" class="form-control col-sm-5" DataValueField="Codigo" DataTextField="Valor" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbMontosProtestos" class="col-sm-7">Montos Protestos</label>
                                                <asp:TextBox ID="tbMontosProtestos" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="ftbMontosProtestos" runat="server" TargetControlID="tbMontosProtestos" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbObservacion" class="col-sm-7">Obsevaci&oacute;n</label>
                                                <asp:TextBox ID="tbObservacion" runat="server" class="form-control col-sm-5" Style="text-align: left; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="..." ToolTip="Finanzas"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="ddlCantidad" class="col-sm-7">Cantidad (>=10/<10)</label>
                                                <asp:DropDownList runat="server" ID="ddlCantidad" class="form-control col-sm-5" DataValueField="Code" DataTextField="Name" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6 col-lg-6">
                                            <div class="form-group row">
                                                <label for="tbCantidadPropiedades" class="col-sm-7">Cantidad Propiedades</label>
                                                <asp:TextBox ID="tbCantidadPropiedades" runat="server" class="form-control col-sm-5" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteCantidadPropiedades" runat="server" FilterType="Numbers" TargetControlID="tbCantidadPropiedades" />
                                            </div>
                                        </div>
                                    </div>

                                </section>

                            </div>

                        </div>

                    </div>


                </Content>

            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">

                <Header>
                    <span class="accordionLink">Acuerdos de plazo extendido</span>
                </Header>


                <Content>

                    <div class="container-fluid mx-auto">

                        <section id="Situacion_Representantes:" class="mx-auto">

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12">
                                            <h3>Acuerdos de plazo extendido:</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12" style="text-decoration: underline">Representante Legal A</label>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12" style="text-decoration: underline">Representante Legal B (necesario completar si por el lado del cliente deben firman dos apoderados)</label>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbNombreRepresentanteA" class="col-sm-5">Nombre Representante</label>
                                        <asp:TextBox ID="tbNombreRepresentanteA" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbNombreRepresentanteB" class="col-sm-5">Nombre Representante</label>
                                        <asp:TextBox ID="tbNombreRepresentanteB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbRutRepresentanteA" class="col-sm-5">Rut Representante</label>
                                        <asp:TextBox ID="tbRutRepresentanteA" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbRutRepresentanteA" runat="server" TargetControlID="tbRutRepresentanteA" FilterType="Custom, Numbers" ValidChars=".-K" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbRutRepresentanteB" class="col-sm-5">Rut Representante</label>
                                        <asp:TextBox ID="tbRutRepresentanteB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbRutRepresentanteB" runat="server" TargetControlID="tbRutRepresentanteB" FilterType="Custom, Numbers" ValidChars=".-K" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbDireccionA" class="col-sm-5">Direcci&oacute;n</label>
                                        <asp:TextBox ID="tbDireccionA" runat="server" class="form-control col-sm-7" Style="text-align: left; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbDireccionB" class="col-sm-5">Direcci&oacute;n</label>
                                        <asp:TextBox ID="tbDireccionB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbComunaA" class="col-sm-5">Comuna</label>
                                        <asp:TextBox ID="tbComunaA" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbComunaB" class="col-sm-5">Comuna</label>
                                        <asp:TextBox ID="tbComunaB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlNacionalidadA" class="col-sm-5">Nacionalidad</label>
                                        <asp:DropDownList runat="server" ID="ddlNacionalidadA" class="form-control col-sm-9 search" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" DataValueField="Codigo" DataTextField="Pais" AutoPostBack="false" ToolTip="Comercial" />
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlNacionalidadB" class="col-sm-5">Nacionalidad</label>
                                        <asp:DropDownList runat="server" ID="ddlNacionalidadB" class="form-control col-sm-9 search" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" DataValueField="Codigo" DataTextField="Pais" AutoPostBack="false" ToolTip="Comercial" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlEstadoCivilA" class="col-sm-5">Estado Civil</label>
                                        <asp:DropDownList runat="server" ID="ddlEstadoCivilA" class="form-control col-sm-9 search" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" DataValueField="Estado" DataTextField="Nombre" AutoPostBack="false" ToolTip="Comercial" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbEstadoCivilB" class="col-sm-5">Estado Civil</label>
                                        <asp:DropDownList runat="server" ID="ddlEstadoCivilB" class="form-control col-sm-9 search" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" DataValueField="Estado" DataTextField="Nombre" AutoPostBack="false" ToolTip="Comercial" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbProfesionA" class="col-sm-5">Profesi&oacute;n</label>
                                        <asp:TextBox ID="tbProfesionA" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbProfesionB" class="col-sm-5">Profesi&oacute;n</label>
                                        <asp:TextBox ID="tbProfesionB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbCorreoA" class="col-sm-5">Correo</label>
                                        <asp:TextBox ID="tbCorreoA" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbCorreoB" class="col-sm-5">Correo</label>
                                        <asp:TextBox ID="tbCorreoB" runat="server" class="form-control col-sm-7" Style="text-align: left; left: 0px; top: 0px; border-color: chartreuse; background-color: azure" placeholder="..." ToolTip="Comercial"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlRecibido" class="col-sm-5">Recibido</label>
                                        <asp:DropDownList runat="server" ID="ddlRecibido" class="form-control col-sm-7" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" ToolTip="Comercial">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlSubido" class="col-sm-5">Subido al Ministerio de econom&iacute;a</label>
                                        <asp:DropDownList runat="server" ID="ddlSubido" class="form-control col-sm-7" Style="left: 0px; top: 0px; border-color: chartreuse; background-color: azure" ToolTip="Comercial">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </section>

                    </div>

                </Content>

            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">

                <Header>
                    <span class="accordionLink">Situaci&oacute;n Facturaci&oacute;n Quimetal</span>
                </Header>

                <Content>

                    <div class="container-fluid mx-auto">

                        <section id="Situación_Facturación_Quimetal:" class="mx-auto">

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12">
                                            <h3>Situaci&oacute;n Facturaci&oacute;n Quimetal:</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12" style="text-decoration: underline">Situaci&oacute;n Actual</label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12" style="text-decoration: underline">Comportamiento Hist&oacute;rico</label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbDeudaTotal" class="col-sm-4">Deuda Total (miles de USD)</label>
                                        <asp:TextBox ID="tbDeudaTotal" runat="server" class="form-control col-sm-8" Style="text-align: right" placeholder="0.00" ReadOnly="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="fteDeudaTotal" runat="server" FilterType="Custom, Numbers" ValidChars=",." TargetControlID="tbDeudaTotal" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbVtasUlt3Temp" class="col-sm-5">Ventas &uacute;ltimas 3 temp. (miles de USD)</label>
                                        <asp:TextBox ID="tbVtasUlt3Temp" runat="server" class="form-control col-sm-7" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.00" ToolTip="Finanzas"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="fteVtasUlt3Temp" runat="server" TargetControlID="tbVtasUlt3Temp" FilterType="Custom, Numbers" ValidChars="." />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbDeudaVigente" class="col-sm-4">Deuda Vigente (miles de USD)</label>
                                        <asp:TextBox ID="tbDeudaVigente" runat="server" class="form-control col-sm-8" Style="text-align: right" placeholder="0.00" ReadOnly="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="fteDeudaVigente" runat="server" FilterType="Custom, Numbers" ValidChars=",." TargetControlID="tbDeudaVigente" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlProtestosCheques" class="col-sm-5">Protestos Cheques</label>
                                        <asp:DropDownList runat="server" ID="ddlProtestosCheques" class="form-control col-sm-7" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="tbDeudaVencida" class="col-sm-4">Deuda Vencida (miles de USD)</label>
                                        <asp:TextBox ID="tbDeudaVencida" runat="server" class="form-control col-sm-8" Style="text-align: right" placeholder="0.00" ReadOnly="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="fteDeudaVencida" runat="server" FilterType="Custom, Numbers" ValidChars=",." TargetControlID="tbDeudaVencida" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlProrrogasUlt3Temp" class="col-sm-5">Pr&oacute;rrogas &uacute;lt. 3 temporadas</label>
                                        <asp:DropDownList runat="server" ID="ddlProrrogasUlt3Temp" class="form-control col-sm-7" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group row">
                                        <label for="ddlSiniestros" class="col-sm-5">Siniestros</label>
                                        <asp:DropDownList runat="server" ID="ddlSiniestros" class="form-control col-sm-7" Style="left: 0px; top: 0px; border-color: gold; background-color: cornsilk" ToolTip="Finanzas">
                                            <asp:ListItem Text="Si" />
                                            <asp:ListItem Text="No" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </section>

                    </div>

                </Content>

            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">

                <Header>
                    <span class="accordionLink">Evaluaci&oacute;n</span>
                </Header>

                <Content>

                    <div class="container-fluid mx-auto">

                        <section id="Evaluacion" class="mx-auto">

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl" class="col-sm-12">
                                            <h3>Evaluaci&oacute;n:</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl_1" class="col-sm-12" style="text-decoration: underline">Evaluaci&oacute;n</label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label for="lbl_2" class="col-sm-12" style="text-decoration: underline">Acuerdos</label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbEvaluacion" class="col-sm-6">Fecha actualizaci&oacute;n informaci&oacute;n</label>
                                                <asp:TextBox ID="tbEvaluacion" runat="server" class="form-control col-sm-6" Style="text-align: center" placeholder="dd/mm/yyyy" ReadOnly="true"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalEvaluacion" runat="server" Format="dd/MM/yyyy" TargetControlID="tbEvaluacion" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbCoberturaContinental" class="col-sm-6">Cobertura Continental Actual (miles de USD)</label>
                                                <asp:TextBox ID="tbCoberturaContinental" runat="server" class="form-control col-sm-6" Style="text-align: right" placeholder="0.00" ReadOnly="true" Text="0"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbVentasPlanificadas" class="col-sm-6">Ventas planificadas mas IVA (miles de USD)</label>
                                                <asp:TextBox ID="tbVentasPlanificadas" runat="server" class="form-control col-sm-6" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0.00" Text="0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteVentasPlanificadas" runat="server" FilterType="Custom, Numbers" ValidChars="." TargetControlID="tbVentasPlanificadas" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbMaxExpo" class="col-sm-6">M&aacute;xima exposici&oacute;n (miles de USD)</label>
                                                <asp:TextBox ID="tbMaxExpo" runat="server" class="form-control col-sm-6" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: aquamarine" placeholder="0.00" Text="0" ToolTip="GCOM" ReadOnly="true"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="ftbMaxExpo" runat="server" FilterType="Custom, Numbers" ValidChars="." TargetControlID="tbMaxExpo" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbRiesgoPropioQuimetal" class="col-sm-6">Riesgo Propio Quimetal necesario (miles de USD)</label>
                                                <asp:TextBox ID="tbRiesgoPropioQuimetal" runat="server" class="form-control col-sm-6" Style="text-align: right; left: 0px; top: 0px; border-color: lightyellow; background-color: seashell" placeholder="0.00" ReadOnly="true" Text="0,0" ToolTip="M&aacute;xima exposici&oacute;n - Cobertura Continental Actual"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteRiesgoPropioQuimetal" runat="server" FilterType="Custom, Numbers" ValidChars=",.-" TargetControlID="tbRiesgoPropioQuimetal" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div style="bottom: unset" class="form-group row">
                                                <label for="tbProxEvaluacion" class="col-sm-6">Fecha Pr&oacute;xima Evaluaci&oacute;n</label>
                                                <asp:TextBox ID="tbProxEvaluacion" runat="server" class="form-control col-sm-6" Style="text-align: center; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="dd/mm/yyyy" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalProxEvaluacion" runat="server" Format="dd/MM/yyyy" TargetControlID="tbProxEvaluacion" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label for="tbCantSolContinental" class="col-sm-6">Cantidad Solicitudes a Continental</label>
                                                <asp:TextBox ID="tbCantSolContinental" runat="server" class="form-control col-sm-6" Style="text-align: right; left: 0px; top: 0px; border-color: gold; background-color: cornsilk" placeholder="0" ToolTip="Finanzas"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="fteCantSolContinental" runat="server" FilterType="Numbers" TargetControlID="tbCantSolContinental" />
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-6" style="left: 0px; top: 0px">

                                    <section id="InformacionComercial-Acuerdos" class="mx-auto">

                                        <div class="row">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-md-10">
                                                        <asp:GridView ID="GridViewAcuerdos" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="table table-bordered table-striped" HeaderStyle-CssClass="header" EmptyDataText="Sin registros" ToolTip="Finanzas" />
                                                        <asp:ImageButton ID="AgregarAcuerdos" type="button" runat="server" BorderWidth="1" CommandName="BtnAcuerdos" ImageUrl="~/images/mas.png" />
                                                        <asp:Label ID="lblInfoAcuerdos" runat="server" Text=" " BackColor="#F5FFFA" ForeColor="#333333"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </section>

                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12 mt-1">
                                    <h6>.</h6>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12 mt-1">
                                    <h6>.</h6>
                                </div>
                            </div>

                        </section>
                    </div>

                </Content>

            </ajaxToolkit:AccordionPane>

        </Panes>

    </ajaxToolkit:Accordion>

</asp:Content>




