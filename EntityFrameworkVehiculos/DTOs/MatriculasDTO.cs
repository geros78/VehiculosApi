using EntityFrameworkVehiculos.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkVehiculos.DTOs
{
    public class MatriculasDTO
    {
        
        //public int Id { get; set; }        
        public string Numero { get; set; }        
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }
        
    }
}
