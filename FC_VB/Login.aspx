<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="FC_VB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Quimetal</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Login.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</head>
<body>
    <div class="sidenav">
        <asp:Image runat="server" ImageUrl="~/images/logo2.jpg"></asp:Image>
        <div class="login-main-text">
            <h1>Ficha Comercial de Clientes </h1>
            <h1>Quimetal Industrial S.A.</h1>
            <h5>(Versión 3.2)</h5>
        </div>
    </div>
    <div class="main">
        <div class="col-md-6 col-sm-12">
            <div class="login-form">
                <div class="card">
                    <div class="card-body">
                        <form id="form1" runat="server">
                            <div class="form-group">
                                <label for="usuario">Usuario</label>
                                <asp:TextBox ID="usuario" runat="server" class="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="pass">Clave</label>
                                <asp:TextBox ID="clave" runat="server" class="form-control" placeholder="Clave" type="password"></asp:TextBox>
                                <asp:Label ID="lblMensaje" runat="server" ForeColor="#996600"></asp:Label>
                            </div>
                            <asp:Button ID="Button1" runat="server" class="btn btn-info btn-block" Text="Login" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

