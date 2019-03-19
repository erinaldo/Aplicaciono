using Aplicaciono.Conexion;
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

        public SplashInicia(Conexione conexion)
        {
            this.repo = conexion;
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
            //carga pantalla de crear usuario
        }
    }
}
