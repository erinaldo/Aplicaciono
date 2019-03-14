using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Modelos
{
    class Usuario
    {
        public string dni { get; set; }
        public string nombre { get; set; }

        public Usuario(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;

        }

        public Usuario()
        {
        }
    }
}
