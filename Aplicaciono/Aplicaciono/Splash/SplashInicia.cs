using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
using Aplicaciono.Modelos;
using System;
using System.Data.SqlClient;

namespace Aplicaciono.Splash
{
    class SplashInicia
    {

        IRepo repo;
        SqlConnection con;
        Usuario user;
        SplashView splashView;

        public SplashInicia(Conexione conexion, SplashView splashView)
        {
            this.repo = conexion;
            this.splashView = splashView;
            this.setUp();
        }

        public void setUp()
        {
            Console.WriteLine("Aqui");
            con = repo.AbrirConexion();
            try
            {
                user = repo.LeerUsuario(con);
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e.ToString());
            }
            repo.CerrarConexion(con);
            elegirSiUsuarioExiste(user);
        }

    
        public void elegirSiUsuarioExiste(Usuario usuario)
        {
            if(usuario.dni != null)
            {
                Console.WriteLine("No es nulo");
                return;

                //cargar pantalla de menu
            }
            Console.WriteLine("Usuario");
            splashView.Hide();
            splashView.Visible = false;
            if (!splashView.Visible)
            {
                CrearUsuarioView cuv = new CrearUsuarioView();
                cuv.Show();
            }
        }
    }
}
