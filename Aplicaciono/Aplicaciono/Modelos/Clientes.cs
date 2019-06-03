using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Modelos
{
    class Clientes
    {
        public int id { get; }
        public string nombre { get; set; }
        public string precio { get; set; }

        public Clientes(string nombre, string precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public Clientes(int id, string nombre, string precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}
