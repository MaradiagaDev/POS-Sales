using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMClientes
    {
        public void InitModuloCrearCliente(PanelCliente frm,string option)
        {
            switch(option)
            {
                case "Crear":
                    frm.cmbPais.SelectedIndex = 0;
                    frm.cmbDepartamento.SelectedIndex = 0;
                    frm.rbtnSoltero.Checked = true;
                    frm.rbtnMasculino.Checked = true;
                    break;
            }
        }

        public void Verificaciones(PanelCliente frm, string option) 
        {
            switch (option)
            {
                case "Crear":

                    //Comprobaciones del crear cliente
                    if (frm.lblPn.Texts.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe digitar el primer nombre del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if(frm.lblPA.Texts.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe digitar el primer apellido del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if(frm.mtxtCedula.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe digitar el primer apellido del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (frm.mtxtCedula.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe digitar la cedula del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FuncionesPrincipales(frm, "Crear");

                    break;
            }
        }

        public void FuncionesPrincipales(PanelCliente frm, string option)
        {
            switch(option)
            {
                case "Crear":

                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        //Calculo de la edad 

                        DateTime fechaNacimiento = frm.lblFecha.Value;
                        DateTime fechaActual = DateTime.Now;

                        int edad = fechaActual.Year - fechaNacimiento.Year;

                        Clientes cliente = new Clientes()
                        {
                            Pnombre = frm.lblPn.Texts.Trim(),
                            Snombre = frm.lblSN.Texts.Trim(),
                            Papellido = frm.lblPA.Texts.Trim(),
                            Sapellido = frm.lblSA.Texts.Trim(),
                            Estado = 0,
                            Direccion = frm.txtDireccion.Text.Trim(),
                            Telefono = frm.mtxtTelefono.Text.Trim(),
                            Celular = frm.mtxtCelular.Text.Trim(),
                            Fax = "",
                            Edad = edad,
                            EstadoCivil = frm.rbtnCasado.Checked == true ? "Casado" : "Soltero",
                            Profesion = frm.lblProfesion.Text.Trim(),
                            Sexo = frm.rbtnMasculino.Checked == true ? "Masculino" : "Femenino",
                            Cedula = frm.mtxtCedula.Text.Trim(),
                            FechaNac = frm.lblFecha.Value,
                            Email = frm.mtxtEmail.Text.Trim(),
                            Departamento = frm.cmbDepartamento.Text.Trim(),
                            Pais = frm.cmbPais.Text.Trim(),
                            Observacion = frm.txtObservacion.Text.Trim(),
                        };

                        db.Add(cliente);
                        db.SaveChanges();

                        frm.Close();
                    }

                    break;
            }
        }
    }
}
