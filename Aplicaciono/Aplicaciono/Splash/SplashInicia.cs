using Aplicaciono.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Splash
{
    class SplashInicia
    {

        IRepo repo;
        public Conexion conexion;

        public SplashInicia(Conexion conexion)
        {
            this.repo = conexion;
            //H
        }

        public void setUp()
        {
            repo.loquesea();
        }
    }
}
