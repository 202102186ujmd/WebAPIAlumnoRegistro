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

        //insertar en NLog
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            this.UsuarioRepository = usuarioRepository;
            this._logger = logger;
        }


        [Apikey]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(UsuarioRepository.GetAll());
        }

        [HttpGet("GetbyEmail")]
        public ActionResult GetbyEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                _logger.LogError("El email no fue enviado");
                return BadRequest("El email no puede ser nulo");
            }
            else
            {
                return Ok(UsuarioRepository.GetbyEmail(email));
            }
        }




        [HttpGet("APIKey")]
        public ActionResult GetAPIKey()
        {
            var MiApiKeyToken = Guid.NewGuid().ToString();
            return Ok(MiApiKeyToken);
        }
    }
}
