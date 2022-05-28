
namespace Aplicaciono.Facturas
{
    partial class PedirNumFactura
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
            this.label1 = new System.Windows.Forms.Label();
            this.numFacturaCargar = new System.Windows.Forms.TextBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduce el número de Factura a cargar";
            // 
            // numFacturaCargar
            // 
            this.numFacturaCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFacturaCargar.Location = new System.Drawing.Point(17, 72);
            this.numFacturaCargar.Name = "numFacturaCargar";
            this.numFacturaCargar.Size = new System.Drawing.Size(323, 30);
            this.numFacturaCargar.TabIndex = 1;
            // 
            // aceptar
            // 
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.aceptar.Location = new System.Drawing.Point(17, 136);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(119, 47);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(221, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PedirNumFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 233);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.numFacturaCargar);
            this.Controls.Add(this.label1);
            this.Name = "PedirNumFactura";
            this.Text = "PedirNumFactura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numFacturaCargar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button button1;
    }
}