<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaJogos.Site.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>Usuario:</div>
            <div>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <br />
            </div>
            <div>
                Senha:
            </div>
            <div>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Label runat="server" ID="lblStatus" ></asp:Label>
                <br />
                <asp:Button ID="btnlogin" Text="Entrar" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnlogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
