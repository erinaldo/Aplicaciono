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
                        matchingPerson.apellido = oReader["apellido"].ToString();
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
                    ",'" + user.direccion + "', '" + user.cp + "'," +
                    " '" + user.ciudad + "', '" + user.provincia + "')";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public Usuario CargarUsuario(SqlConnection con)
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
                        matchingPerson.apellido = oReader["apellido"].ToString();
                        matchingPerson.direccion = oReader["direccion"].ToString();
                        matchingPerson.cp = oReader["cp"].ToString();
                        matchingPerson.ciudad = oReader["ciudad"].ToString();
                        matchingPerson.provincia = oReader["provincia"].ToString();
                    }
                }
            }
            return matchingPerson;
        }

        public bool ModificarUsuario(SqlConnection con, Usuario user)
        {
            using (con)
            {
                string sql = "update usuario set " +
                    "dni='" + user.dni + 
                    "', nombre='" + user.nombre + 
                    "', apellido='" + user.apellido +
                    "', direccion='" + user.direccion + 
                    "', cp='" + user.cp + 
                    "', ciudad='" + user.ciudad + 
                    "', provincia='" + user.provincia + "'";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool LeerImpuestos(SqlConnection con)
        {
            Impuestos impuestos = new Impuestos();
            using (con)
            {
                string query = "select * from Impuestos";
                SqlCommand oCmd = new SqlCommand(query, con);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        impuestos.dni = oReader["dni"].ToString();
                        impuestos.iva = Convert.ToInt32(oReader["iva"]);
                        impuestos.irpf = Convert.ToInt32(oReader["irpf"]);
                    }
                }
            }
            return true;
        }

        public bool GuardarImpuestos(SqlConnection con, Impuestos impuestos)
        {
            using (con)
            {
                string sql = "update impuestos set " +
                    "dni='" + impuestos.dni +
                    "', iva='" + impuestos.iva +
                    "', irpf='" + impuestos.irpf + "'";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
