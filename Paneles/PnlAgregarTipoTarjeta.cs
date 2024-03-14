using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarTipoTarjeta : Form
    {
        public DataTable auxTablaDinamica = new DataTable();
        string auxKey = "";
        string auxOpc = "";

        public PnlAgregarTipoTarjeta(string opc, string key)
        {
            InitializeComponent();
            this.auxKey = key;
            auxOpc = opc;
        }

        private void PnlAgregarTipoTarjeta_Load(object sender, EventArgs e)
        {
            if (auxTablaDinamica.Columns.Count == 0)
            {
                auxTablaDinamica.Columns.Add("Id", typeof(string));
                auxTablaDinamica.Columns.Add("Banco", typeof(string));

                dgvSucursalesProductos.DataSource = auxTablaDinamica;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Bancos> listBancos = db.Bancos.Where(c => c.Estado == "Activo").OrderByDescending(c => c.BancoId).ToList();
                CmbBancos.ValueMember = "BancoId";
                CmbBancos.DisplayMember = "Banco";
                CmbBancos.DataSource = listBancos;
            }

            if (auxOpc == "Crear")
            {
                btnAgregar.Text = "Guardar";
                LblNombreDinamico.Text = "Crear Tipo Tarjeta";
            }
            else
            {
                btnAgregar.Text = "Modificar";
                LblNombreDinamico.Text = "Modificar Tipo Tarjeta";

                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    TipoTarjeta tipo = db.TipoTarjeta.Where(s => s.TipoTarjetaId == int.Parse(auxKey)).FirstOrDefault();
                    var lista = db.RelBancoTipo.Where(s => s.TarjetaTipoId == tipo.TipoTarjetaId).ToList();

                    TxtNombre.Text = tipo.NombreTipo.ToString();
                    foreach(var item in lista)
                    {
                        Bancos banco = db.Bancos.Where(s => s.BancoId == item.BancoId).FirstOrDefault();

                        auxTablaDinamica.Rows.Add(banco.BancoId,banco.Banco);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregarBanco_Click(object sender, EventArgs e)
        {
            if (CmbBancos.Items.Count > 0)
            {
                foreach (DataRow row in auxTablaDinamica.Rows)
                {
                    if (row[0].ToString() == CmbBancos.SelectedValue.ToString())
                    {
                        MessageBox.Show("El Banco seleccionado ya ha sido agregado.", "Atención",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                auxTablaDinamica.Rows.Add(CmbBancos.SelectedValue.ToString(), CmbBancos.Text);
            }
            else
            {
                MessageBox.Show("Debe agregar un Banco en la sección de Catalogo para realizar esta acción.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnQuitarBanco_Click(object sender, EventArgs e)
        {
            if (dgvSucursalesProductos.SelectedRows.Count > 0)
            {
                auxTablaDinamica.Rows.RemoveAt(dgvSucursalesProductos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Banco en la lista para quitarlo.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FuncionesPrincipales();
        }

        public void FuncionesPrincipales()
        {
            if (TxtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe digitar el Nombre de Tipo Tarjeta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (auxTablaDinamica.Rows.Count == 0)
            {
                MessageBox.Show("Debe asignarle al menos un banco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxOpc == "Crear")
                {
                    TipoTarjeta tipo = new TipoTarjeta()
                    {
                        NombreTipo = TxtNombre.Text.Trim(),
                        Estado = "Activo"
                    };

                    db.Add(tipo);
                    db.SaveChanges();

                    foreach (DataRow row in auxTablaDinamica.Rows)
                    {
                        RelBancoTipo rel = new RelBancoTipo();

                        rel.TarjetaTipoId = tipo.TipoTarjetaId;
                        rel.BancoId = int.Parse(row[0].ToString());

                        db.Add(rel);
                        db.SaveChanges();
                    }
                }
                else
                {
                    TipoTarjeta tipo = db.TipoTarjeta.Where(s => s.TipoTarjetaId == int.Parse(auxKey)).FirstOrDefault();

                    if (tipo != null)
                    {
                        tipo.NombreTipo = TxtNombre.Text.Trim();
                        db.Update(tipo);

                        List<RelBancoTipo> list = db.RelBancoTipo.Where(p => p.TarjetaTipoId == tipo.TipoTarjetaId).ToList();

                        foreach (DataRow row in auxTablaDinamica.Rows)
                        {
                            RelBancoTipo rel = new RelBancoTipo();
                            rel.TarjetaTipoId = tipo.TipoTarjetaId;
                            rel.BancoId = int.Parse(row[0].ToString());
                            db.Add(rel);
                        }

                        foreach (var item in list)
                        {
                            db.Remove(item);
                        }

                        db.SaveChanges();

                        
                    }

                }
                this.Close();
            }
        }
    }
}
