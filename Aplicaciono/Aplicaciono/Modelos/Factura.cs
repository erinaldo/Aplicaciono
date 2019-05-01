namespace Aplicaciono.Modelos
{
    class Factura
    {
        public string numAlbaran { get; set; }
        public string idLocalidad { get; set; }
        public string idCliente { get; set; }
        public string matricula { get; set; }
        public string importe { get; set; }

        public Factura(string numAlbaran, string idLocalidad, string idCliente, string matricula, string importe)
        {
            this.numAlbaran = numAlbaran;
            this.idLocalidad = idLocalidad;
            this.idCliente = idCliente;
            this.matricula = matricula;
            this.importe = importe;
        }

        public Factura()
        {

        }
    }
}