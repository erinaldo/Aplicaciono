namespace Aplicaciono.GestionImpuestos
{
    partial class GestionImpuestosView
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
            this.lblIva = new System.Windows.Forms.Label();
            this.tbIva = new System.Windows.Forms.TextBox();
            this.lblIrpf = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(43, 40);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(24, 13);
            this.lblIva.TabIndex = 0;
            this.lblIva.Text = "IVA";
            // 
            // tbIva
            // 
            this.tbIva.Location = new System.Drawing.Point(73, 37);
            this.tbIva.Name = "tbIva";
            this.tbIva.Size = new System.Drawing.Size(100, 20);
            this.tbIva.TabIndex = 1;
            // 
            // lblIrpf
            // 
            this.lblIrpf.AutoSize = true;
            this.lblIrpf.Location = new System.Drawing.Point(36, 67);
            this.lblIrpf.Name = "lblIrpf";
            this.lblIrpf.Size = new System.Drawing.Size(31, 13);
            this.lblIrpf.TabIndex = 2;
            this.lblIrpf.Text = "IRPF";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // GestionImpuestosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 115);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblIrpf);
            this.Controls.Add(this.tbIva);
            this.Controls.Add(this.lblIva);
            this.Name = "GestionImpuestosView";
            this.Text = "Gestionar Impuestos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox tbIva;
        private System.Windows.Forms.Label lblIrpf;
        private System.Windows.Forms.TextBox textBox1;
    }
}