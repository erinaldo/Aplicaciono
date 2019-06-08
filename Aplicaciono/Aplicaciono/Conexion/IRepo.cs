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
        bool ModificarUsuario(SqlConnection con, Usuario user);
        Impuestos LeerImpuestos(SqlConnection con);
        bool GuardarImpuestos(SqlConnection con, Impuestos impuestos);
        List<Clientes> LeerClientes(SqlConnection con);
        bool NuevoClientes(SqlConnection con, List<Clientes> clientes, int posicion);
        bool ModificarCliente(SqlConnection con, List<Clientes> clientes, int posicion);
        bool EliminarCliente(SqlConnection con, List<Clientes> clientes, int posicion);
    }
}
