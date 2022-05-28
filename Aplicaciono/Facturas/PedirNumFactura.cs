using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.Facturas
{
    public partial class PedirNumFactura : Form
    {
        public string numFacturaBuscar;
        
        public PedirNumFactura()
        {
            InitializeComponent();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            numFacturaBuscar = numFacturaCargar.Text;
            FacturasView fact = new FacturasView(numFacturaBuscar);
            fact.Size = new Size(1300, 600);
            fact.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numFacturaCargar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
