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
        public string fecha { get; set; }

        public Clientes(string nombre, string precio, string fecha)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.fecha = fecha;
        }

        public Clientes(int id, string nombre, string precio, string fecha)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.fecha = fecha;
        }
    }
}
