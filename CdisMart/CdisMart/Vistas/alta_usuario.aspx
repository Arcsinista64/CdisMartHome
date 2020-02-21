<%@ Page Title="" Language="C#" MasterPageFile="~/SiteForLogin.Master" AutoEventWireup="true" CodeBehind="alta_usuario.aspx.cs" Inherits="CdisMart.Vistas.alta_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />

        <div class="col-md-6">
            <div class="form-group">
              <label class=" " for="txtNombreCompleto">Nombre Completo:</label>  
              <div class="">
                    <asp:TextBox ID="txtNombreCompleto" runat="server" placeholder="Nombres Apellidos" class="form-control input-md"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombreCompleto" runat="server" ErrorMessage="Requerido." ControlToValidate="txtNombreCompleto" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Error. Por favor ingrese Nombre(s) y Apellidos." ControlToValidate="txtNombreCompleto" ValidationExpression="^^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    
              </div>
            </div>
            <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtEmail">Correo Electronico:</label>  
              <div class="">
                  <asp:TextBox ID="txtEmail" runat="server" placeholder="example@mail.com" class="form-control input-md"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Requerido." ControlToValidate="txtEmail" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="rev_correo" runat="server" ErrorMessage="Error. Ingrese formato de correo electrònico." ControlToValidate="txtEmail" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
              </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtUser">Nombre de usuario:</label>  
              <div class="">
                  <asp:TextBox ID="txtUser" runat="server" placeholder="User" class="form-control input-md"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Requerido." ControlToValidate="txtUser" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="rfvUsuario" runat="server" ValidationExpression="^[a-zA-Z0-9]{0,10}$" ErrorMessage="Ingrese usuario alfanumerico (Max. 10 caracteres)." ControlToValidate="txtUser" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    
              </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtPassword">Contraseña:</label>  
              <div class="">
                  <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="**********" class="form-control input-md"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Requerido." ControlToValidate="txtPassword" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Ingrese contraseña alfanumerica (Max. 10 caracteres)." ControlToValidate="txtPassword" ValidationExpression="^[a-zA-Z0-9]{0,10}$" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    
              </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
              <label class=" " for="txtPasswordConfirmacion">Confirmar contraseña:</label>  
              <div class="">
                 <asp:TextBox ID="txtPasswordConfirmacion" TextMode="Password" runat="server" placeholder="**********" class="form-control input-md"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvPssConfimation" runat="server" ErrorMessage="Requerido." ControlToValidate="txtPasswordConfirmacion" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
    
                  <p ID="confirmPassword" style="display:none;">Contraseña no coincide.</p>  
              
              </div>

                <hr />

            </div>

            <asp:Button ID="btnAgregar" runat="server" Text=" Agregar " OnClick="btnAgregar_Click" ValidationGroup="vlg1"/>
        </div>
        
        <script type="text/javascript">
            function passwordNoCoincide() {
                document.getElementById("confirmPassword").style.display = "inline";
            };
        </script>

</asp:Content>
