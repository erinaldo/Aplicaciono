namespace Aplicaciono.Modelos
{
    class Usuario
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string cp { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }

        public Usuario(string nombre, string dni, string apellido, string direccion, string cp, string ciudad, string provincia)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.apellido = apellido;
            this.direccion = direccion;
            this.cp = cp;
            this.ciudad = ciudad;
            this.provincia = provincia;
        }

        public Usuario()
        {
        }
    }
}
