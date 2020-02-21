using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart.Vistas
{
    public partial class detalles : Tema, IAcceso
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
            int IdSubasta;
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    lblUsuarioActivo.Text = "Usuario activo: " + UserNameActivo();

                    IdSubasta = int.Parse(Request.QueryString["pIdSubasta"]);
                    cargarSubasta(IdSubasta);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        public string UserNameActivo()
        {
            return Session["nombreUsuario"].ToString();
        }

        public int UserIDActivo()
        {
            return int.Parse(Session["Id_Usuario"].ToString());
        }
        protected void btnRealizarOferta_Click(object sender, EventArgs e)
        {
            int IdSubasta;
            IdSubasta = int.Parse(Request.QueryString["pIdSubasta"]);

            int nuevaOferta = int.Parse(txtNuevaOferta.Text);

            SubastaBLL oferta = new SubastaBLL();
            Auction auction = new Auction();
            auction = oferta.cargarSubasta(IdSubasta);

            DateTime BidDate = DateTime.Now;
            int IdUsuarioActivo = UserIDActivo();
            
            int usuarioCreadordeSubasta;
            Decimal ofertaAnterior;

            usuarioCreadordeSubasta = UsuarioCreadordeSubasta(IdSubasta);
            ofertaAnterior = OfertaAnterior(IdSubasta);
            
            bool subastaActiva;
            bool mismoUsuario;
            if (DateTime.Parse(txtFechaFinalizacion.Text) > DateTime.Now) { subastaActiva = true;} else { subastaActiva = false; }
            if (usuarioCreadordeSubasta == IdUsuarioActivo) { mismoUsuario = true; } else { mismoUsuario = false; }
            try
            {
                


                //TS
                oferta.actualizarWinner(IdUsuarioActivo, nuevaOferta, auction, ofertaAnterior, subastaActiva, mismoUsuario); ;
                oferta.agregarRecordSubasta(int.Parse(lblIdSubasta.Text),  UserIDActivo(),  nuevaOferta, BidDate);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertPass", "alert('Oferta realizada exitosamente.')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertPass", "alert('"+ ex.Message +"')", true);
            }
        }
        #endregion

        #region METODOS
        public int UsuarioCreadordeSubasta(int IdSubasta)
        {
            SubastaBLL usuario = new SubastaBLL();
            Auction dtSubasta = new Auction();
            dtSubasta = usuario.cargarSubasta(IdSubasta);

            return int.Parse(dtSubasta.UserId.ToString());
        }
        public Decimal OfertaAnterior(int IdSubasta)
        {
            SubastaBLL usuario = new SubastaBLL();
            Auction dtSubasta = new Auction();
            dtSubasta = usuario.cargarSubasta(IdSubasta);

            if(dtSubasta.HighestBid == null)
            {
                return Decimal.Parse("0");
            }
            else
            { 
                return Decimal.Parse(dtSubasta.HighestBid.ToString());
            }
        }
        public void cargarSubasta(int IdSubasta)
        {
            SubastaBLL usuario = new SubastaBLL();
            Auction dtSubasta = new Auction();
            dtSubasta = usuario.cargarSubasta(IdSubasta);

            lblIdSubasta.Text = dtSubasta.AuctionId.ToString();
            txtNombreProducto.Text = dtSubasta.ProductName.ToString();
            txtFechaInicio.Text = dtSubasta.StartDate.ToString().Substring(0, 16);
            txtFechaFinalizacion.Text = dtSubasta.EndDate.ToString().Substring(0, 16);
            txtDescripcion.Text = dtSubasta.Description.ToString();
            //this.usuarioCreadordeSubasta = int.Parse(dtSubasta.UserId.ToString());

            txtOfertaMasAlta.Text = dtSubasta.HighestBid.ToString();
            //this.ofertaAnterior = Decimal.Parse(dtSubasta.HighestBid.ToString());

            txtUsuariodeOfertaMasAlta.Text = dtSubasta.Users.Name.ToString();

        }

        





        #endregion
    }
}