using Microsoft.EntityFrameworkCore;
using WebAPIAlumnoRegistro.Controllers;

namespace WebAPIAlumnoRegistro.Models.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {

        #region Inyectar el DBContext
        private readonly DBContextRegistro Db;
        //insertar en NLog
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(DBContextRegistro db, ILogger<UsuarioRepository> logger)
        {
            this.Db = db;
            this._logger = logger;
        }
        #endregion

        public List<Usuario> GetAll()
        {
            return Db.Usuario.ToList();
        }

        public Usuario GetbyEmail(String email)
        {
            try
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
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
            }
            return new Usuario();
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
