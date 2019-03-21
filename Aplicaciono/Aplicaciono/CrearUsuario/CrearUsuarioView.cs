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
        public CrearUsuarioView()
        {
            InitializeComponent();
            repo = new Conexione();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                con = repo.AbrirConexion();

                Usuario user = new Usuario(editNombre.Text, editDNI.Text, editApellido1.Text, editApellido2.Text,
                    editDireccion.Text, editNumero.Text, editCP.Text, editCiudad.Text, editProvincia.Text);

                if (repo.GuardarUsuario(con, user))
                {
                    MessageBox.Show("Los datos se han introducido correctamente");
                }

                repo.CerrarConexion(con);
            }
        }

        private bool ValidarFormulario()
        {
            string Str = editNumero.Text.Trim();
            int Num;
            bool isNum = int.TryParse(Str, out Num);
            if (!isNum)
            {
                MessageBox.Show("El numero de la calle no es correcto");
                return false;
            }
            Str = editCP.Text.Trim();
            isNum = int.TryParse(Str, out Num);
            if (!isNum)
            {
                MessageBox.Show("El código postal no es correcto");
                return false;
            }
            return true;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
