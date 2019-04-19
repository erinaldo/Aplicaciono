using Aplicaciono.Conexion;
using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.CrearUsuario
{
    class CrearUsuarioPresenter : ICrearUsuarioPresenter
    {
        CrearUsuarioView view;
        Conexione repo;

        string mensaje = "¿Estas seguro que quieres cancelar? Esto borrará todo lo que has introducido y cerrará el programa";
        string caption = "Cancelar";

        public CrearUsuarioPresenter(CrearUsuarioView view, Conexione repo)
        {
            this.view = view;
            this.repo = repo;
        }

        public bool comprobarCP(CancelEventArgs e, ErrorProvider errorProvider, TextBox editCP)
        {
            if (ValidacionesUtils.ValidarCodigoPostal(editCP.Text))
            {
                e.Cancel = false;
                errorProvider.SetError(editCP, null);
                return true;
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(editCP, "Lo has hecho mal");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool comprobarDni(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editDNI)
        {
            if (ValidacionesUtils.ValidarDni(editDNI.Text))
            {
                e.Cancel = false;
                errorProvider.SetError(editDNI, null);
                return true;
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(editDNI, "Lo has hecho mal");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool comprobarPalabras(CancelEventArgs e, ErrorProvider errorProvider, TextBox editPalabra)
        {
            if (ValidacionesUtils.ValidarPrimeraMayus(editPalabra.Text))
            {
                e.Cancel = false;
                errorProvider.SetError(editPalabra, null);
                return true;
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(editPalabra, "Lo has hecho mal");
                return false;
            }
            throw new NotImplementedException();
        }

        public void guardarClick(Usuario usuario, SqlConnection con)
        {
            try
            {
                con = repo.AbrirConexion();

                if (repo.GuardarUsuario(con, usuario))
                {
                    MessageBox.Show("Los datos se han introducido correctamente");
                }

                repo.CerrarConexion(con);
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException)
                {
                    MessageBox.Show("No se puede guardar con campos vacios");
                }
                MessageBox.Show("No se ha podido realizar una conexión a la base de datos");
            }
               
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
    }
}
