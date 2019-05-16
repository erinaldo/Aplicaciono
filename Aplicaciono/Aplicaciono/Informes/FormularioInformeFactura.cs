using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Aplicaciono.Modelos;
using Aplicaciono.Conexion;

namespace Aplicaciono.Informes
{
    public partial class FormularioInformeFactura : Form
    {
        public FormularioInformeFactura()
        {
            InitializeComponent();
            this.Load += Form1_Load1;
        }
        /// <summary>
        /// Se carga los datos en el reporte 
        /// en el evento Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load1(object sender, EventArgs e)
        {
            CargarReporte();

        }
        /// <summary>
        /// Método para recuperar Datos a una lista
        /// y para mostrar en el ReportViewer
        /// </summary>
        private void CargarReporte()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            try
            {
                List<Factura> user = repo.MostrarFacturas(con);
                List<Factura> Agregar = user;
                ///Mostrar datos en el reporte
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Aplicaciono.Informes.Report1.rdlc";
                ReportDataSource rds1 = new ReportDataSource("Factura", Agregar);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.RefreshReport();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.ToString());
            }
            repo.CerrarConexion(con);
        }
        private void FormularioInformeFactura_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
    /// <summary>
    /// Clase para conectarse
    /// al servidor de base de datos
    /// </summary>
    public class Conexionsql
    {
        /// <summary>
        /// Retorna Tabla con datos
        /// </summary>
        /// <returns></returns>
        public DataTable Datos()
        {
            // Fragmento de código para
            //Para conexión al SQLSERVER
            DataTable Retornar = new DataTable();
            SqlConnection Conectar = new SqlConnection(@"Data Source={Nombreservidor};Initial Catalog=Reporte;Integrated Security=True");
            Conectar.Open();
            //Se ejecuta el procedimiento almacenado
            SqlDataAdapter Comandosql = new SqlDataAdapter("exec DatosPersona", Conectar);
            Comandosql.Fill(Retornar);
            Conectar.Close();
            return Retornar;
        }
    }
}