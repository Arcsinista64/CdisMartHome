using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using System.Data;
using System.Data.SqlClient;


namespace CdisMart.Vistas
{
    public partial class alta_usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void altaUsuario()
        {
            UserBLL usuario = new UserBLL();

            string nombreCompleto = txtNombreCompleto.Text;
            string correoElectronico = txtEmail.Text;
            string nombreUsuario = txtUser.Text;
            string contraseña = txtPassword.Text;

            usuario.altaUsuario(nombreCompleto, correoElectronico, nombreUsuario, contraseña);
            
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool error = false;
            do
            {
                if (txtPassword.Text != txtPasswordConfirmacion.Text)
                {
                    error = true;

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertPass", "passwordNoCoincide();", true);

                }
                else
                {
                    try
                    {
                        error = false;
                        altaUsuario();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "alert('Usuario registradoexitosamente.')", true);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "alert('" + ex.Message + "')", true);
                    }
                    finally
                    {
                        txtUser.Text = "";
                        txtNombreCompleto.Text = "";
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                        txtPasswordConfirmacion.Text = "";
                    }
                }break;
            } while (error == true);



        }
    }
}