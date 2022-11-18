using EntityFrameworkVehiculos.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkVehiculos.DTOs
{
    public class ConductoresDTO
    {
        //public int Id { get; set; }       
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public string? NumeroMatricula { get; set; }


        
    }
}
