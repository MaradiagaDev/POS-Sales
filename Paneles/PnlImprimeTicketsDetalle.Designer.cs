namespace NeoCobranza.Paneles
{
    partial class PnlImprimeTicketsDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlImprimeTicketsDetalle));
            this.lblCredito = new System.Windows.Forms.Label();
            this.DgvItemsOrden = new System.Windows.Forms.DataGridView();
            this.BtnImprimir = new NeoCobranza.Especiales.EspecialButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.BackColor = System.Drawing.Color.CadetBlue;
            this.lblCredito.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.ForeColor = System.Drawing.Color.White;
            this.lblCredito.Location = new System.Drawing.Point(12, 9);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Padding = new System.Windows.Forms.Padding(10);
            this.lblCredito.Size = new System.Drawing.Size(259, 38);
            this.lblCredito.TabIndex = 170;
            this.lblCredito.Text = "Historial de Productos en Orden";
            // 
            // DgvItemsOrden
            // 
            this.DgvItemsOrden.AllowUserToAddRows = false;
            this.DgvItemsOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvItemsOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvItemsOrden.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvItemsOrden.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvItemsOrden.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvItemsOrden.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvItemsOrden.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.DgvItemsOrden.Location = new System.Drawing.Point(12, 61);
            this.DgvItemsOrden.Name = "DgvItemsOrden";
            this.DgvItemsOrden.ReadOnly = true;
            this.DgvItemsOrden.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsOrden.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvItemsOrden.RowHeadersWidth = 15;
            this.DgvItemsOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItemsOrden.Size = new System.Drawing.Size(940, 453);
            this.DgvItemsOrden.TabIndex = 171;
            this.DgvItemsOrden.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItemsOrden_CellContentClick_1);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImprimir.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnImprimir.BackGroundColor = System.Drawing.Color.DarkGreen;
            this.BtnImprimir.BorderColor = System.Drawing.Color.Transparent;
            this.BtnImprimir.BorderRadius = 0;
            this.BtnImprimir.BorderSize = 0;
            this.BtnImprimir.FlatAppearance.BorderSize = 0;
            this.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(778, 531);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(174, 49);
            this.BtnImprimir.TabIndex = 172;
            this.BtnImprimir.Text = "Imprimir Ticket";
            this.BtnImprimir.TextGroundColor = System.Drawing.Color.White;
            this.BtnImprimir.UseVisualStyleBackColor = false;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // PnlImprimeTicketsDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 589);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.DgvItemsOrden);
            this.Controls.Add(this.lblCredito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(980, 628);
            this.MinimumSize = new System.Drawing.Size(980, 628);
            this.Name = "PnlImprimeTicketsDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de impresiones Individuales";
            this.Load += new System.EventHandler(this.PnlImprimeTicketsDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCredito;
        public System.Windows.Forms.DataGridView DgvItemsOrden;
        private Especiales.EspecialButton BtnImprimir;
    }
}