﻿using Aplicaciono.Conexion;
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

        public FacturasView(string numFactura)
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
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
                if (dataGridView1.Rows[i].Cells["Import"].Value != null)
                {
                    Factura fact = new Factura
                        (
                        dataGridView1.Rows[i].Cells["Fecha"].Value.ToString(), 
                        dataGridView1.Rows[i].Cells["NumAlbaran"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Localidad"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Cliente"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Matricula"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Import"].Value.ToString(),
                        txtDescuento.Text, txtTotal.Text, txtPorcenIRPF.Text, txtPorcenIVA.Text, txtTotalFactura.Text
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
                    facturas = repo.MostrarFacturas(con);
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
                        case "Matricula":
                            autotxt.Add(fact.matricula);
                            break;
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
                    if (dataGridView1.Rows[i].Cells["Import"].Value != null)
                    {
                        String celImportValue = dataGridView1.Rows[i].Cells["Import"].Value.ToString();
                        Regex regex = new Regex(@"[0-9]*[\.\,]?[.0-9]+");
                        if(ValidacionesUtils.ValidarNumeros(celImportValue))
                        {
                            dataGridView1.Rows[i].Cells["Import"].Value = "";
                        }
                        if (Decimal.TryParse(celImportValue, out decimal xt))
                            suma = suma + xt;
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
    }
}
