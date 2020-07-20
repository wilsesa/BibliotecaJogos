<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogos.aspx.cs" Inherits="BibliotecaJogos.Site.Jogos.CadastroEdicaoJogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-group">
            <label for="formGroupExampleInput">Título</label>
            <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" Text=""></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RfvTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="È necessário preencher o campo Título" Text="*"></asp:RequiredFieldValidator>--%>
        </div>

        <div class="form-group">
            <label for="formGroupExampleInput">Valor Pago</label>
            <asp:TextBox runat="server" ID="txtValorPago" CssClass="form-control" TextMode="Number"></asp:TextBox>
            
        </div>

        <div class="form-group">
            <label for="formGroupExampleInput">Data Compra</label>
            <asp:TextBox runat="server" ID="txtDataCompra" TextMode="Date" CssClass="form-control"></asp:TextBox>
            
        </div>

        <div class="form-group">
            <label for="formGroupExampleInput">Imagem</label>
            <asp:FileUpload ID="FileUploadImage" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group">
            <label for="formGroupExampleInput">Género</label>
            <asp:DropDownList ID="DdlGenero" runat="server" DataValueField="Id" DataTextField="Descricao" CssClass="form-control"></asp:DropDownList>
            <%--<asp:RequiredFieldValidator ID="RfvGenero" runat="server" ControlToValidate="DdlGenero" ErrorMessage="È necessário preencher o campo Género" Text="*"></asp:RequiredFieldValidator>--%>
        </div>

        <div class="form-group">
            <label for="formGroupExampleInput">Editor</label>
            <asp:DropDownList ID="DdlEditor" runat="server" DataValueField="Id" DataTextField="Nome" CssClass="form-control"></asp:DropDownList>
            <%--<asp:RequiredFieldValidator ID="RfvEditor" runat="server" ControlToValidate="DdlEditor" ErrorMessage="È necessário preencher o campo Editor" Text="*"></asp:RequiredFieldValidator>--%>
        </div>

        <%--<asp:ValidationSumary
            id="valSum"
            DisplayMode="BulletList"
            EnableClientScript="true"
            ForeColor="Red"
            HeaderText="Vocé precisa corrigir os seguintes campos"
            runat="server"
            ></asp:ValidationSumary>--%>
        <br />  
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnGravar" Text="Gravar" CssClass="btn btn-primary" runat="server" OnClick="btnGravar_Click" />
        <br />
        <a href="Catalogo.aspx">Voltar ao catálogo de jogos</a>
    </div>

    

</asp:Content>
