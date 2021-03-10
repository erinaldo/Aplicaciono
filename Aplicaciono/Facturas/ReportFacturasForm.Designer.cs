namespace Aplicaciono.Informes
{
    partial class ReportFacturasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaDataSet = new Aplicaciono.Facturas.FacturaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.facturasTableAdapter = new Aplicaciono.Facturas.FacturaDataSetTableAdapters.FacturasTableAdapter();
            this.fillByFechaToolStrip = new System.Windows.Forms.ToolStrip();
            this.fechaAltaToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.fechaAltaToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByFechaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillByThisMonthToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByThisMonthToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.FacturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource1)).BeginInit();
            this.fillByFechaToolStrip.SuspendLayout();
            this.fillByThisMonthToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FacturasBindingSource
            // 
            this.FacturasBindingSource.DataMember = "Facturas";
            this.FacturasBindingSource.DataSource = this.facturaDataSet;
            // 
            // facturaDataSet
            // 
            this.facturaDataSet.DataSetName = "FacturaDataSet";
            this.facturaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FacturaDataSet";
            reportDataSource1.Value = this.FacturasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Aplicaciono.Informes.FacturaReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // facturaDataSetBindingSource
            // 
            this.facturaDataSetBindingSource.DataSource = this.facturaDataSet;
            this.facturaDataSetBindingSource.Position = 0;
            // 
            // facturasBindingSource1
            // 
            this.facturasBindingSource1.DataMember = "Facturas";
            this.facturasBindingSource1.DataSource = this.facturaDataSetBindingSource;
            // 
            // facturasTableAdapter
            // 
            this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // fillByFechaToolStrip
            // 
            this.fillByFechaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaAltaToolStripLabel,
            this.fechaAltaToolStripTextBox,
            this.fillByFechaToolStripButton});
            this.fillByFechaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByFechaToolStrip.Name = "fillByFechaToolStrip";
            this.fillByFechaToolStrip.Size = new System.Drawing.Size(800, 25);
            this.fillByFechaToolStrip.TabIndex = 1;
            this.fillByFechaToolStrip.Text = "fillByFechaToolStrip";
            // 
            // fechaAltaToolStripLabel
            // 
            this.fechaAltaToolStripLabel.Name = "fechaAltaToolStripLabel";
            this.fechaAltaToolStripLabel.Size = new System.Drawing.Size(62, 22);
            this.fechaAltaToolStripLabel.Text = "FechaAlta:";
            // 
            // fechaAltaToolStripTextBox
            // 
            this.fechaAltaToolStripTextBox.Name = "fechaAltaToolStripTextBox";
            this.fechaAltaToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillByFechaToolStripButton
            // 
            this.fillByFechaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByFechaToolStripButton.Name = "fillByFechaToolStripButton";
            this.fillByFechaToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.fillByFechaToolStripButton.Text = "FillByFecha";
            this.fillByFechaToolStripButton.Click += new System.EventHandler(this.fillByFechaToolStripButton_Click);
            // 
            // fillByThisMonthToolStrip
            // 
            this.fillByThisMonthToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByThisMonthToolStripButton});
            this.fillByThisMonthToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByThisMonthToolStrip.Name = "fillByThisMonthToolStrip";
            this.fillByThisMonthToolStrip.Size = new System.Drawing.Size(111, 25);
            this.fillByThisMonthToolStrip.TabIndex = 2;
            this.fillByThisMonthToolStrip.Text = "fillByThisMonthToolStrip";
            // 
            // fillByThisMonthToolStripButton
            // 
            this.fillByThisMonthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByThisMonthToolStripButton.Name = "fillByThisMonthToolStripButton";
            this.fillByThisMonthToolStripButton.Size = new System.Drawing.Size(96, 22);
            this.fillByThisMonthToolStripButton.Text = "FillByThisMonth";
            // 
            // ReportFacturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fillByThisMonthToolStrip);
            this.Controls.Add(this.fillByFechaToolStrip);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportFacturasForm";
            this.Text = "ReportFacturasForm";
            this.Load += new System.EventHandler(this.ReportFacturasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource1)).EndInit();
            this.fillByFechaToolStrip.ResumeLayout(false);
            this.fillByFechaToolStrip.PerformLayout();
            this.fillByThisMonthToolStrip.ResumeLayout(false);
            this.fillByThisMonthToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Facturas.FacturaDataSet facturaDataSet;
        private System.Windows.Forms.BindingSource facturaDataSetBindingSource;
        private System.Windows.Forms.BindingSource FacturasBindingSource;
        private System.Windows.Forms.BindingSource facturasBindingSource1;
        private Facturas.FacturaDataSetTableAdapters.FacturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.ToolStrip fillByFechaToolStrip;
        private System.Windows.Forms.ToolStripLabel fechaAltaToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox fechaAltaToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByFechaToolStripButton;
        private System.Windows.Forms.ToolStrip fillByThisMonthToolStrip;
        private System.Windows.Forms.ToolStripButton fillByThisMonthToolStripButton;
    }
}