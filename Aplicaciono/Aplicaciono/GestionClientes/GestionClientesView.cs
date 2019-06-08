using Aplicaciono.Conexion;
using Aplicaciono.GestionClientes;
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

namespace Aplicaciono.GestionUsuarios
{
    public partial class GestionClientesView : Form
    {
        Conexione repo;
        SqlConnection con;
        IGestionImpuestosPresenter presenter;
        List<Clientes> clientes;

        public GestionClientesView()
        {
            InitializeComponent();
            repo = new Conexione();
            presenter = new GestionClientesPresenter(this, repo);
            clientes = presenter.cargarClientes(con);
            if(clientes != null)
            { 
                for (int i = 0; i<clientes.Count; i++)
                {
                    dataGridView1.Rows.Add(clientes[0].nombre, clientes[0].fecha, clientes[0].fecha, clientes[0].fecha);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
