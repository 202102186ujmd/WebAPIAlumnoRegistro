using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAlumnoRegistro.Authentication;
using WebAPIAlumnoRegistro.Models.Usuarios;

namespace WebAPIAlumnoRegistro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository UsuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }


        [Apikey]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(UsuarioRepository.GetAll());
        }
    }
}
