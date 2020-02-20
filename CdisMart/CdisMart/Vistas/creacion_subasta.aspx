<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="creacion_subasta.aspx.cs" Inherits="CdisMart.Vistas.creacion_subasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="col-md-12" >
            <asp:Label style="float:right;" ID="lblUsuarioActivo" runat="server" Text=""></asp:Label>
        </div>
    <hr />
    <div class="col-md-12">
            <div class="form-group">
              <label class=" " for="txtNombreProducto">Nombre del producto:</label>  
              <div class="">
                    <asp:TextBox ID="txtNombreProducto" runat="server" placeholder="Marca, Modelo" class="form-control input-md"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ErrorMessage="Requerido" ControlToValidate="txtNombreProducto" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rfvnombreproducto" runat="server" ErrorMessage="Error. Ingrese nombre alfabètico (Max. 50 caracteres)." ControlToValidate="txtNombreProducto" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]{0,50}$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    
              </div>
            </div>
            <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtDescripcionProducto">Descripcion del producto:</label>  
              <div class="">
                  <asp:TextBox ID="txtDescripcionProducto" runat="server" placeholder="RAM, Almacenamiento, Componentes" class="form-control input-md"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="Requerido" ControlToValidate="txtDescripcionProducto" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="rfvDescripcionProducto" runat="server" ErrorMessage="Error. Ingrese nombre alfabètico (Max. 50 caracteres)." ControlToValidate="txtDescripcionProducto" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]{0,100}$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                  
              
              </div>
            </div>

        <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtFechaInicio">Fecha de inicio:</label>  
              <div class="">
                  <asp:TextBox ID="txtFechaInicio" runat="server" placeholder="DD-MM-YYYY" class="form-control input-md"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ErrorMessage="Requerido" ControlToValidate="txtFechaInicio" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtFechaInicio" ValidationGroup="vlg1" ErrorMessage="Error. Ingrese formato: (dd/mm/yyyy)." Display="Dynamic"></asp:CompareValidator>
                  
               </div>
            </div>

        <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtFechaFin">Fecha de finalización:</label>  
              <div class="">
                  <asp:TextBox ID="txtFechaFin" runat="server" placeholder="DD-MM-YYYY HH:MM" class="form-control input-md"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" ErrorMessage="Requerido" ControlToValidate="txtFechaFin" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="cv_rfvFechaFin" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtFechaFin" ValidationGroup="vlg1" ErrorMessage="Error. Ingrese formato: (dd/mm/yyyy hh:mm)." Display="Dynamic"></asp:CompareValidator>
              </div>
            </div>


            

            <asp:Button ID="btnAgregarSubasta" runat="server" Text=" Agregar " OnClick="btnAgregarSubasta_Click" ValidationGroup="vlg1"/>
        </div>
        

        <script type="text/javascript">

            $(document).ready(function () {

                $("#MainContent_txtFechaInicio").datepicker(
                    {
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "2020:2030",
                        dateFormat: "dd-mm-yy"
                    });

                $("#MainContent_txtFechaFin").datepicker(
                    {
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "2020:2030",
                        dateFormat: "dd-mm-yy"
                    });

                $(".lista").chosen();

            });

            var manager = Sys.WebForms.PageRequestManager.getInstance();

            manager.add_endRequest(function () {

                $("#MainContent_txtFechaInicio").datepicker(
                    {
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "2020:2030",
                        dateFormat: "dd-mm-yy"
                    });

                $("#MainContent_txtFechaFin").datepicker(
                    {
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "2020:2030",
                        dateFormat: "dd-mm-yy"
                    });

                $(".lista").chosen();

            });

    </script>

</asp:Content>
