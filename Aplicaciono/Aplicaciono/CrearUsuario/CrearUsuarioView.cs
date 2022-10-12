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
        bool modificarUser;
        public CrearUsuarioView()
        {
            InitializeComponent();
            this.ActiveControl = lbldni;
            repo = new Conexione();
            presenter = new CrearUsuarioPresenter(this, repo);
            usuario = new Usuario();
            modificarUser = false;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            con = repo.AbrirConexion();
            usuario.dni = editDNI.Text;
            usuario.nombre = editNombre.Text;
            usuario.apellido = editApellido1.Text;
            usuario.direccion = editDireccion.Text;
            usuario.cp = editCP.Text;
            usuario.ciudad = editCiudad.Text;
            usuario.provincia = editProvincia.Text;
            if (presenter.guardarClick(usuario, con, modificarUser) == true)
                this.Close();
            else
                MessageBox.Show("Ha ocurrido un error al actualizar los datos");
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if(presenter.comprobarDireccion(e, errorProvider1, editDireccion))
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

        private void CrearUsuarioView_Load(object sender, EventArgs e)
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            Usuario user = repo.LeerUsuario(con);
            if (user.dni != null)
            {
                modificarUser = true;
                editDNI.Text = user.dni;
                editNombre.Text = user.nombre;
                editApellido1.Text = user.apellido;
                editDireccion.Text = user.direccion;
                editCP.Text = user.cp;
                editCiudad.Text = user.ciudad;
                editProvincia.Text = user.provincia;
            }
        }
    }
}
