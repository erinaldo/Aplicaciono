using Aplicaciono.Conexion;
using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.Facturas
{
    public partial class FacturasView : Form
    {
        public FacturasView()
        {
            InitializeComponent();
        }
        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
            Guardarfacturas();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Guardarfacturas();
        }

        private bool Guardarfacturas()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Import"].Value != null)
                {
                    Factura fact = new Factura(dataGridView1.Rows[i].Cells["NumAlbaran"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["IdLocalidad"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["IdCliente"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Matricula"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Import"].Value.ToString()
                    );
                    repo.GuardarFactura(con, fact);
                }
            }
            return true;
        }
    }
}