using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Splash
{
    class SplashInicia
    {

        Repo repo;

        public SplashInicia(Conexion conexion)
        {
            this.repo = conexion;

        }

        public void setUp()
        {
            repo.loquesea();
        }
    }
}
