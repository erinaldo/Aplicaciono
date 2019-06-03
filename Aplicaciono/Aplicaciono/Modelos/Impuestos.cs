using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.Modelos
{
    class Impuestos
    {
        public string iva { get; set; }
        public string irpf { get; set; }

        public Impuestos(string iva, string irpf)
        {
            this.iva = iva;
            this.irpf = irpf;
        }

        public Impuestos()
        {
        }
    }
}
