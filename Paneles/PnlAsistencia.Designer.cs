namespace NeoCobranza.Paneles
{
    partial class PnlAsistencia
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
            this.BtnEntrada = new System.Windows.Forms.Button();
            this.BtnSalida = new System.Windows.Forms.Button();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEntrada
            // 
            this.BtnEntrada.BackColor = System.Drawing.Color.Green;
            this.BtnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.BtnEntrada.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnEntrada.Location = new System.Drawing.Point(19, 44);
            this.BtnEntrada.Name = "BtnEntrada";
            this.BtnEntrada.Size = new System.Drawing.Size(287, 214);
            this.BtnEntrada.TabIndex = 0;
            this.BtnEntrada.Text = "ENTRADA";
            this.BtnEntrada.UseVisualStyleBackColor = false;
            this.BtnEntrada.Click += new System.EventHandler(this.BtnEntrada_Click);
            // 
            // BtnSalida
            // 
            this.BtnSalida.BackColor = System.Drawing.Color.Maroon;
            this.BtnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSalida.Location = new System.Drawing.Point(331, 44);
            this.BtnSalida.Name = "BtnSalida";
            this.BtnSalida.Size = new System.Drawing.Size(287, 214);
            this.BtnSalida.TabIndex = 1;
            this.BtnSalida.Text = "SALIDA";
            this.BtnSalida.UseVisualStyleBackColor = false;
            this.BtnSalida.Click += new System.EventHandler(this.BtnSalida_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblUsuario.Location = new System.Drawing.Point(17, 9);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(57, 20);
            this.LblUsuario.TabIndex = 2;
            this.LblUsuario.Text = "label1";
            // 
            // Salir
            // 
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Salir.Location = new System.Drawing.Point(456, 6);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(162, 32);
            this.Salir.TabIndex = 3;
            this.Salir.Text = "Cancelar";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // PnlAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(637, 284);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.BtnSalida);
            this.Controls.Add(this.BtnEntrada);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlAsistencia";
            this.Load += new System.EventHandler(this.PnlAsistencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEntrada;
        private System.Windows.Forms.Button BtnSalida;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Button Salir;
    }
}