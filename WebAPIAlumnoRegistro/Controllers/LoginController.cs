using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAlumnoRegistro.Models.Usuarios;

namespace WebAPIAlumnoRegistro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository UsuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }


        [HttpPost]
        public ActionResult<bool> Login([FromBody] Usuario usuario)
        {
            var respuesta = UsuarioRepository.Login(usuario);
            if (respuesta == true)
            {
                return Ok("Login Exitoso");
            }
            else
            {
                return Ok("Login Fallo");
            }
        }

    }
}
