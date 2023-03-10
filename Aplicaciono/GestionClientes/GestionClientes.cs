using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
using Aplicaciono.Informes;
using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aplicaciono.Facturas
{
    public partial class GestionClientes : Form
    {

        public GestionClientes()
        {
            InitializeComponent();
            loadClientes();
        }

        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
            GuardarClientes();
            /*ReportFacturasForm fact = new ReportFacturasForm();
            fact.Show();*/
        }

        private bool GuardarClientes()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            Usuario user = repo.LeerUsuario(con);            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con = repo.AbrirConexion();
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    Cliente cli = new Cliente
                        (
                        dataGridView1.Rows[i].Cells[0].Value.ToString(), 
                        dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        dataGridView1.Rows[i].Cells[2].Value.ToString(),                        
                        dataGridView1.Rows[i].Cells[4].Value.ToString()
                    );
                    repo.GuardarCliente(con, cli, user.dni);
                }
            }
            return true;
        }

        private void loadClientes()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            List<Cliente> clientes = repo.LoadClientes(con);

            bool registrado;
            for (int i = 0; i < clientes.Count; i++)
            {
                if (String.IsNullOrEmpty(clientes[i].cif))
                {
                    registrado = false;
                }
                else
                {
                    registrado = true;
                }
                this.dataGridView1.Rows.Add(clientes[i].nombre, clientes[i].cif, clientes[i].direccion, clientes[i].codigoPostal, clientes[i].provincia);
            }
        }
    }
}
