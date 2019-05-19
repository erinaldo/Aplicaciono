using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
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

namespace Aplicaciono.GestionImpuestos
{
    public partial class GestionImpuestosView : Form
    {
        Conexione repo;
        SqlConnection con;
        IGestionImpuestosPresenter presenter;
        Impuestos impuestos;
        public GestionImpuestosView()
        {
            InitializeComponent();
            this.ActiveControl = btnAceptar;
            repo = new Conexione();
            presenter = new GestionImpuestosPresenter(this, repo);
            impuestos = new Impuestos();
        }

        private void BtnAceptar(object sender, EventArgs e)
        {
            bool close = presenter.guardarClick(impuestos, con);
            if (close)
            {
                this.Close();
            }
        }

        private void BtnCancelar(object sender, EventArgs e)
        {
            presenter.cancelarClick();
        }

        private void ValidarIva(object sender, CancelEventArgs e)
        {
            if (presenter.comprobarImpuestos(e, errorProvider1, tbIva))
            {
                impuestos.iva = Convert.ToDecimal(tbIva.Text);
            }
            else
            {
                impuestos.iva = 0;
            }
        }

        private void ValidarIrpf(object sender, CancelEventArgs e)
        {
            if (presenter.comprobarImpuestos(e, errorProvider1, tbIrpf))
            {
                impuestos.irpf = Convert.ToDecimal(tbIrpf.Text);
            }
            else
            {
                impuestos.irpf = 0;
            }
        }
    }
}
