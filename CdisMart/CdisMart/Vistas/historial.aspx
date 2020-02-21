<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historial.aspx.cs" Inherits="CdisMart.Vistas.historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12" >
            <asp:Label style="float:right;" ID="lblUsuarioActivo" runat="server" Text=""></asp:Label>
        </div>
    <hr />
    
    <div class="container">

        <asp:Label ID="lblNombreProducto" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
        <hr />
        <asp:DropDownList class=".lista" AutoPostBack="true" ID="ddlUsuarios" runat="server"></asp:DropDownList>
    
    
    </div>

    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView class="table table-hover" ID="grdSubastasporID"  AutoGenerateColumns = "false" runat="server" OnRowCommand="grdSubastasporID_RowCommand">
                <FooterStyle BackColor="SkyBlue" />
                <Columns>
                    <asp:BoundField HeaderText = "Usuario que realizó la oferta" DataField = "UserId"/>
                    <asp:BoundField HeaderText = "Fecha de la realización de la oferta" DataField = "BidDate"/>
                    <asp:BoundField HeaderText = "Monto de la oferta"  DataField = "Amount"/>
            
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate>
                        <asp:Label ID="lblPrecio" runat="server" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                  </FooterTemplate>
                </asp:TemplateField>

                </Columns>
                
            </asp:GridView>
            
        </ContentTemplate>


    </asp:UpdatePanel>
    
     <div class="col-md-12" >
            <asp:Label ID="Label1" runat="server" Text="Total: "></asp:Label>
            <asp:TextBox ID="txtSumatoriaOfertas" runat="server" Enabled="false"></asp:TextBox>
        </div>
    
        

            
    
    <script type="text/javascript">

        $(document).ready(function() {

            function CalcularTotal() {

                var total = 0;
                $("#<%=grdSubastasporID.ClientID%> [id*='Amount']").each(function () {

                    var coltotal = parseFloat($(this).html());

                    if (!isNaN(coltotal)) {
                        total += coltotal;
                    }

                });

                $("#<%=grdSubastasporID.ClientID%> [id*='lblTotal']").html(total);

            }
        }

            
        
    </script>


</asp:Content>
