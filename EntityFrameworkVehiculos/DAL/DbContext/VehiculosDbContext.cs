
namespace EntityFrameworkVehiculos.DAL.DbContext
{

    using EntityFrameworkVehiculos.DAL.Entities;
    using Microsoft.EntityFrameworkCore;

    public class VehiculosDbContext : DbContext
    {
        public VehiculosDbContext(DbContextOptions<VehiculosDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<Matriculas> Matriculas { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
    }
}
