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
using System.Windows.Forms;

namespace CdisMart.Vistas
{
    public partial class historial : Tema, IAcceso
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
                    cargarLabels();
                    cargarUsuarios();

                    

                    if(int.Parse(ddlUsuarios.SelectedValue) == 0)
                    {
                        grdSubastasporID.DataSource = cargarRecordSubastas();
                        grdSubastasporID.DataBind();
                    }
                    

                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                grdSubastasporID.DataSource = cargarRecordSubastasporUserId();
                grdSubastasporID.DataBind();
            }
        }
        public string usuarioActivo()
        {
            return Session["nombreUsuario"].ToString();

        }
        #endregion

        #region METODOS
        public int total = 0;
        protected void grdSubastasporID_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Total")
            {
                foreach (DataGridViewRow row in grdSubastasporID.Rows)
                {
                    total += Convert.ToInt32(row.Cells["Column2"].Value);
                }

                txtSumatoriaOfertas.Text = Convert.ToString(total);
            }
        }
        public List<object> cargarRecordSubastas()
        {
            int IdSubasta;
            IdSubasta = int.Parse(Request.QueryString["pIdSubasta"]);

            SubastaBLL subasta = new SubastaBLL();

            List<object> listSubastas = new List<object>();

            listSubastas = subasta.cargarRecordSubastas(IdSubasta);

            return listSubastas;
        }

        public List<object> cargarRecordSubastasporUserId()
        {
            int IdSubasta;
            IdSubasta = int.Parse(Request.QueryString["pIdSubasta"]);
            int IdUsuario = int.Parse(ddlUsuarios.SelectedValue);
            SubastaBLL subasta = new SubastaBLL();

            List<object> listSubastas = new List<object>();

            listSubastas = subasta.cargarRecordSubastasporUserId(IdSubasta, IdUsuario);

            return listSubastas;
        }
        public void cargarLabels()
        {
            int IdSubasta;
            IdSubasta = int.Parse(Request.QueryString["pIdSubasta"]);


            SubastaBLL oferta = new SubastaBLL();
            Auction auction = new Auction();
            auction = oferta.cargarSubasta(IdSubasta);

            lblNombreProducto.Text = auction.ProductName.ToString();
            lblDescripcion.Text = auction.Description.ToString();
        }
        public void cargarUsuarios()
        {
            UserBLL usuario = new UserBLL();
            DataTable dtUsuarios = new DataTable();

            dtUsuarios = usuario.consultarUsuarios();

            ddlUsuarios.DataSource = dtUsuarios;
            ddlUsuarios.DataTextField = "UserId";
            ddlUsuarios.DataValueField = "UserId";
            ddlUsuarios.DataBind();

            ddlUsuarios.Items.Insert(0, new ListItem("- Seleccione usuario -", "0"));
        }
        #endregion


    }
}