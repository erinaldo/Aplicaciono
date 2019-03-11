using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Modelos
{
    class Usuario
    {
        public string dni { get; set; }
        public string nombre { get; set; }

        public Usuario(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;

        }

        public Usuario()
        {
        }

        public Usuario BuscarUsuario()
        {
            string infoConexion = @"Data Source=(localdb)\Servidor;Initial Catalog=AppGestion;Integrated Security=True";
            Usuario matchingPerson = new Usuario();
            using (SqlConnection myConnection = new SqlConnection(infoConexion))
            {
                string oString = "Select * from Usuario";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingPerson.dni = oReader["dni"].ToString();
                        matchingPerson.nombre = oReader["nombre"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPerson;
        }
    }
}
