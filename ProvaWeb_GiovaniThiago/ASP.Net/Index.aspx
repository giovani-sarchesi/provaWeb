<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProvaWeb_GiovaniThiago.NewFolder1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Concessinária VS</title>
    <link rel="stylesheet" type="text/css" href="../CSS/css.css" />
</head>
<body>
    <h1 id="cabecalho">
        Concessinonária Sarchesi Valle
    </h1>
    <hr />
    <form id="frmCadastro" runat="server">
            <asp:Label  ID="lblId" runat="server" Text="Id Carro" Width="75px"></asp:Label>
            <asp:TextBox ID="txtId" runat="server" MaxLength="20" Width="100px"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblMarca" runat="server" Text="Marca" Width="75px"></asp:Label>
            <asp:TextBox ID="txtMarca" runat="server" MaxLength="20" Width="100px"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblModelo" runat="server" Text="Modelo" Width="75px"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server" MaxLength="20" Width="100px"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblAno" runat="server" Text="Ano" Width="75px"></asp:Label>
            <asp:TextBox ID="txtAno" runat="server" MaxLength="4" TextMode="Number" Width="100px" min="1990" max="2020"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblKM" runat="server" Text="KM" Width="75px"></asp:Label>
            <asp:TextBox ID="txtKM" runat="server" MaxLength="4" TextMode="Number" Width="100px" min="0" max="100000"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblPreco" runat="server" Text="Preço" Width="75px"></asp:Label>
            <asp:TextBox ID="txtPreco" runat="server" TextMode="Number" Width="100px" min="5000"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblCor" runat="server" Text="Cor" Width="75px"></asp:Label>
            <asp:TextBox ID="txtCor" runat="server" TextMode="Color" Width="100px"></asp:TextBox><br />
            <br />
            <div id="menu" aria-dropeffect="none" aria-orientation="vertical" dir="ltr">
                <asp:Button Class="button" ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" Width="158px" />
                <asp:Button Class="buttonUpdate" ID="btnAtualizar" runat="server" Text="Atualizar" Width="157px" OnClick="btnAtualizar_Click" />
                <asp:Button Class="buttonDelete" ID="btnExcluir" runat="server" Text="Excluir" Width="157px" OnClick="btnExcluir_Click" /><br />
                <br />
            </div>
            <asp:Label ID="lblRetorno" runat="server" Text=""></asp:Label>
            <asp:GridView ID="dtCarros" runat="server" BorderStyle="Double" HorizontalAlign="Left" CellPadding="2" CellSpacing="2" Height="100px" PageSize="5" Width="200px">
                <HeaderStyle BorderStyle="Outset" />
                <RowStyle VerticalAlign="Middle" />
            </asp:GridView>
    </form>
</body>
</html>
