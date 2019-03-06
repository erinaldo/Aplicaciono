using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Http
{
    public class Conexion : IRepo
    {
        SqlConnection con;
        string infoConexion = @"Data Source=(localdb)\Servidor;Initial Catalog=AppGestion;Integrated Security=True";        

        void IRepo.AbrirConexion()
        {
            string infoConexion = @"Data Source=(localdb)\Servidor;Initial Catalog=AppGestion;Integrated Security=True";
            SqlConnection con;
            con = new SqlConnection(infoConexion);
            con.Open();
            //return true;
            
            throw new NotImplementedException();
        }

        void IRepo.CerrarConexion()
        {
            con.Close();
            throw new NotImplementedException();
        }

        void IRepo.GetUsuario()
        {
            SqlCommand cmd = new SqlCommand();
           // SqlDataReader reader;

            cmd.CommandText = "Select nombre from Usuario";
            cmd.CommandType = CommandType.Text;
            string nombreUsuario = (string)cmd.ExecuteScalar();

            //return nombreUsuario;
            throw new NotImplementedException();
        }
    }
}
