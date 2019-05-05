using Aplicaciono.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Aplicaciono.Conexion
{
    interface IRepo
    {
        SqlConnection AbrirConexion();
        void CerrarConexion(SqlConnection con);
        Usuario LeerUsuario(SqlConnection con);
        bool GuardarUsuario(SqlConnection con, Usuario user);
        List<Factura> MostrarFacturas(SqlConnection con);
    }
}
