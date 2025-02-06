namespace NeoCobranza.Paneles
{
    partial class PnlIngresosPagosCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlIngresosPagosCaja));
            this.BtnPagarEfectivo = new NeoCobranza.Especiales.EspecialButton();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtReferencia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnPagarEfectivo
            // 
            this.BtnPagarEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPagarEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnPagarEfectivo.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnPagarEfectivo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnPagarEfectivo.BorderRadius = 5;
            this.BtnPagarEfectivo.BorderSize = 0;
            this.BtnPagarEfectivo.FlatAppearance.BorderSize = 0;
            this.BtnPagarEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagarEfectivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagarEfectivo.ForeColor = System.Drawing.Color.White;
            this.BtnPagarEfectivo.Image = ((System.Drawing.Image)(resources.GetObject("BtnPagarEfectivo.Image")));
            this.BtnPagarEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPagarEfectivo.Location = new System.Drawing.Point(12, 327);
            this.BtnPagarEfectivo.Name = "BtnPagarEfectivo";
            this.BtnPagarEfectivo.Size = new System.Drawing.Size(233, 46);
            this.BtnPagarEfectivo.TabIndex = 232;
            this.BtnPagarEfectivo.Text = "Confirmar";
            this.BtnPagarEfectivo.TextGroundColor = System.Drawing.Color.White;
            this.BtnPagarEfectivo.UseVisualStyleBackColor = false;
            this.BtnPagarEfectivo.Click += new System.EventHandler(this.BtnPagarEfectivo_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(12, 39);
            this.TxtTotal.MaximumSize = new System.Drawing.Size(234, 29);
            this.TxtTotal.MinimumSize = new System.Drawing.Size(234, 29);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(234, 29);
            this.TxtTotal.TabIndex = 233;
            this.TxtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotal_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 234;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 235;
            this.label2.Text = "Tipo ";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Items.AddRange(new object[] {
            "INGRESO",
            "GASTO"});
            this.CmbTipo.Location = new System.Drawing.Point(12, 107);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(233, 32);
            this.CmbTipo.TabIndex = 236;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 238;
            this.label3.Text = "Referencia";
            // 
            // TxtReferencia
            // 
            this.TxtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReferencia.Location = new System.Drawing.Point(12, 181);
            this.TxtReferencia.Multiline = true;
            this.TxtReferencia.Name = "TxtReferencia";
            this.TxtReferencia.Size = new System.Drawing.Size(234, 108);
            this.TxtReferencia.TabIndex = 237;
            // 
            // PnlIngresosPagosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtReferencia);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.BtnPagarEfectivo);
            this.Name = "PnlIngresosPagosCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresos / Gastos Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Especiales.EspecialButton BtnPagarEfectivo;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtReferencia;
    }
}