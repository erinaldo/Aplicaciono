namespace Aplicaciono.MenuPrincipal
{
    partial class MenuPrincipalForm
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
            this.btnGenerarFact = new System.Windows.Forms.Button();
            this.btnGenerarGastos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerarFact
            // 
            this.btnGenerarFact.Location = new System.Drawing.Point(80, 34);
            this.btnGenerarFact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarFact.Name = "btnGenerarFact";
            this.btnGenerarFact.Size = new System.Drawing.Size(168, 35);
            this.btnGenerarFact.TabIndex = 0;
            this.btnGenerarFact.Text = "Generar Factura";
            this.btnGenerarFact.UseVisualStyleBackColor = true;
            this.btnGenerarFact.Click += new System.EventHandler(this.btnGenerarFact_Click);
            // 
            // btnGenerarGastos
            // 
            this.btnGenerarGastos.Location = new System.Drawing.Point(80, 100);
            this.btnGenerarGastos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarGastos.Name = "btnGenerarGastos";
            this.btnGenerarGastos.Size = new System.Drawing.Size(168, 35);
            this.btnGenerarGastos.TabIndex = 1;
            this.btnGenerarGastos.Text = "Generar Gasto";
            this.btnGenerarGastos.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(80, 167);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(168, 35);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Gestión Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(80, 233);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "Gestión Impuestos";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(80, 301);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(168, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Datos Usuario";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonUsuarios_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 379);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnGenerarGastos);
            this.Controls.Add(this.btnGenerarFact);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MenuPrincipalForm";
            this.Text = "MenuPrincipalView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarFact;
        private System.Windows.Forms.Button btnGenerarGastos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}