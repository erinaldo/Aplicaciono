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
        private CrearUsuarioView crearUsuarioView;

        public CrearUsuarioPresenter(Usuario usuario, SqlConnection con, bool modificarUsuario)
        {
            this.view = view;
            this.repo = repo;
        }

        public CrearUsuarioPresenter(CrearUsuarioView crearUsuarioView, Conexione repo)
        {
            this.crearUsuarioView = crearUsuarioView;
            this.repo = repo;
        }

        public bool comprobarCP(CancelEventArgs e, ErrorProvider errorProvider, TextBox editCP)
        {
            if (ValidacionesUtils.ValidarCodigoPostal(editCP.Text))
            {
                errorProvider.SetError(editCP, null);
                return true;
            }
            else if (editCP.Text == "")
            {
                errorProvider.SetError(editCP, "Este campo no puede ser vacío");
                return false;
            }
            else
            {
                errorProvider.SetError(editCP, "El código postal no existe");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool comprobarDni(System.ComponentModel.CancelEventArgs e, ErrorProvider errorProvider, TextBox editDNI)
        {
            if (ValidacionesUtils.ValidarDni(editDNI.Text))
            {
                errorProvider.SetError(editDNI, null);
                return true;
            }
            else if(editDNI.Text == "")
            {
                errorProvider.SetError(editDNI, "Este campo no puede ser vacío");
                return false;
            }
            else
            {
                errorProvider.SetError(editDNI, "El DNI introducido es incorrecto");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool comprobarPalabras(CancelEventArgs e, ErrorProvider errorProvider, TextBox editPalabra)
        {
            if (ValidacionesUtils.ValidarPalabras(editPalabra.Text))
            {
                errorProvider.SetError(editPalabra, null);
                return true;
            }
            else if (editPalabra.Text == "")
            {
                errorProvider.SetError(editPalabra, "Este campo no puede ser vacío");
                return false;
            }
            else
            {
                errorProvider.SetError(editPalabra, "Este campo no es correcto");
                return false;
            }
            throw new NotImplementedException();
        }

        public bool comprobarDireccion(CancelEventArgs e, ErrorProvider errorProvider, TextBox editDireccion)
        {
            if (ValidacionesUtils.ValidarDireccion(editDireccion.Text))
            {
                errorProvider.SetError(editDireccion, null);
                return true;
            }
            else if (editDireccion.Text == "")
            {
                errorProvider.SetError(editDireccion, "Este campo no puede ser vacío");
                return false;
            }
            else
            {
                errorProvider.SetError(editDireccion, "Este campo no es correcto");
                return false;
            }
            throw new NotImplementedException();
        }

        public void guardarClick(Usuario usuario, SqlConnection con)
        {
            try
            {
                con = repo.AbrirConexion();

                if (repo.GuardarUsuario(con, usuario, true))
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

        public bool guardarClick(Usuario usuario, SqlConnection con, bool modificarUsuario)
        {
            string sql = "";
            using (con)
            {
                try
                {
                    if (modificarUsuario == false)
                    {

                        sql = "INSERT INTO Usuario(dni,nombre,apellido,direccion," +
                            "cp, ciudad,provincia) VALUES('" + usuario.dni + "','" + usuario.nombre + "','" + usuario.apellido + "'" +
                            ",'" + usuario.direccion + "', '" + int.Parse(usuario.cp) + "'," +
                            " '" + usuario.ciudad + "', '" + usuario.provincia + "')";
                    }
                    else
                    {
                        sql = "UPDATE Usuario set dni ='" + usuario.dni + "', nombre ='" + usuario.nombre + "', apellido ='" + usuario.apellido + "'" +
                            ", direccion = '" + usuario.direccion + "', cp='" + int.Parse(usuario.cp) + "', ciudad = " +
                            " '" + usuario.ciudad + "', provincia = '" + usuario.provincia + "' where dni = '" + usuario.dni + "'";
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;

        }
    }
}
