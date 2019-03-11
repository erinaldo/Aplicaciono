using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Conexion
{
    interface IRepo
    {
        SqlConnection AbrirConexion();
        void CerrarConexion(SqlConnection con);


    }
}
