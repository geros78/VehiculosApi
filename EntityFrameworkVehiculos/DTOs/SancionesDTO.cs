using EntityFrameworkVehiculos.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkVehiculos.DTOs
{
    public class SancionesDTO
    {

        [Key]
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string? Sancion { get; set; }
        public string? Observacion { get; set; }
        public decimal? Valor { get; set; }
        public string ConductorId { get; set; }

    }
}
