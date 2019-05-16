using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicaciono.Conexion;
using Aplicaciono.Modelos;

namespace Aplicaciono.GestionImpuestos
{
    class GestionImpuestosPresenter : IGestionImpuestosPresenter
    {
        GestionImpuestosView view;
        Conexione repo;

        string mensaje = "¿Estas seguro que quieres cancelar? Esto borrará todo lo que has introducido y cerrará el programa";
        string caption = "Cancelar";
        private GestionImpuestosView gestionImpuestosView;

        public GestionImpuestosPresenter(GestionImpuestosView view, Conexione repo)
        {
            this.view = view;
            this.repo = repo;
        }

        public void cancelarClick()
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(mensaje, caption, messageBoxButtons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public bool comprobarImpuestos(CancelEventArgs e, ErrorProvider errorProvider, TextBox editImpuesto)
        {
            throw new NotImplementedException();
        }

        public bool guardarClick(Impuestos usuario, SqlConnection con)
        {
            throw new NotImplementedException();
        }
    }
}
