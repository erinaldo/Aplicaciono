using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.GestionImpuestos
{
    interface IGestionImpuestosPresenter
    {
        bool comprobarImpuestos(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editImpuesto);
        bool guardarClick(Impuestos usuario, SqlConnection con);
        void cancelarClick();
    }
}
