namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnConvABinario = new System.Windows.Forms.Button();
            this.btnConvADecimal = new System.Windows.Forms.Button();
            this.txtBoxNum1 = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtBoxNum2 = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(12, 119);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(119, 36);
            this.btnOperar.TabIndex = 3;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(137, 119);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnConvABinario
            // 
            this.btnConvABinario.Location = new System.Drawing.Point(75, 161);
            this.btnConvABinario.Name = "btnConvABinario";
            this.btnConvABinario.Size = new System.Drawing.Size(119, 36);
            this.btnConvABinario.TabIndex = 6;
            this.btnConvABinario.Text = "Convertir a Binario";
            this.btnConvABinario.UseVisualStyleBackColor = true;
            this.btnConvABinario.Click += new System.EventHandler(this.btnConvABinario_Click);
            // 
            // btnConvADecimal
            // 
            this.btnConvADecimal.Location = new System.Drawing.Point(200, 161);
            this.btnConvADecimal.Name = "btnConvADecimal";
            this.btnConvADecimal.Size = new System.Drawing.Size(119, 36);
            this.btnConvADecimal.TabIndex = 7;
            this.btnConvADecimal.Text = "Convertir a Decimal";
            this.btnConvADecimal.UseVisualStyleBackColor = true;
            this.btnConvADecimal.Click += new System.EventHandler(this.btnConvADecimal_Click);
            // 
            // txtBoxNum1
            // 
            this.txtBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNum1.Location = new System.Drawing.Point(12, 60);
            this.txtBoxNum1.Name = "txtBoxNum1";
            this.txtBoxNum1.Size = new System.Drawing.Size(134, 38);
            this.txtBoxNum1.TabIndex = 0;
            // 
            // lblResultado
            // 
            this.lblResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(9, 18);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(369, 38);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxNum2
            // 
            this.txtBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNum2.Location = new System.Drawing.Point(248, 59);
            this.txtBoxNum2.Name = "txtBoxNum2";
            this.txtBoxNum2.Size = new System.Drawing.Size(137, 38);
            this.txtBoxNum2.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(262, 119);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(119, 36);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(152, 59);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(90, 39);
            this.cmbOperator.TabIndex = 1;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 220);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtBoxNum2);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtBoxNum1);
            this.Controls.Add(this.btnConvADecimal);
            this.Controls.Add(this.btnConvABinario);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1";
            this.Text = "Calculadora de Selene ABraldez del curso 2ºA";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnConvABinario;
        private System.Windows.Forms.Button btnConvADecimal;
        private System.Windows.Forms.TextBox txtBoxNum1;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtBoxNum2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbOperator;
    }
}

