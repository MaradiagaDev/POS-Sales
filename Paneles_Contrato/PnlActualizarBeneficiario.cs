using NeoCobranza.Clases;
using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Contrato
{
    public partial class PnlActualizarBeneficiario : Form
    {

        private Conexion conexion;
        private int idPublico;
        private Contrato contrato;

        private string NombreValor;
        private string NoCedulaValor;
        private int idContratoP;
        public PnlActualizarBeneficiario(Conexion conexion, int id,int idContrato)
        {
            InitializeComponent();

            //
            this.conexion = conexion;
            this.idPublico = id;
            this.contrato = new Contrato(conexion);
            this.idContratoP = idContrato;
             

            //LLenar datos
           txtPrimerNombre.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][6].ToString();
           txtSegundoNombre.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][7].ToString();
           txtPrimerApellido.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][8].ToString();
            txtSegundoApellido.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][9].ToString();
            lblCedula.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][1].ToString();
            lblFecha.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][2].ToString();

            txtDireccion.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][4].ToString();
            txtObservacion.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][5].ToString();

            cmbDepartamento.Text = contrato.Contrato_Informacion_Beneficiario(id).Rows[0][11].ToString();

            NombreValor = txtPrimerNombre.Text +" "+txtSegundoNombre.Text+" "+txtPrimerApellido.Text+" "+txtSegundoApellido.Text;
            this.NoCedulaValor = lblCedula.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verificaciones
            if (txtPrimerNombre.Text == "")
            {
                MessageBox.Show("Debe digitar el primer nombre","Error");
            }
            if (txtPrimerNombre.Text == "")
            {
                MessageBox.Show("Debe digitar el primer Apellido", "Error");
                return;
            }
            if (lblCedula.Text == "")
            {
                MessageBox.Show("Debe digitar el primer nombre", "Error");
                return;
            }

            string sexo ="Desconocido";

            if (rbtnFemenino.Checked)
            {
                sexo = "Femenino";
            }else if (rbtnMasculino.Checked)
            {
                sexo = "Masculino";
            }

            contrato.Contrato_Insertar_Historial("Actualizacion de beneficiario","Nombre anterior: "+NombreValor+" NoCedulaAnterior: "+NoCedulaValor+" Con id: "+idPublico.ToString(),conexion.usuario,idContratoP);

            contrato.AgregarBeneficiario(txtPrimerNombre.Text,txtSegundoNombre.Text,
                txtPrimerApellido.Text,txtSegundoApellido.Text,lblFecha.Text,txtObservacion.Text,sexo,txtDireccion.Text,lblCedula.Text,
                cmbDepartamento.Text,int.Parse(txtIdBeneficiario.Text));

            MessageBox.Show("Beneficiario Actualizado","Correcto");
            this.Close();
        }
    }
}
