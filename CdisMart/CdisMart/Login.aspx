<%@ Page Title="" Language="C#" MasterPageFile="~/SiteForLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CdisMart.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
            <div id="tableLogin">
                <table>

                    <tr>
                        <td><asp:TextBox class="form-control input-md" ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox class="form-control input-md" ID="txtContraseña" runat ="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox></td>
                    
                    </tr>
                    <tr>
                        <td>
                            <asp:Button class="form-control input-md" ID="btnIngresar" runat="server" Text="ingresar" OnClick="btnIngresar_Click"/>
                        </td>
                    </tr>

                </table>
            </div>
</asp:Content>
