using Aplicaciono.Modelos;
using System.Data.SqlClient;

namespace Aplicaciono.Conexion
{
    interface IRepo
    {
        SqlConnection AbrirConexion();
        void CerrarConexion(SqlConnection con);
        Usuario LeerUsuario(SqlConnection con);
        bool GuardarUsuario(SqlConnection con, Usuario user);
        bool ModificarUsuario(SqlConnection con, Usuario user);
        Impuestos LeerImpuestos(SqlConnection con);
        bool GuardarImpuestos(SqlConnection con, Impuestos impuestos);
    }
}
