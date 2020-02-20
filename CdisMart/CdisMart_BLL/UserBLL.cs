using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class UserBLL
    {
        public DataTable consultarUsuario(string usuario, string contraseña)
        {
            UserDAL user = new UserDAL();
            return user.consultarUsuario(usuario, contraseña);
        }

        public DataTable consultarUsuarios()
        {
            UserDAL user = new UserDAL();
            return user.consultarUsuarios();
        }
        public Users consultarUsuario(string usuario)
        {
            UserDAL usuarioDAL = new UserDAL();
            return usuarioDAL.consultarUsuario(usuario);
        }
        public void altaUsuario(string  nombreCompleto, string correoElectronico, string nombreUsuario, string contraseña)
        {
            UserDAL usuario = new UserDAL();




            usuario.altaUsuario(nombreCompleto, correoElectronico, nombreUsuario, contraseña);
        }
        

    }
}
