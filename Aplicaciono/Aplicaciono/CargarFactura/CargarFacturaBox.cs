using Aplicaciono.Facturas;
using System;
using System.Windows.Forms;

namespace Aplicaciono.CargarFactura
{
    public partial class CargarFacturaBox : Form
    {
        public CargarFacturaBox()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacturasView fact = new FacturasView(textBox1.Text);
            this.Close();
            fact.ShowDialog();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
