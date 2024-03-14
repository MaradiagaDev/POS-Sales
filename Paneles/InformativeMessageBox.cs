using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NeoCobranza.Paneles
{
    public partial class InformativeMessageBox : Form
    {
        public InformativeMessageBox(string message, string title, int displayTime)
        {
            InitializeComponent();

            LblTitle.Text  = title;
            TxtBody.Text = message;
            // Ajustar la posición del formulario
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 10, Screen.PrimaryScreen.WorkingArea.Height - Height - 10);
            TxtBody.Select(0, 0);
            this.Focus();
            Task.Delay(displayTime).ContinueWith(t =>
            {
                if (!IsDisposed && !Disposing)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Close();
                    });
                }
            });
        }
    }
}
