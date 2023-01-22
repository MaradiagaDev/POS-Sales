using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.DataController;
using NeoCobranza.Data;
using NeoCobranza.Clases;
using NeoCobranza.Clases_de_Contrato;

namespace NeoCobranza.Paneles
{
    public partial class PnlBeneficiario : Form
    {
        public CBeneficiario cBeneficiario;
        public CGeneral cGeneral;
        public Conexion conexion;

       
        public Ataudes ataudes;
        
        public PnlBeneficiario(Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            cGeneral = new CGeneral(conexion);
            cBeneficiario = new CBeneficiario(conexion);
            ataudes= new Ataudes(conexion);

            Contrato contratos = new Contrato(conexion);

            cmbAtaudes.DataSource = contratos.Mostrar_Todos_Nombres();
            cmbAtaudes.ValueMember = "NombreEstandar";

            //Inicializacion del panel de contrato
           


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            lblPn.clear();
            lblSN.clear();
            lblPA.clear();
            lblSA.clear();
            lblCedula.Text="";
            lblProfesion.clear();
            cmbAtaudes.SelectedIndex = 0;
            txtDireccion.clear();
            txtObservaciones.clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sexo = "Desconocido";

            //Vericaciones necesarias con respecto a los beneficiarios

            if (cmbAtaudes.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado ningun Ataud para el beneficiario","Error");
                return;
            }

            if(lblCedula.Text == "")
            {
                MessageBox.Show("La cedula es un campo requerido", "Error");
                return;
            }

            if (lblPn.Texts == "")
            {
                MessageBox.Show("El primer nombre es un campo requerido", "Error");
                return;
            }
            if(lblPA.Texts == "")
            {
                MessageBox.Show("El primer apellido es un campo requerido", "Error");
                return;
            }




            if(rbtnFemenino.Checked == true)
            {
                sexo = "Femenino";
            }
            if(rbtnMasculino.Checked == true)
            {
                sexo = "Masculino";
            }

            ProformaContrato proformaContrato = new ProformaContrato(conexion);
            PnlContrato pnlContrato = Owner as PnlContrato;

            //Verificar que la cedula no sea igual a cualquiera de los otros beneficiarios

            for(int i =0;i < pnlContrato.dgvBenficiarios.Rows.Count; i++)
            {
                if (pnlContrato.dgvBenficiarios.Rows[i].Cells[4].Value.ToString() == lblCedula.Text)
                {
                    MessageBox.Show("El numero de cedula ya pertenece a uno de los beneficiarios", "Error");
                    return;

                }


            }


            pnlContrato.dgvBenficiarios.Rows.Add(lblPn.Texts,lblSN.Texts,lblPA.Texts,lblSA.Texts,
                lblCedula.Text,lblProfesion.Texts,txtDireccion.Texts,txtObservaciones.Texts,lblFecha.Text,
                sexo,cmbDepartamento.Text,cmbAtaudes.Text, proformaContrato.Obtener_Precio_Nombre(cmbAtaudes.SelectedValue.ToString()));


            this.Close();
        }

                
            

        private void PnlBeneficiario_Load(object sender, EventArgs e)
        {

        }
    }
}
