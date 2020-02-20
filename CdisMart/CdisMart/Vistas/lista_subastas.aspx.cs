using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using System.Data;
using System.Data.Sql;

namespace CdisMart.Vistas
{
    public partial class lista_subastas : Tema, IAcceso
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    lblUsuarioActivo.Text = "Usuario activo: " + usuarioActivo();

                    grd_subastas.DataSource = cargarSubastas();
                    grd_subastas.DataBind();

                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        public string usuarioActivo()
        {
            return Session["nombreUsuario"].ToString();

        }

        #endregion

        #region METODOS
        protected void grd_subastas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Historial")
            {
                Response.Redirect("~/Vistas/historial?pIdSubasta=" + e.CommandArgument);
            }
            else
            {
            }
        }

        


        //ORM
        public List<object> cargarSubastas()
        {
            SubastaBLL subasta = new SubastaBLL();

            List<object> listSubastas = new List<object>();

            listSubastas = subasta.cargarSubastas();

            return listSubastas;
        }

        #endregion


    }
}