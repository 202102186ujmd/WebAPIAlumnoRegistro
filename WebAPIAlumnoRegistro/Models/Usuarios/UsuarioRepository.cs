using Microsoft.EntityFrameworkCore;

namespace WebAPIAlumnoRegistro.Models.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {

        #region Inyectar el DBContext
        private readonly DBContextRegistro Db;

        public UsuarioRepository(DBContextRegistro db)
        {
            this.Db = db;
        }
        #endregion

        public List<Usuario> GetAll()
        {
            return Db.Usuario.ToList();
        }

        public Usuario GetbyEmail(String email)
        {
            var usuariobyemail = Db.Usuario.Where(s => s.Email == email).FirstOrDefault();
            if (usuariobyemail != null)
            {
                return usuariobyemail;
            }
            else
            {
                return new Usuario();
            }
        }

        public bool Login(Usuario usuario)
        {
            var usuariobyemail = Db.Usuario.Where(s => s.Email == usuario.Email).FirstOrDefault();
            if (usuariobyemail != null)
            {

                //verificar que el password sea el mismo
                if (usuariobyemail.Password == usuario.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
            
        }
    }
    
}
