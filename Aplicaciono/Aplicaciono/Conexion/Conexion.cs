using System;
using System.Collections.Generic;
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
                    ",'" + user.direccion + "', '" + int.Parse(user.cp) + "'," +
                    " '" + user.ciudad + "', '" + user.provincia + "')";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool GuardarFactura(SqlConnection con, Factura fact)
        {
            using (con)
            {
                string sql = "INSERT INTO Albaranes(NumAlbaran,IdLocalidad,IdCliente,Matricula," +
                "Import) VALUES('" + fact.numAlbaran +
                "'," + fact.idLocalidad +
                "," + fact.idCliente + " " +
                ",'" + fact.matricula +
                "', " + fact.importe + " )";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            return true;
        }

        public List<Factura> MostrarFacturas(SqlConnection con)
        {
            List<Factura> listaFacturas = new List<Factura>();
            using (con)
            {
                string oString = "Select * from Albaranes";
                SqlCommand oCmd = new SqlCommand(oString, con);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Factura fact = new Factura();
                        fact.numAlbaran = oReader["NumAlbaran"].ToString();
                        fact.idCliente = oReader["IdLocalidad"].ToString();
                        fact.idCliente = oReader["IdCliente"].ToString();
                        fact.matricula = oReader["Matricula"].ToString();
                        fact.matricula = oReader["Import"].ToString();
                        listaFacturas.Add(fact);
                    }
                }
            }
            return listaFacturas;
        }
    }
}