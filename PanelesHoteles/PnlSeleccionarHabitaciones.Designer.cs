﻿namespace NeoCobranza.PanelesHoteles
{
    partial class PnlSeleccionarHabitaciones
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
            this.FLHabitaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.FLConjunto = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCostosConjunto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLHabitaciones
            // 
            this.FLHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLHabitaciones.Location = new System.Drawing.Point(286, 69);
            this.FLHabitaciones.Name = "FLHabitaciones";
            this.FLHabitaciones.Size = new System.Drawing.Size(799, 444);
            this.FLHabitaciones.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 51);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(84, 11);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(101, 28);
            this.label2.TabIndex = 97;
            this.label2.Text = "CONJUNTO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(286, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 51);
            this.panel2.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(284, 11);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(242, 28);
            this.label1.TabIndex = 97;
            this.label1.Text = "HABITACIONES DEL CONJUNTO";
            // 
            // FLConjunto
            // 
            this.FLConjunto.Location = new System.Drawing.Point(12, 69);
            this.FLConjunto.Name = "FLConjunto";
            this.FLConjunto.Size = new System.Drawing.Size(261, 497);
            this.FLConjunto.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.CmbCostosConjunto);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(286, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 47);
            this.panel3.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(177, 28);
            this.label3.TabIndex = 98;
            this.label3.Text = "SELECCIONAR COSTO";
            // 
            // CmbCostosConjunto
            // 
            this.CmbCostosConjunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCostosConjunto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.CmbCostosConjunto.FormattingEnabled = true;
            this.CmbCostosConjunto.Location = new System.Drawing.Point(221, 11);
            this.CmbCostosConjunto.Name = "CmbCostosConjunto";
            this.CmbCostosConjunto.Size = new System.Drawing.Size(555, 26);
            this.CmbCostosConjunto.TabIndex = 99;
            // 
            // PnlSeleccionarHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1097, 578);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.FLConjunto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FLHabitaciones);
            this.MaximumSize = new System.Drawing.Size(1113, 617);
            this.MinimumSize = new System.Drawing.Size(1113, 617);
            this.Name = "PnlSeleccionarHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Habitaciones";
            this.Load += new System.EventHandler(this.PnlSeleccionarHabitaciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLHabitaciones;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FLConjunto;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbCostosConjunto;
    }
}