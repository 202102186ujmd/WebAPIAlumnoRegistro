using System.ComponentModel.DataAnnotations;

namespace WebAPIAlumnoRegistro.Models.Usuarios
{
    public class Usuario
    {
        [Key]
        [EmailAddress(ErrorMessage = "Email is not valid")]//validad que sea la estructura de un email)]
        [StringLength(150, ErrorMessage = "El email excede los limites ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El password es obligatorio"), StringLength(50, ErrorMessage = "El password excede los limites ")]
        public string? Password { get; set; }
    }
}
