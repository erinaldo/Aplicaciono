using Aplicaciono.Conexion;
using Aplicaciono.Modelos;
using Aplicaciono.Utils;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Aplicaciono.CrearUsuario
{
    public partial class CrearUsuarioView : Form
    {
        Conexione repo;
        SqlConnection con;
        ICrearUsuarioPresenter presenter;
        Usuario usuario;
        public CrearUsuarioView(bool tipo)
        {
            InitializeComponent();
            this.ActiveControl = lbldni;
            repo = new Conexione();
            presenter = new CrearUsuarioPresenter(this, repo, tipo);
            usuario = new Usuario();
            if (!tipo)
            {
                usuario = presenter.cargarDatosUsuario(con);
                editApellido1.Text = usuario.apellido;
                editDNI.Text = usuario.dni;
                editNombre.Text = usuario.nombre;
                editDireccion.Text = usuario.direccion;
                editCP.Text = usuario.cp;
                editCiudad.Text = usuario.ciudad;
                editProvincia.Text = usuario.provincia;
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool close = presenter.guardarClick(usuario, con);
            if (close)
            {
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            presenter.cancelarClick();
        }

        private void editDNI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarDni(e, errorProvider1, editDNI))
            {
                usuario.dni = editDNI.Text;
            }
            else
            {
                usuario.dni = "";
            }
        }

        private void editNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (presenter.comprobarPalabras(e, errorProvider1, editNombre))
            {
                usuario.nombre = editNombre.Text;
            }
            else
            {
                usuario.nombre = "";
            }
        }

        private void editApellido1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editApellido1))
            {
                usuario.apellido = editApellido1.Text;
            }
            else
            {
                usuario.apellido = "";
            }
        }

        private void editDireccion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarDireccion(e, errorProvider1, editDireccion))
            {
                usuario.direccion = editDireccion.Text;
            }
            else
            {
                usuario.direccion = "";
            }
        }

        private void editCP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarCP(e, errorProvider1, editCP))
            {
                usuario.cp = editCP.Text;
            }
            else
            {
                usuario.cp = "";
            }
        }

        private void editCiudad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editCiudad))
            {
                usuario.ciudad = editCiudad.Text;
            }
            else
            {
                usuario.ciudad = "";
            }
        }

        private void editProvincia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editProvincia))
            {
                usuario.provincia = editProvincia.Text;
            }
            else
            {
                usuario.provincia = "";
            }
        }
    }
}
