using Aplicaciono.Conexion;
using System.Data.SqlClient;


namespace Aplicaciono.Splash
{
    class SplashInicia
    {

        IRepo repo;
        SqlConnection con;

        public SplashInicia(Conexione conexion)
        {
            this.repo = conexion;
        }

        public void setUp()
        {
           con = repo.AbrirConexion();
            repo.LeerUsuario(con);
            repo.CerrarConexion(con);
        }
    }
}
