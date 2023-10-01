using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCobranza.ModelObjectCobranza
{
    internal class RolModel
    {

        //GET
        public List<RolUsuario> GetAll()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<RolUsuario> ListRolUser = db.RolUsuario.OrderBy(p => p.RolId).ToList();
                return ListRolUser;
            }
        }

        //Get by Id

        public string GetById(int id)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                RolUsuario ListRolUser = db.RolUsuario.Where(p => p.RolId == id).FirstOrDefault();
                return ListRolUser.Rol;
            }
        }

    }
}
