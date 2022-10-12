﻿using System;
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
            //la String de conexion se puede conseguir haciendo la base de datos y abriendo view server explorer y propiedades de conexion
            //string infoConexion = @"Data Source=(localdb)\SQLEXPRESS;Initial Catalog=AppGestion;Integrated Security=True";
            string infoConexion = @"Data Source=(localdb)\Local;Initial Catalog=AppGestion;Integrated Security=True";
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

        public bool GuardarUsuario(SqlConnection con, Usuario user, bool modificarUser)
        {
            string sql = "";
            using (con)
            {
                if (modificarUser == false)
                {

                    sql = "INSERT INTO Usuario(dni,nombre,apellido,direccion," +
                        "cp, ciudad,provincia) VALUES('" + user.dni + "','" + user.nombre + "','" + user.apellido + "'" +
                        ",'" + user.direccion + "', '" + int.Parse(user.cp) + "'," +
                        " '" + user.ciudad + "', '" + user.provincia + "')";
                }
                else
                {
                    sql = "UPDATE Usuario(dni,nombre,apellido,direccion," +
                        "cp, ciudad,provincia) VALUES('" + user.dni + "','" + user.nombre + "','" + user.apellido + "'" +
                        ",'" + user.direccion + "', '" + int.Parse(user.cp) + "'," +
                        " '" + user.ciudad + "', '" + user.provincia + "' where dni = '"+user.dni+"')";
                }
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool GuardarFactura(SqlConnection con, Factura fact, string dni)
        {
            using (con)
            {
                string sql = "INSERT INTO Facturas(Fecha,NumAlbaran,Localidad,Cliente,Matricula," +
                "Importe,FechaAlta, dni, PorcenIVA, PorcenIRPF, Descuento,Total,TotalFactura) " +
                "VALUES('" + fact.fecha +
                "','" + fact.numAlbaran +
                "','" + fact.idLocalidad +
                "','" + fact.idCliente + " " +
                "','" + fact.matricula +
                "','" + fact.importe + 
                "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                "','" + dni +
                "','" + fact.IVA +
                "','" + fact.IRPF +
                "','" + fact.Descuento +
                "','" + fact.Total +
                "','" + fact.TotalFactura+"')";
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
                string oString = "Select * from Facturas";
                SqlCommand oCmd = new SqlCommand(oString, con);
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Factura fact = new Factura();
                        fact.numAlbaran = oReader["NumAlbaran"].ToString();
                        fact.idLocalidad = oReader["Localidad"].ToString();
                        fact.idCliente = oReader["Cliente"].ToString();
                        fact.matricula = oReader["Matricula"].ToString();
                        fact.importe = oReader["Importe"].ToString();
                        listaFacturas.Add(fact);
                    }
                }
            }
            return listaFacturas;
        }
    }
}