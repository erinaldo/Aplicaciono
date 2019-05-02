using Aplicaciono.Facturas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void btnGenerarFact_Click(object sender, System.EventArgs e)
        {
            FacturasView fact = new FacturasView();
            fact.ShowDialog();
        }

        private void btnGenerarGastos_Click(object sender, System.EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {

        }

        private void button5_Click(object sender, System.EventArgs e)
        {

        }
    }
}