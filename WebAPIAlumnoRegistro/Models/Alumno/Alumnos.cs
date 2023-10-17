using System.ComponentModel.DataAnnotations;

namespace WebAPIAlumnoRegistro.Models.Alumno
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }
        [StringLength(9,ErrorMessage = "Carnet es invalido")]
        public int Carnet { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio"), StringLength(100, ErrorMessage = "El nombre excede los limites ")]
        public string? Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Email is not valid")]//validad que sea la estructura de un email
        public string? Email { get; set; }
        [Required(ErrorMessage = "La facultad es obligatoria"),StringLength(100, ErrorMessage = "La Facultad excede los limites ")]
        public string? Facultad { get; set; }

    }
}
