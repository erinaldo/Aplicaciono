using System;
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
                        matchingPerson.apellido = oReader["apellido1"].ToString();
                        matchingPerson.direccion = oReader["direccion"].ToString();
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
                string sql = "INSERT INTO Usuario(dni,nombre,apellido,direccion," +
                    "cp, ciudad,provincia) VALUES('" + user.dni + "','" + user.nombre + "','" + user.apellido + "'" +
                    ",'" + user.direccion + "', '" + int.Parse(user.cp) + "'," +
                    " '" + user.ciudad + "', '" + user.provincia + "')";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {//TODO!!!!!:::::
                    //string sql = "INSERT INTO Usuario(dni,nombre,apellido,direccion," +
                    //"cp, ciudad,provincia) VALUES(@dni,@nombre,@apellido,@direccion,@cp,@ciudad,@provincia)";
                    /*     TODO por si alguna vez se quiere hacer bien
                    cmd.Parameters.Add("@dni", SqlDbType.NChar).Value = user.dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.NChar).Value = user.nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.NChar).Value = user.apellido;
                    cmd.Parameters.Add("@direccion", SqlDbType.NChar).Value = user.direccion;
                    cmd.Parameters.Add("@cp", SqlDbType.Int).Value = user.cp;
                    cmd.Parameters.Add("@ciudad", SqlDbType.NChar).Value = user.ciudad;
                    cmd.Parameters.Add("@provincia", SqlDbType.NChar).Value = user.provincia;*/


                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
