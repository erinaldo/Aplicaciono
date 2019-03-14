using Aplicaciono.Conexion;
using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(usuario != null)
            {
                Console.WriteLine("nulo");

                //cargar pantalla de menu
            }
            Console.WriteLine("Usuario");
            //carga pantalla de crear usuario
        }
    }
}
