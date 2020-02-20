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
    public partial class creacion_subasta : Tema, IAcceso
    {

        #region EVENTOS
        public bool sesionIniciada()
        {
            {
                if (Session["Usuario"] != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }
        public string usuarioActivo()
        {
            return Session["nombreUsuario"].ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    lblUsuarioActivo.Text = "Usuario activo: "+usuarioActivo();

                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        
        #endregion

        #region



        #endregion

        protected void btnAgregarSubasta_Click(object sender, EventArgs e)
        {
            //Session["Usuario"].ToString(); = TextBox1.Text;

            agregarSubasta();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Registro", "alert('Subasta registrada exitosamente.')", true);


        }

        public void agregarSubasta()
        {
            SubastaBLL subasta = new SubastaBLL();

            string nombreProducto = txtNombreProducto.Text;
            string descripcionProducto = txtDescripcionProducto.Text;
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fechaFinal = Convert.ToDateTime(txtFechaFin.Text);
            string usuariodeOferta = usuarioActivo();


            subasta.agregarSubasta(nombreProducto, descripcionProducto, fechaInicio, fechaFinal, 1);

        }
    
    }
}