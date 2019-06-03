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
            this.components = new System.ComponentModel.Container();
            this.lblIva = new System.Windows.Forms.Label();
            this.tbIva = new System.Windows.Forms.TextBox();
            this.lblIrpf = new System.Windows.Forms.Label();
            this.tbIrpf = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.tbIva.Validating += new System.ComponentModel.CancelEventHandler(this.ValidarIva);
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
            // tbIrpf
            // 
            this.tbIrpf.Location = new System.Drawing.Point(73, 63);
            this.tbIrpf.Name = "tbIrpf";
            this.tbIrpf.Size = new System.Drawing.Size(100, 20);
            this.tbIrpf.TabIndex = 3;
            this.tbIrpf.Validating += new System.ComponentModel.CancelEventHandler(this.validarIrpf);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(66, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(147, 110);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GestionImpuestosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 145);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tbIrpf);
            this.Controls.Add(this.lblIrpf);
            this.Controls.Add(this.tbIva);
            this.Controls.Add(this.lblIva);
            this.Name = "GestionImpuestosView";
            this.Text = "Gestionar Impuestos";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox tbIva;
        private System.Windows.Forms.Label lblIrpf;
        private System.Windows.Forms.TextBox tbIrpf;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}