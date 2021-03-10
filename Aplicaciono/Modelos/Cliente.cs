
namespace Aplicaciono.Modelos
{
    class Cliente
    {
        public string nombre { get; set; }
        public string cif { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string provincia { get; set; }

        public Cliente(string nombre, string cif, string direccion, string codigoPostal, string provincia)
        {
            this.nombre = nombre;
            this.cif = cif;
            this.direccion = direccion;
            this.codigoPostal = codigoPostal;
            this.provincia = provincia;
        }

        public Cliente()
        {

        }
    }
}
