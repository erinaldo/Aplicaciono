using Aplicaciono.Conexion;
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

        public SplashInicia(Conexione conexion)
        {
            this.repo = conexion;
            //H
        }

        public void setUp()
        {
           con = repo.AbrirConexion();
            //sql
            repo.CerrarConexion(con);
        }
    }
}
