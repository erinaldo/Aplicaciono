using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Http
{
    interface IRepo
    {
        void AbrirConexion();
        void CerrarConexion();
        void GetUsuario();
    }
}