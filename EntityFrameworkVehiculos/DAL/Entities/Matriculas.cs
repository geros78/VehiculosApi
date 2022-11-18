using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkVehiculos.DAL.Entities
{
    public class Matriculas
    {
        
        //public int Id { get; set; }        
        [Key]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "Longitud maxima 20")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaExpedicion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }

        
    }
}
