﻿namespace Aplicaciono.Modelos
{
    class Factura
    {
        public string fecha { get; set; }
        public string numAlbaran { get; set; }
        public string idLocalidad { get; set; }
        public string idCliente { get; set; }
        public string matricula { get; set; }
        public string importe { get; set; }
        public string Descuento { get; set; }
        public string Total { get; set; }
        public string IRPF { get; set; }
        public string IVA { get; set; }
        public string TotalFactura { get; set; }

        public Factura(string fecha, string numAlbaran, string idLocalidad, string idCliente, string matricula, string importe, 
            string descuento, string total, string irpf, string iva, string totalFactura)
        {
            this.fecha = fecha;
            this.numAlbaran = numAlbaran;
            this.idLocalidad = idLocalidad;
            this.idCliente = idCliente;
            this.matricula = matricula;
            this.importe = importe;
            this.Descuento = descuento;
            this.Total = total;
            this.IRPF = irpf;
            this.IVA = iva;
            this.TotalFactura = totalFactura;
        }

        public Factura()
        {

        }
    }
}