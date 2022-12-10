using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
using Aplicaciono.MenuPrincipal;
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

        public SplashInicia(Conexione conexion)
        {
            this.repo = conexion;
            this.setUp();
        }

        public void setUp()
        {
            con = repo.AbrirConexion();
            try
            {
                user = repo.LeerUsuario(con);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.ToString());
            }
            repo.CerrarConexion(con);
            elegirSiUsuarioExiste(user);
        }


        public void elegirSiUsuarioExiste(Usuario usuario)
        {
            if (usuario.dni != null)
            {
                MenuPrincipalForm menu = new MenuPrincipalForm();
                menu.ShowDialog();
            }
            CrearUsuarioView crearUsuario = new CrearUsuarioView();
          //  crearUsuario.ShowDialog();
        }
    }
}