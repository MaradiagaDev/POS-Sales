namespace NeoCobranza.Paneles_ComprasComercial
{
    partial class PnlProductoNuevo
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
            this.PnlNuevaCompra = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemision = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoSerie = new System.Windows.Forms.TextBox();
            this.PnlNuevaCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlNuevaCompra
            // 
            this.PnlNuevaCompra.Controls.Add(this.label2);
            this.PnlNuevaCompra.Controls.Add(this.txtNoSerie);
            this.PnlNuevaCompra.Controls.Add(this.label6);
            this.PnlNuevaCompra.Controls.Add(this.textBox1);
            this.PnlNuevaCompra.Controls.Add(this.label9);
            this.PnlNuevaCompra.Controls.Add(this.txtRemision);
            this.PnlNuevaCompra.Controls.Add(this.label7);
            this.PnlNuevaCompra.Location = new System.Drawing.Point(1, 1);
            this.PnlNuevaCompra.Name = "PnlNuevaCompra";
            this.PnlNuevaCompra.Size = new System.Drawing.Size(411, 167);
            this.PnlNuevaCompra.TabIndex = 108;
            this.PnlNuevaCompra.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlNuevaCompra_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 137;
            this.label6.Text = "Color: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 136;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 133;
            this.label9.Text = "NoRemision: ";
            // 
            // txtRemision
            // 
            this.txtRemision.Location = new System.Drawing.Point(127, 81);
            this.txtRemision.Name = "txtRemision";
            this.txtRemision.Size = new System.Drawing.Size(236, 20);
            this.txtRemision.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(318, 24);
            this.label7.TabIndex = 99;
            this.label7.Text = "Digite la informacion de compra: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 140;
            this.label2.Text = "NoSerie: ";
            // 
            // txtNoSerie
            // 
            this.txtNoSerie.Location = new System.Drawing.Point(127, 120);
            this.txtNoSerie.Name = "txtNoSerie";
            this.txtNoSerie.Size = new System.Drawing.Size(236, 20);
            this.txtNoSerie.TabIndex = 139;
            // 
            // PnlProductoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(413, 167);
            this.Controls.Add(this.PnlNuevaCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlProductoNuevo";
            this.Text = "PnlProductoNuevo";
            this.PnlNuevaCompra.ResumeLayout(false);
            this.PnlNuevaCompra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlNuevaCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtRemision;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNoSerie;
    }
}