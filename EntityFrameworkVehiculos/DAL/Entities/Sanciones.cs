using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EntityFrameworkVehiculos.DAL.Entities
{
    public class Sanciones
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string? Sancion { get; set; }
        public string? Observacion { get; set; }       
        public decimal? Valor { get; set; }
        public string ConductorId { get; set; }
        [ForeignKey("ConductorId")]
        public virtual Conductores Conductores { get; set; }

    }
}
