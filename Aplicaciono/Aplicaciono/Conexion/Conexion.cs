using System.Data;
using System.Data.SqlClient;
using Aplicaciono.Modelos;

namespace Aplicaciono.Conexion
{
    class Conexione : IRepo
    {
        public SqlConnection AbrirConexion()
        {
            string infoConexion = @"Data Source=(localdb)\Servidor;Initial Catalog=AppGestion;Integrated Security=True";
            SqlConnection con = new SqlConnection(infoConexion);
            con.Open();
            return con;
        }

        public void CerrarConexion(SqlConnection con)
        {
            con.Close();
        }

        public Usuario LeerUsuario(SqlConnection con)
        {
            Usuario matchingPerson = new Usuario();
            using (con)
            {
                string oString = "Select * from Usuario";
                SqlCommand oCmd = new SqlCommand(oString, con);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.dni = oReader["dni"].ToString();
                        matchingPerson.nombre = oReader["nombre"].ToString();
                        matchingPerson.apellido1 = oReader["apellido1"].ToString();
                        matchingPerson.apellido2 = oReader["apellido2"].ToString();
                        matchingPerson.direccion = oReader["direccion"].ToString();
                        matchingPerson.numero = oReader["numero"].ToString();
                        matchingPerson.cp = oReader["cp"].ToString();
                        matchingPerson.ciudad = oReader["ciudad"].ToString();
                        matchingPerson.provincia = oReader["nombre"].ToString();
                    }
                }
            }
            return matchingPerson;
        }

        public bool GuardarUsuario(SqlConnection con, Usuario user)
        {
            using (con)
            {
                string sql = "INSERT INTO Usuario(dni,nombre,apellido1,apellido2,direccion," +
                    "numero, cp, ciudad,provincia) VALUES(@param1,@param2,@param3,@param4,@param5,@param6" +
                    "@param7, @param8, @param9)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = user.dni;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = user.nombre;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = user.apellido1;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = user.apellido2;
                    cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = user.direccion;
                    cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = user.numero;
                    cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = user.cp;
                    cmd.Parameters.Add("@param8", SqlDbType.VarChar, 50).Value = user.ciudad;
                    cmd.Parameters.Add("@param9", SqlDbType.VarChar, 50).Value = user.provincia;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
