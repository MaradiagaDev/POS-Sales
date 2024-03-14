using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ModelObjectCobranza
{
    internal class UserModel
    {
        public class UserModelClass
        {
            public int IdUsuarios { get; set; }
            public string Nombre { get; set; }
            public DateTime? FechaCreacion { get; set; }
            public string Rol { get; set; }
            public string Estado { get; set; }
            public string PrimerNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string Pass { get; set; }
            public string SucursalId { get; set; }
        }

        //GET
        public List<UserModelClass> GetAll()
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> ListUser = db.Usuario.OrderBy(p => p.IdUsuarios).ToList();

                List<UserModelClass> userFinal = new List<UserModelClass>();

                foreach(Usuario u in ListUser)
                {
                    Sucursales sucursal = db.Sucursales.Where(s => s.SucursalId == u.SucursalId).FirstOrDefault();

                    if(sucursal != null)
                    {
                        UserModelClass userModelClass = new UserModelClass() 
                        {
                         IdUsuarios = u.IdUsuarios,
                         Nombre = u.Nombre,
                         FechaCreacion = u.FechaCreacion,
                         Rol= u.Rol,
                         Estado = u.Estado,
                         PrimerApellido = u.PrimerApellido,
                         PrimerNombre = u.PrimerNombre,
                         Pass = u.Pass,
                         SucursalId = sucursal.NombreSucursal
                        };

                        userFinal.Add(userModelClass);
                        
                    }
                }

                return userFinal;
            }
        }

        //GET FIND BY
        //ID
        public List<Usuario> GetById( string id)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> ListUser = db.Usuario.Where(p => p.IdUsuarios.ToString() == id).ToList();
                return ListUser;
            }
        }
        //Usuario
        public List<Usuario> GetByUser(string user)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> ListUser = db.Usuario.Where(p => p.Nombre.Contains(user)).ToList();
                return ListUser;
            }
        }
        //Primer Nombre
        public List<Usuario> GetByPNombre(string PNombre)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> ListUser = db.Usuario.Where(p => p.PrimerNombre.Contains(PNombre)).ToList();
                return ListUser;
            }
        }
        //Primer Apellido
        public List<Usuario> GetByPApellido(string PApellido)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> ListUser = db.Usuario.Where(p => p.Nombre.Contains(PApellido)).ToList();
                return ListUser;
            }
        }

        //Cambio de estado

        public void PutEstado(int id)
        {
            try
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Usuario usuario = db.Usuario.Where(p => p.IdUsuarios == id).FirstOrDefault();

                    if (usuario.Estado == "Habilitado")
                    {
                        usuario.Estado = "Inhabilitado";
                    }
                    else
                    {
                        usuario.Estado = "Habilitado";
                    }

                    db.Update(usuario);
                    db.SaveChanges();
                }
            }catch(Exception ex)
            {
                MessageBox.Show($" Error: {ex}", "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void putUsuario(Usuario usuario)
        {
            try
            {
                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    db.Update(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Error: {ex}", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //Post
        public void PostUser(Usuario userInt)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Usuario> usuarios = db.Usuario.ToList();
                foreach(Usuario user in usuarios)
                {
                    if(user.Nombre == userInt.Nombre)
                    {
                        MessageBox.Show($" No se puede repetir el nombre de usuario.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        return;
                    }
                }

                db.Add(userInt);
                db.SaveChanges();
            }
        }

        

    }
}
