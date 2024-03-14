namespace NeoCobranza.Paneles
{
    partial class PnlAgregarProductoInd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarProductoInd));
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDinamico = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDinamico);
            this.panel3.Location = new System.Drawing.Point(-3, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 33);
            this.panel3.TabIndex = 97;
            // 
            // LblDinamico
            // 
            this.LblDinamico.AutoSize = true;
            this.LblDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDinamico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDinamico.Location = new System.Drawing.Point(22, 9);
            this.LblDinamico.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDinamico.Name = "LblDinamico";
            this.LblDinamico.Size = new System.Drawing.Size(144, 18);
            this.LblDinamico.TabIndex = 1;
            this.LblDinamico.Text = "Nombre Dinamico";
            // 
            // PnlAgregarProductoInd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "PnlAgregarProductoInd";
            this.Text = "Productos por Cantidad";
            this.Load += new System.EventHandler(this.PnlAgregarProductoInd_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label LblDinamico;
    }
}