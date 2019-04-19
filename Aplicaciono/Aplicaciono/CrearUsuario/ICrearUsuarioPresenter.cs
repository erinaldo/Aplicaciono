using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicaciono.Modelos;

namespace Aplicaciono.CrearUsuario
{
    interface ICrearUsuarioPresenter
    {
        bool comprobarDni(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editDNI);
        bool comprobarPalabras(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editPalabra);
        bool comprobarCP(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editCP);
        void guardarClick(Usuario usuario, SqlConnection con);
        void cancelarClick();
    }
}
