using Aplicaciono.CrearUsuario;
using Aplicaciono.Facturas;
using Aplicaciono.Informes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Aplicaciono.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void btnGenerarFact_Click(object sender, EventArgs e)
        {
            FacturasView fact = new FacturasView();
            fact.Size = new Size(1300, 600);
            fact.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            GestionClientes fact = new GestionClientes();
            fact.Show();
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            CrearUsuarioView fact = new CrearUsuarioView();
            fact.Show();
        }

        private void btnCargarFacturas_Click(object sender, EventArgs e)
        {

        }
    }
}