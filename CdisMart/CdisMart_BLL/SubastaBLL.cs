using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;
using System.Data;
using System.Data.SqlClient;



namespace CdisMart_BLL
{
    public class SubastaBLL
    {
        public List<object> cargarSubastas()
        {
            SubastaDAL subasta = new SubastaDAL();
            return subasta.cargarSubastas();
        }
        public List<object> cargarRecordSubastas(int IdSubasta)
        {
            SubastaDAL subasta = new SubastaDAL();
            return subasta.cargarRecordSubastas(IdSubasta);
        }

        public List<object> cargarRecordSubastasporUserId(int IdSubasta, int IdUsuario)
        {
            SubastaDAL subasta = new SubastaDAL();
            return subasta.cargarRecordSubastasporUserId(IdSubasta, IdUsuario);
        }
        public Auction cargarSubasta(int IdSubasta)
        {
            SubastaDAL subasta = new SubastaDAL();
            return subasta.cargarSubastas(IdSubasta);
        }

        public void actualizarWinner(int userActivo, int nuevaOferta, Auction IdSubasta, Decimal ofertaAnterior, bool subastaVigente, bool mismoUsuario)
        {
            SubastaDAL subasta = new SubastaDAL();

            if(nuevaOferta < 0 || nuevaOferta > 1000000)
            {
                throw new Exception("La cantidad ingresada debe ser un decimal mayor a 0 y menor que 1,000,000.");
                //ERROR
            }
            if (nuevaOferta < ofertaAnterior)
            {
                throw new Exception("La oferta debe ser mayor a la oferta actual.");
                //ERROR
            }
            if (!subastaVigente)
            {
                throw new Exception("La subasta a finalizado.");
                //ERROR
            }
            if (mismoUsuario) 
            {
                throw new Exception("No se le permite ofertar en esta subasta.");
            }

            ofertaAnterior = nuevaOferta;

            subasta.actualizarWinner(userActivo, ofertaAnterior, IdSubasta);

        }

        public void agregarRecordSubasta(int AuctionId, int userActivo, int Amount, DateTime BidDate)
        {
            SubastaDAL subasta = new SubastaDAL();

            subasta.agregarRecordSubasta(AuctionId, userActivo, Amount, BidDate);
        }

        public void agregarSubasta(string nombreProducto, string descripcionProducto, DateTime fechaInicio, DateTime fechaFinal, int usuariodeOferta)
        {
            SubastaDAL subasta = new SubastaDAL();
            subasta.agregarSubasta(nombreProducto, descripcionProducto, fechaInicio, fechaFinal, usuariodeOferta);
        }
    }
}
