using Aplicaciono.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciono.Informes
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            Conexione repo = new Conexione();
            con = repo.AbrirConexion();
            try
            {
                string cs = @"Data Source=(localdb)\Servidor;Initial Catalog=AppGestion;Integrated Security=True";
                string query = "select * from Usuario";
                OleDbDataAdapter adp = new OleDbDataAdapter(query, cs);
                AppGestionDataSet appGestionDataSet = new AppGestionDataSet();

            }
            catch (InvalidCastException er)
            {
                Console.WriteLine(er.ToString());
            }
            repo.CerrarConexion(con);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.Refresh();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
