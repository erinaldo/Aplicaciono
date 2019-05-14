using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Modelos
{
    class Impuestos
    {
        public string dni { get; set; }
        public decimal iva { get; set; }
        public decimal irpf { get; set; }

        public Impuestos(string dni, decimal iva, decimal irpf)
        {
            this.dni = dni;
            this.iva = iva;
            this.irpf = irpf;
        }

        public Impuestos()
        {
        }
    }
}
