using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.Informes
{
    public partial class ReportFacturasForm : Form
    {
        public ReportFacturasForm()
        {
            InitializeComponent();
        }

        private void ReportFacturasForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facturaDataSet.Facturas' table. You can move, or remove it, as needed.
            DataSet test = CalcularDataSet();
            this.facturasTableAdapter.FillByThisMonth(this.facturaDataSet.Facturas);

            this.reportViewer1.RefreshReport();
        }
        public DataSet CalcularDataSet()
        {
            string sql = @"
            SELECT [PkId]
                  ,[NumAlbaran]
                  ,[Localidad]
                  ,[Cliente]
                  ,[Matricula]
                  ,[Importe]
                  ,[FechaAlta]
                  ,[dni]
                  ,[PorcenIVA]
                  ,[PorcenIRPF]
                  ,[Descuento]
                  ,[Total]
                  ,[TotalFactura]
              FROM [AppGestion].[dbo].[Facturas]";
            string connstr = @"Data Source=DESKTOP-PFPBK7U\SQLEXPRESS;Initial Catalog=AppGestion;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            conn.Open();

            DataSet ds = new DataSet();
            da.Fill(ds, "Finalistas");

            conn.Close();
            return ds;

        }

        private void fillByFechaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
              //  this.facturasTableAdapter.FillByFecha(this.facturaDataSet.Facturas, new Nullable<DateTime>(((DateTime)(Convert.ChangeType("2020-02-09 11:47:00.000", typeof(DateTime))))));
              //  this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
