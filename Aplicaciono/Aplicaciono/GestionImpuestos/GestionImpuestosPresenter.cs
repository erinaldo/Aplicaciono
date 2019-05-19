using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
using Aplicaciono.Modelos;

namespace Aplicaciono.GestionImpuestos
{
    class GestionImpuestosPresenter : IGestionImpuestosPresenter
    {
        GestionImpuestosView view;
        Conexione repo;

        string mensaje = "¿Estas seguro que quieres cancelar? Esto borrará todo lo que has introducido y cerrará el programa";
        string caption = "Cancelar";
        bool validaciones = false;

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
                view.Close();
            }
        }

        public bool comprobarImpuestos(CancelEventArgs e, ErrorProvider errorProvider, TextBox editImpuesto)
        {
            if (ValidacionesUtils.ValidarImpuestos(editImpuesto.Text))
            {
                errorProvider.SetError(editImpuesto, null);
                return true;
            }
            else if (editImpuesto.Text == "")
            {
                errorProvider.SetError(editImpuesto, "Este campo no puede ser vacío");
                return false;
            }
            else
            {
                errorProvider.SetError(editImpuesto, "Este campo no es correcto");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool guardarClick(Impuestos impuestos, SqlConnection con)
        {
            validaciones = validacionesCorrectas(impuestos);
            if (validaciones)
            {
                try
                {
                    con = repo.AbrirConexion();
                    if (repo(con, impuestos))
                    {
                        MessageBox.Show("Los datos se han introducido correctamente");
                    }
                    
                    repo.CerrarConexion(con);
                    return true;
                }
                catch (Exception e)
                {
                    if (e is ArgumentNullException)
                    {
                        MessageBox.Show("No se puede guardar con campos vacios");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido realizar una conexión a la base de datos");
                    }
                    repo.CerrarConexion(con);
                }
                return false;
            }
            else
            {
                MessageBox.Show("No puedes guardar campos vacios");
            }
            return false;
            throw new NotImplementedException();
        }

        private bool validacionesCorrectas(Impuestos impuestos)
        {
            validaciones = true;
            validaciones = validaciones && ValidacionesUtils.ValidarDni(impuestos.dni);
            validaciones = validaciones && ValidacionesUtils.ValidarImpuestos(impuestos.iva.ToString());
            validaciones = validaciones && ValidacionesUtils.ValidarImpuestos(impuestos.irpf.ToString());
            return validaciones;
        }
    }
}
