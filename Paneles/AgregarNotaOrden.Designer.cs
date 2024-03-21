namespace NeoCobranza.Paneles
{
    partial class AgregarNotaOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarNotaOrden));
            this.btnGuardarNota = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNotaOrden = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGuardarNota
            // 
            this.btnGuardarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnGuardarNota.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGuardarNota.BackGroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGuardarNota.BorderColor = System.Drawing.Color.Lime;
            this.btnGuardarNota.BorderRadius = 5;
            this.btnGuardarNota.BorderSize = 0;
            this.btnGuardarNota.FlatAppearance.BorderSize = 0;
            this.btnGuardarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNota.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardarNota.ForeColor = System.Drawing.Color.White;
            this.btnGuardarNota.Location = new System.Drawing.Point(617, 403);
            this.btnGuardarNota.Name = "btnGuardarNota";
            this.btnGuardarNota.Size = new System.Drawing.Size(173, 35);
            this.btnGuardarNota.TabIndex = 163;
            this.btnGuardarNota.Text = "Guardar Nota";
            this.btnGuardarNota.TextGroundColor = System.Drawing.Color.White;
            this.btnGuardarNota.UseVisualStyleBackColor = false;
            this.btnGuardarNota.Click += new System.EventHandler(this.btnGuardarNota_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 5;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(434, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 164;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 167;
            this.label3.Text = "Nota en Orden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 18);
            this.label2.TabIndex = 166;
            this.label2.Text = "*Escriba una pequeña explicación o detalle acerca de la orden.*";
            // 
            // TxtNotaOrden
            // 
            this.TxtNotaOrden.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNotaOrden.Location = new System.Drawing.Point(12, 63);
            this.TxtNotaOrden.Multiline = true;
            this.TxtNotaOrden.Name = "TxtNotaOrden";
            this.TxtNotaOrden.Size = new System.Drawing.Size(778, 250);
            this.TxtNotaOrden.TabIndex = 165;
            // 
            // AgregarNotaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNotaOrden);
            this.Controls.Add(this.btnGuardarNota);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "AgregarNotaOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota en Orden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Especiales.EspecialButton btnGuardarNota;
        public Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNotaOrden;
    }
}