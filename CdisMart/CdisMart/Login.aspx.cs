using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using System.Data;
using System.Data.SqlClient;
using CdisMart_DAL;


namespace CdisMart
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Vistas/lista_subastas.aspx");

                //Poner UserName en Site.Master
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "UserName", "", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesión", "alert('Usuario y/o contraseña incorrectos.')", true);
            }
        }

        //public bool usuarioValido()
        //{
        //    bool acceso = false;

        //    UserBLL userBLL = new UserBLL();
        //    Users usuario = new Users();

        //    usuario = userBLL.consultarUsuario(txtUsuario.Text, txtContraseña.Text);

        //    if (usuario.Rows.Count > 0)
        //    {
        //        //dtUsuario = userBLL.consultarUsuario(txtUsuario.Text);

        //        Session["Usuario"] = txtUsuario.Text;
        //        Session["IdSession"] = 
        //        acceso = true;
        //    }

        //    return acceso;
        //}

        public bool usuarioValido()
        {
            bool acceso = false;
            UserBLL userBLL = new UserBLL();
            DataTable dtUsuario = new DataTable();
            Users usuario = new Users();

            dtUsuario = userBLL.consultarUsuario(txtUsuario.Text, txtContraseña.Text);
            usuario = userBLL.consultarUsuario(txtUsuario.Text);
            
            if (dtUsuario.Rows.Count > 0)
            {
                int Id_Usuario = usuario.UserId;
                string nombreUsuario = usuario.Name;
                Session["Usuario"] = dtUsuario;
                Session["Id_Usuario"] = Id_Usuario;
                Session["nombreUsuario"] = nombreUsuario;
                acceso = true;
            }

            return acceso;

        }
    }
}