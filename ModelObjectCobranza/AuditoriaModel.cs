using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ModelObjectCobranza
{
    static class AuditoriaModel
    {
        
        static public List<AuditoriaSistema> GetAll()
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<AuditoriaSistema> ListaAudit = db.AuditoriaSistema.OrderByDescending(p =>p.IdAuditoria).ToList();
                return ListaAudit;
            }
        }
        static public List<AuditoriaSistema> GetFAll(string fechaInicio, string fechaFin, string sector, string usuario, string key)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var ListasAuditorias = db.AuditoriaSistema.AsEnumerable();
                var ListaFiltrada =
                    from n in ListasAuditorias
                    where (DateTime.Parse(n.Fecha) >= DateTime.Parse(fechaInicio) && DateTime.Parse(n.Fecha) >= DateTime.Parse(fechaInicio))
                    && ( n.Sector == sector ) && (n.Usuario == usuario) && (n.Campo.Contains(key))
                    orderby n.IdAuditoria descending
                    select n;

                return ListaFiltrada.ToList();
            }
        }

        static public void AgregarAuditoria(string usuario,string sector,string campo,string tipo, string nivel)
        {
            try
            {
                AuditoriaSistema aud = new AuditoriaSistema
                {
                    Usuario = usuario,
                    Sector = sector,
                    Campo = campo,
                    Tipo = tipo,
                    Nivel = nivel,
                    Fecha = DateTime.Now.ToString()
                };

                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    db.Add(aud);
                    db.SaveChanges();
                }

            }catch(Exception ex)
            {
                MessageBox.Show($"No se pudo agregar la auditoria. {ex}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

    }
}
