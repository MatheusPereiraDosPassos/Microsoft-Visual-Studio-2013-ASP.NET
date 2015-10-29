<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro_cliente.aspx.cs" Inherits="Projeto.cadastro_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
        <asp:DropDownList ID="cboCategoria" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gridClientes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="121px" OnSelectedIndexChanged="gridClientes_SelectedIndexChanged" Width="391px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Editar" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <br />
    
    </div>
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" style="height: 26px" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
&nbsp;
        <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir" />
    </form>
</body>
</html>
