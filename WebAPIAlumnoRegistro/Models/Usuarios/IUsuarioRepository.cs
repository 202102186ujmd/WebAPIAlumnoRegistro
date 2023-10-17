namespace WebAPIAlumnoRegistro.Models.Usuarios
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();

        Usuario GetbyEmail(string email);

        bool Login(Usuario usuario);
    }
}
