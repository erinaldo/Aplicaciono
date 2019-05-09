using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Aplicaciono.Modelos
{
    public class PojoFactura
    {
        //Propiedades
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidMat { get; set; }
        public string TipoDocument { get; set; }
        public string Correo { get; set; }
        public bool Vigencia { get; set; }
        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        public PojoFactura()
        {
        }
     /*   //Constructor que recibe parámetro de la misma clase
        public PojoFactura(Factura Add)
        {
            idCliente = Add.idCliente;
            idLocalidad = Add.idLocalidad;
            importe = Add.importe;
            matricula = Add.matricula;
            numAlbaran = Add.numAlbaran;
        }*/
    }
}