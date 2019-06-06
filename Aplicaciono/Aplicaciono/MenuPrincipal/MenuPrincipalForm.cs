using Aplicaciono.CrearUsuario;
using Aplicaciono.Utils;
using Aplicaciono.GestionImpuestos;
using Aplicaciono.GestionUsuarios;
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

        }

        private void btnGenerarGastos_Click(object sender, System.EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, System.EventArgs e)
        {
            GestionClientesView gestionClientes = new GestionClientesView();
            gestionClientes.ShowDialog();
        }

        private void btnGestionImpuestos_Click(object sender, System.EventArgs e)
        {
            GestionImpuestosView gestionImpuestos = new GestionImpuestosView();
            gestionImpuestos.ShowDialog();
        }

        private void btnDatosUsuario_Click(object sender, System.EventArgs e)
        {
            CrearUsuarioView crearUsuario = new CrearUsuarioView(ConstantesGlobales.viejo);
            crearUsuario.ShowDialog();
        }

        private void cerrarApp(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("¿Estass seguro que quieres cerrar la aplicación?", "Cerrare", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}