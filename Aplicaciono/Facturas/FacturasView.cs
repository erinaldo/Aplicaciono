using Aplicaciono.Conexion;
using Aplicaciono.CrearUsuario;
using Aplicaciono.Informes;
using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aplicaciono.Facturas
{
    public partial class FacturasView : Form
    {
        SqlConnection con;
        string columnna;
        decimal totalIRPF = 0;
        decimal total = 0;
        decimal TotalIVA = 0;
        decimal suma = 0;
        decimal descuento = 0;
        List<Factura> factGuardadas;
        Factura fact;

        public FacturasView(string facturaABuscar)
        {
            InitializeComponent();
            loadImpuestos();
            loadFacturasMes();
        }

        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
            Guardarfacturas();
            ReportFacturasForm fact = new ReportFacturasForm();
            fact.Show();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Guardarfacturas();
            MessageBox.Show("Guardado correctamente");
        }

        private bool Guardarfacturas()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            Usuario user = repo.LeerUsuario(con);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con = repo.AbrirConexion();

                if (dataGridView1.Rows[i].Cells[5].Value != null && dataGridView1.Rows[i].Cells[6].Value == null)
                {
                    Factura fact = new Factura
                        (
                        txtNumFactura.Text,
                        dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        txtDescuento.Text, txtTotal.Text, txtPorcenIRPF.Text, txtPorcenIVA.Text, txtTotalFactura.Text, 
                        comboBox1.SelectedValue.ToString()
                    );
                    repo.GuardarFactura(con, fact, user.dni);
                }

            }
            return true;
        }

        public void avisoGuardar()
        {
            DialogResult result = MessageBox.Show("¿Has guardado las facturas?", "Imprimir", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Conexione repo = new Conexione();
                con = repo.AbrirConexion();
                try
                {
                    List<Factura> user = repo.MostrarFacturas(con);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.ToString());
                }
                repo.CerrarConexion(con);
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            if (dataGrid == null)
                return;
            List<Factura> facturas = null;
            TextBox auto = e.Control as TextBox;
            if (auto != null)
            {
                AutoCompleteStringCollection autotxt = new AutoCompleteStringCollection();
                auto.AutoCompleteMode = AutoCompleteMode.Suggest;
                auto.AutoCompleteSource = AutoCompleteSource.CustomSource;

                Conexione repo = new Conexione();
                con = repo.AbrirConexion();
                try
                {
                    facturas = repo.FacturasByCliente(con);
                }
                catch (InvalidCastException er)
                {
                    Console.WriteLine(e.ToString());
                }
                foreach (Factura fact in facturas)
                {
                    switch (columnna)
                    {
                        case "Localidad":
                            autotxt.Add(fact.idLocalidad);
                            break;
                        case "Cliente":
                            autotxt.Add(fact.idCliente);
                            break;
                     /*   case "Matricula":
                            autotxt.Add(fact.matricula);
                            break;*/
                    }
                }
                auto.AutoCompleteCustomSource = autotxt;
            }
        }

        private void txtPorcenIRPF_TextChanged(object sender, EventArgs e)
        {
            label9.Text = String.Format("IRPF {0}%", txtPorcenIRPF.Text);
            calcularIRPF();
        }

        private void txtPorcenIVA_TextChanged(object sender, EventArgs e)
        {
            label10.Text = String.Format("IVA {0}%", txtPorcenIVA.Text);
            calcularIVA();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            descuento = 0;
            suma = 0;
            total = 0;
            try
            {                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value != null)
                    {
                        String celImportValue = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        Regex regex = new Regex(@"[0-9]*[\.\,]?[.0-9]+");
                        if(ValidacionesUtils.ValidarNumeros(celImportValue))
                        {
                            dataGridView1.Rows[i].Cells[5].Value = "";
                        }
                        if (Decimal.TryParse(celImportValue, out decimal xt))
                            suma = suma + xt;
                    }

                    if (dataGridView1.Rows[i].Cells[2].Value != null)
                    {
                        Conexione repo = new Conexione();
                        con = repo.AbrirConexion();
                        try
                        {
                            Factura factura = repo.FacturaDeCliente(con, dataGridView1.Rows[i].Cells[2].Value.ToString());
                            if (dataGridView1.Rows[i].Cells[3].Value == null) {
                                dataGridView1.Rows[i].Cells[3].Value = factura.idLocalidad;
                            }
                           /* if (dataGridView1.Rows[i].Cells[4].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = factura.matricula;
                            }*/
                            if (dataGridView1.Rows[i].Cells[5].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[5].Value = factura.importe;
                            }
                        }
                        catch (InvalidCastException er)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                txtSuma.Text = suma.ToString();
            }
            catch (Exception ex)
            {
            }
            calcularTotal();
        }

        private void calcularTotal()
        {
            if (String.IsNullOrEmpty(txtDescuento.Text))
                descuento = 0;
            else
            {
                if (Decimal.TryParse(txtDescuento.Text, out decimal xd))
                    descuento = xd;
            }
            total = suma - descuento;
            txtTotal.Text = total.ToString();
        }

        private void calcularIRPF()
        {
            if (Decimal.TryParse(txtPorcenIRPF.Text, out decimal x))
                totalIRPF = (x * total) / 100;
            else
                totalIRPF = 0;
            txtIRPF.Text = totalIRPF.ToString();
            calcularTotalFactura();
        }

        private void calcularIVA()
        {
            if (Decimal.TryParse(txtPorcenIVA.Text, out decimal x))
                TotalIVA = (x * total) / 100;
            else
                TotalIVA = 0;
            txtIVA.Text = TotalIVA.ToString();
            calcularTotalFactura();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            calcularIRPF();
            calcularIVA();
            calcularTotalFactura();
        }

        private void calcularTotalFactura()
        {
            txtTotalFactura.Text = (total - totalIRPF + TotalIVA).ToString();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            columnna = dataGridView1.SelectedCells[0].OwningColumn.HeaderText;
        }

        private void FacturasView_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'clientesDataSet.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.clientesDataSet.Clientes);
            // TODO: This line of code loads data into the 'facturaDataSet.Facturas' table. You can move, or remove it, as needed.
            this.facturasTableAdapter.Fill(this.facturaDataSet.Facturas);
            if (fact.Cliente != null)
            {
                comboBox1.SelectedValue = fact.idCliente;
            }
            
        }

        private void loadImpuestos()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            fact = repo.DatosUltimaFactura(con);
            txtPorcenIRPF.Text = fact.IRPF;
            txtPorcenIVA.Text = fact.IVA;
          //  txtNumFactura.Text = fact.numFactura;

            /*comboBox1.DisplayMember = "Nombre"; // will display Name property
            comboBox1.ValueMember = "IdCliente"; // will select Value property

            clientesBindingSource.DataSource = clientesDataSet;
            comboBox1.DataSource = clientesBindingSource; // assign list (will populate comboBox1.Items)

            comboBox1.SelectedValue = fact.idCliente;*/

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string fecha, fechaFinal = "", fechaOriginal;
            if (e.ColumnIndex == 0)
            {
                var dataGrid = sender as DataGridView;
                if (dataGrid == null)
                    return;

                fechaOriginal = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                fecha = fechaOriginal.Substring(fechaOriginal.Length - 2);
                switch (fecha)
                {
                    case "01":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Enero";
                        break;
                    case "02":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Febrero";
                        break;
                    case "03":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Marzo";
                        break;
                    case "04":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Abril";
                        break;
                    case "05":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Mayo";
                        break;
                    case "06":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Junio";
                        break;
                    case "07":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Julio";
                        break;
                    case "08":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Agosto";
                        break;
                    case "09":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Septiembre";
                        break;
                    case "10":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Octubre";
                        break;
                    case "11":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Noviembre";
                        break;
                    case "12":
                        fechaFinal = fechaOriginal.Substring(0, fechaOriginal.Length - 2) + "Diciembre";
                        break;
                }
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = fechaFinal;
            }

        }
        private void loadFacturasMes()
        {
            Conexione repo = new Conexione();
            SqlConnection con = repo.AbrirConexion();
            factGuardadas = repo.LoadFacturasMes(con);
            bool registrado;
            for (int i = 0; i < factGuardadas.Count; i++)
            {
                if (String.IsNullOrEmpty(factGuardadas[i].PkId))
                {
                    registrado = false;
                }
                else
                {
                    registrado = true;
                }
                this.dataGridView1.Rows.Add(factGuardadas[i].fecha, factGuardadas[i].numAlbaran, factGuardadas[i].idCliente, factGuardadas[i].idLocalidad, factGuardadas[i].matricula, factGuardadas[i].importe, registrado);
            }
        }
    }
}
