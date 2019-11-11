<%@ Page Language="C#" Title="Entrada" AutoEventWireup="true" CodeBehind="webEntrada.aspx.cs" Inherits="estapar.webEntrada" %>

<!DOCTYPE html>
<link href="styEstapar.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="webEntrada" runat="server" >
        <div>

        <table style="width: 100%; background-color: #DFDFDF;">
            <tr>
                <td style="width: 1000px; height: 100px; vertical-align: middle; text-align: right; padding-right: 20px;">
                    <asp:ImageButton ID="imgEstapar" runat="server" ImageUrl="~/Images/novo_logo_estapar_estacionamentos_site.png" />
                </td>
                <td style="width: 3000px; padding-left: 20px; border-left-style: solid; border-left-color: #999999; border-left-width: 1px;">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial Rounded MT Bold" Font-Size="Large" ForeColor="#006600" Text="GERENCIADOR DE MONOBRAS" Font-Bold="False"></asp:Label>
                </td>
            </tr>
        </table>
            <table >
            <table style=" width: 100%; margin-bottom: 5px; margin-top: 5px;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="background-color: #3A3A3A; vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px;">
                        &nbsp;</td>
                    <td style="background-color: #3A3A3A; vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px;">
                    <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#CCCCCC" Text="LIMPAR" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="background-color: #3A3A3A; vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px;">
                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#CCCCCC" Text="NOVO" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="background-color: #3A3A3A; vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px;">
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#CCCCCC" Text="GRAVAR" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="background-color: #3A3A3A; vertical-align: middle; text-align: center; padding-top: 7px; padding-bottom: 5px;">
                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#CCCCCC" Text="EXCLUIR" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="background-color: #3A3A3A">&nbsp;</td>
                </tr>
                <tr>
                    <td style="background-color: #3A3A3A; width: 100px; height: 40px; vertical-align: middle; text-align: center; padding-bottom: 7px; padding-top: 5px;">
                    <asp:ImageButton ID="imgHome" runat="server" ImageUrl="~/Images/home_w.png" Width="28px" OnClick="imgHome_Click" />
                    </td>
                    <td style="background-color: #3A3A3A; width: 100px; height: 40px; vertical-align: middle; text-align: center; padding-bottom: 5px; padding-top: 5px;">
                    <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/Images/clear_w.png" Width="30px" OnClick="imgClear_Click" />
                    </td>
                    <td style="background-color: #3A3A3A; width: 100px; height: 40px; vertical-align: middle; text-align: center; padding-bottom: 5px; padding-top: 5px;">
                    <asp:ImageButton ID="imgIncluir" runat="server" ImageUrl="~/Images/add_new.png" Width="30px" OnClick="imgIncluir_Click" />
                    </td>
                    <td style="background-color: #3A3A3A; width: 100px; height: 40px; vertical-align: middle; text-align: center; padding-bottom: 7px; padding-top: 5px;">
                    <asp:ImageButton ID="imgGravar" runat="server" ImageUrl="~/Images/save_w.png" Width="30px" OnClick="imgGravar_Click" />
                    </td>
                    <td style="background-color: #3A3A3A; width: 100px; height: 40px; vertical-align: middle; text-align: center; padding-bottom: 8px; padding-top: 5px;">
                    <asp:ImageButton ID="imgExcluir" runat="server" ImageUrl="~/Images/delete_w.png" Width="30px" OnClick="imgExcluir_Click" />
                    </td>
                    <td style="background-color: #3A3A3A; vertical-align: bottom; padding-bottom: 8px; padding-right: 20px; text-align: right;">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial Black" Font-Size="Medium" ForeColor="White" Text="Entrada Veiculo" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width:100%; background-color: #e4e4e4;">
                <tr>
                    <td style="width: 2000px; vertical-align: top;">
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 600px; height: 40px; vertical-align: middle; text-align: right; padding-right: 15px">
                                <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="CODIGO : "></asp:Label>
                                </td>
                                <td style="width: 1500px; height: 30px; vertical-align: middle; text-align: left; " class="styTextLabel">
                                    <asp:TextBox ID="emn_id" runat="server" AutoComplete="off" CssClass="styTextBox"></asp:TextBox>
                                </td>
                                <td style="height: 30px; vertical-align: middle; text-align: left; padding-left: 12px;">
                                <asp:ImageButton ID="imgKey" runat="server" ImageUrl="~/Images/find_b.png" Width="25px" OnClick="imgKey_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 600px; height: 40px; vertical-align: middle; text-align: right; padding-right: 15px">
                                <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="PLACA : "></asp:Label>
                                </td>
                                <td style="width: 1500px; height: 30px; vertical-align: middle; text-align: left; " class="styTextLabel">
                                    <asp:TextBox ID="emn_placa" runat="server" AutoComplete="off" CssClass="styTextBox"></asp:TextBox>
                                </td>
                                <td style="width: 100px; height: 30px; vertical-align: middle; text-align: left; ">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 600px; height: 40px; vertical-align: middle; text-align: right; padding-right: 15px">
                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="MARCA : "></asp:Label>
                                </td>
                                <td style="width: 1500px; height: 30px; vertical-align: middle; text-align: left; " class="styTextLabel">
                                    <asp:DropDownList ID="cma_id" runat="server" CssClass="styTextBox">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px; height: 30px; vertical-align: middle; text-align: left; ">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 600px; height: 40px; vertical-align: middle; text-align: right; padding-right: 15px">
                    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="MODELO : "></asp:Label>
                                </td>
                                <td style="width: 1500px; height: 30px; vertical-align: middle; text-align: left;" class="styTextLabel">
                                    <asp:DropDownList ID="cmo_id" runat="server" CssClass="styTextBox">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px; height: 30px; vertical-align: middle; text-align: left;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 600px; height: 40px; vertical-align: middle; text-align: right; padding-right: 15px">
                    <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="MANOBRISTA : "></asp:Label>
                                </td>
                                <td style="width: 1500px; height: 30px; vertical-align: middle; text-align: left;" class="styTextLabel">
                                    <asp:DropDownList ID="man_id" runat="server" CssClass="styTextBox">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px; height: 30px; vertical-align: middle; text-align: left;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 2000px; vertical-align: top;">
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td style="width: 1200px">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; text-align: right; padding-right: 5px; height: 40px;">
                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#333333" Text="PLACA : "></asp:Label>
                                </td>
                                <td class="styTextLabel">
                                    <asp:TextBox ID="txt_pesquisa" runat="server" AutoComplete="off" CssClass="styTextBox"></asp:TextBox>
                                </td>
                                <td style="vertical-align: middle; text-align: left; padding-left: 12px;">
                                <asp:ImageButton ID="imgLocalizar" runat="server" ImageUrl="~/Images/find_b.png" Width="25px" OnClick="imgLocalizar_Click"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px; vertical-align: top; text-align: right; padding-top: 9px; padding-right: 7px;">
                    <asp:ImageButton ID="imgSelect" runat="server" ImageUrl="~/Images/seta_e.png" Width="18px" OnClick="imgSelect_Click" Height="20px" />
                                            </td>
                                <td class="styTextLabel">
                                    <asp:ListBox ID="lstEstmanobra" runat="server" CssClass="styTextBox" Height="200px" OnSelectedIndexChanged="lstEstmanobra_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:ListBox>
                                </td>
                                <td style="width: 200px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        <table style="width: 100%; background-color: #339966;">
            <tr>
                <td style="vertical-align: middle; text-align: center; padding-top: 3px; padding-bottom: 3px; height: 30px; width: 50px;">
                    <asp:ImageButton ID="imgLimpar" runat="server" ImageUrl="~/Images/erro_w.png" Width="20px" OnClick="imgLimpar_Click" Visible="False" />
                    </td>
                <td style="vertical-align: middle; text-align: left; padding-top: 3px; padding-bottom: 3px; padding-left: 15px; height: 30px; width: 3000px;">
                    <asp:Label ID="labERRO" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Font-Bold="False"></asp:Label>
                    </td>
            </tr>
        </table>

        </div>
    </form>
</body>
</html>
