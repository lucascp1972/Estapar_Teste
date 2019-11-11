<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webEstapar.aspx.cs" Inherits="estapar.webEstapar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; background-color: #DFDFDF;">
            <tr>
                <td style="width: 1000px; height: 100px; vertical-align: middle; text-align: right; padding-right: 20px;">
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/novo_logo_estapar_estacionamentos_site.png" />
                </td>
                <td style="width: 3000px; padding-left: 20px; border-left-style: solid; border-left-color: #999999; border-left-width: 1px;">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial Rounded MT Bold" Font-Size="Large" ForeColor="#006600" Text="GERENCIADOR DE MONOBRAS" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 1000px; padding-left: 20px; border-left-style: solid; border-left-color: #999999; border-left-width: 1px;">&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: middle; text-align: center; width: 1000px; height: 40px;">
                    <asp:Label ID="Label1" runat="server" Font-Names="Candara" Font-Size="Medium" ForeColor="#333333" Text="Marca"></asp:Label>
                </td>
                <td style="vertical-align: middle; text-align: center; width: 1000px">
                    <asp:Label ID="Label2" runat="server" Font-Names="Candara" Font-Size="Medium" ForeColor="#333333" Text="Modelo"></asp:Label>
                </td>
                <td style="vertical-align: middle; text-align: center; width: 1000px">
                    <asp:Label ID="Label3" runat="server" Font-Names="Candara" Font-Size="Medium" ForeColor="#333333" Text="Manobrista"></asp:Label>
                </td>
                <td style="vertical-align: middle; text-align: center; width: 1000px">
                    <asp:Label ID="Label4" runat="server" Font-Names="Candara" Font-Size="Medium" ForeColor="#333333" Text="Entrada"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: middle; text-align: center; height: 100px;">
                    <asp:ImageButton ID="imgMarca" runat="server" ImageUrl="~/Images/carro.png" Width="60px" OnClick="imgMarca_Click" />
                </td>
                <td style="vertical-align: middle; text-align: center;">
                    <asp:ImageButton ID="imgModelo" runat="server" ImageUrl="~/Images/carro.png" Width="60px" OnClick="imgModelo_Click" />
                </td>
                <td style="vertical-align: middle; text-align: center;">
                    <asp:ImageButton ID="imgManobrista" runat="server" ImageUrl="~/Images/manobrista.png" Width="70px" OnClick="imgManobrista_Click" />
                </td>
                <td style="vertical-align: middle; text-align: center;">
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/entrada.png" Width="50px" OnClick="ImageButton4_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width: 100%; background-color: #339966;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
