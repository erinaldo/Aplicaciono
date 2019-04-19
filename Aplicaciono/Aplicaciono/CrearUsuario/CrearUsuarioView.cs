using Aplicaciono.Conexion;
using Aplicaciono.Modelos;
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
        public CrearUsuarioView()
        {
            InitializeComponent();
            this.ActiveControl = lbldni;
            repo = new Conexione();
            presenter = new CrearUsuarioPresenter(this, repo);
            usuario = new Usuario();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            presenter.guardarClick(usuario, con);
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
        }

        private void editNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (presenter.comprobarPalabras(e, errorProvider1, editNombre))
            {
                usuario.nombre = editNombre.Text;
            }
        }

        private void editApellido1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editApellido1))
            {
                usuario.apellido = editApellido1.Text;
            }
        }

        private void editDireccion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editDireccion))
            {
                usuario.direccion = editDireccion.Text;
            }
        }

        private void editCP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarCP(e, errorProvider1, editCP))
            {
                usuario.cp = editCP.Text;
            }
        }

        private void editCiudad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editCiudad))
            {
                usuario.ciudad = editCiudad.Text;
            }
        }

        private void editProvincia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(presenter.comprobarPalabras(e, errorProvider1, editProvincia))
            {
                usuario.provincia = editProvincia.Text;
            }
        }
    }
}
