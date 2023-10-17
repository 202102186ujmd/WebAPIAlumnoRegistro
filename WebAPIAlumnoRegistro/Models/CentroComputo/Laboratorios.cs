using System.ComponentModel.DataAnnotations;

namespace WebAPIAlumnoRegistro.Models.CentroComputo
{
    public class Laboratorios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio"), StringLength(100, ErrorMessage = "El nombre excede los limites ")]
        public string? Nombre { get; set; }
        public int? NumeroEspacio { get; set; }
    }
}
