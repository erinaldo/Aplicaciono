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
                    "numero, cp, ciudad,provincia) VALUES('"+ user.dni + "','" + user.nombre + "','" + user.apellido1 + "'" +
                    ",'" + user.apellido2 + "','" + user.direccion + "','" + Int16.Parse(user.numero) + "', '" + int.Parse(user.cp) + "'," +
                    " '" + user.ciudad + "', '" + user.provincia + "')";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
