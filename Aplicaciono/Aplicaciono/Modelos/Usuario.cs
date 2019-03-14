
namespace Aplicaciono.Modelos
{
    class Usuario
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion { get; set; }
        public string numero { get; set; }
        public string cp { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }

        public Usuario(string nombre, string dni, string apellido1, string apellido2, string direccion, string numero, string cp, string ciudad, string provincia)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.direccion = direccion;
            this.numero = numero;
            this.cp = cp;
            this.ciudad = ciudad;
            this.provincia = provincia;
        }

        public Usuario()
        {
        }
    }
}
