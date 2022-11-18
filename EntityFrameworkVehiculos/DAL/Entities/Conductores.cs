using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkVehiculos.DAL.Entities
{
    public class Conductores
    {
        //public int Id { get; set; }

        [Key]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(15, ErrorMessage = "Longitud maxima 15")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "Longitud maxima 20")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "Longitud maxima 20")]
        public string Apellido { get; set; }
        [StringLength(30, ErrorMessage = "Longitud maxima 30")]
        public string? Direccion { get; set; }
        [StringLength(15, ErrorMessage = "Longitud maxima 15")]
        public string? Telefono { get; set; }
        [StringLength(30, ErrorMessage = "Longitud maxima 30")]
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public string? NumeroMatricula { get; set; }
        [ForeignKey ("NumeroMatricula")]
        public virtual Matriculas Matriculas { get; set; }

    }
}
