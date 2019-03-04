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

namespace Aplicaciono
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string infoConexion = @"Data Source=(localdb)\Servidor;Initial Catalog=Aplicaciono;Integrated Security=True";            
            SqlConnection con = new SqlConnection(infoConexion);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string q = "Select nombre from Usuario";
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                string newID = (string)cmd.ExecuteScalar();
                reader = cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}
