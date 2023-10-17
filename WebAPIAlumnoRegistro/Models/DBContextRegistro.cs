using Microsoft.EntityFrameworkCore;
using WebAPIAlumnoRegistro.Models.Alumno;
using WebAPIAlumnoRegistro.Models.CentroComputo;
using WebAPIAlumnoRegistro.Models.Usuarios;

namespace WebAPIAlumnoRegistro.Models
{
    public class DBContextRegistro : DbContext
    {
        public DBContextRegistro(DbContextOptions<DBContextRegistro> options) : base(options)
        {

        }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Laboratorios> Laboratorios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
