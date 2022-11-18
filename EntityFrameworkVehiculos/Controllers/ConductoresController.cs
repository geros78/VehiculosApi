using EntityFrameworkVehiculos.DAL.DbContext;
using EntityFrameworkVehiculos.DAL.Entities;
using EntityFrameworkVehiculos.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkVehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public ConductoresController(VehiculosDbContext context)
        {
            _context = context;

        }
        // GET: api/<ConuctoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductoresDTO>>> Get()
        {

            var conductor = await _context.Conductores.Select(x =>
            new ConductoresDTO
            {
                //Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Direccion = x.Direccion,
                Telefono= x.Telefono,
                Email= x.Email,
                FechaNacimiento= x.FechaNacimiento,
                Activo= x.Activo,
                NumeroMatricula = x.NumeroMatricula
                

            }).ToListAsync();
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }

        // GET api/<ConuctoresController>/5
        [HttpGet("{Identificacion}")]
        public async Task<ActionResult<ConductoresDTO>> Get(string Identificacion)
        {
            var conductor = await _context.Conductores.Select(x =>
            new ConductoresDTO
            {
                //Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                NumeroMatricula = x.NumeroMatricula

            }).FirstOrDefaultAsync(x => x.Identificacion == Identificacion);
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }

        }

        // POST api/<ConuctoresController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductoresDTO conductor)
        {
            try
            {
                var entity = new Conductores()
                {
                    //Id = conductor.Id,
                    Identificacion = conductor.Identificacion,
                    Nombre = conductor.Nombre,
                    Apellido = conductor.Apellido,
                    Direccion = conductor.Direccion,
                    Telefono = conductor.Telefono,
                    Email = conductor.Email,
                    FechaNacimiento = conductor.FechaNacimiento,
                    Activo = conductor.Activo,
                    NumeroMatricula = conductor.NumeroMatricula


                };
                _context.Conductores.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }

        // PUT api/<ConuctoresController>/5
        [HttpPut("{Identificacion}")]
        public async Task<HttpStatusCode> Put(ConductoresDTO conductor)
        {
            try
            {
                var entity = await _context.Conductores.FirstOrDefaultAsync(v => v.Identificacion == conductor.Identificacion);
                    //entity.Id = matricula.Id;
                    entity.Identificacion = conductor.Identificacion;
                    entity.Nombre = conductor.Nombre;
                    entity.Apellido = conductor.Apellido;
                    entity.Direccion = conductor.Direccion;
                    entity.Telefono = conductor.Telefono;
                    entity.Email = conductor.Email;
                    entity.FechaNacimiento = conductor.FechaNacimiento;
                    entity.Activo = conductor.Activo;
                    entity.NumeroMatricula = conductor.NumeroMatricula;


                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return HttpStatusCode.Accepted;
        }

        // DELETE api/<ConuctoresController>/5
        [HttpDelete("{Identificacion}")]
        public async Task<HttpStatusCode> Delete(string Identificacion)
        {
            try
            {
                var conductor = _context.Conductores.Find(Identificacion);

                var entity = await _context.Conductores.FirstOrDefaultAsync(v => v.Identificacion == Identificacion);
                entity.Activo = false;
                _context.Entry(entity).State = EntityState.Modified;

                _context.Conductores.Attach(entity);
                _context.Conductores.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return HttpStatusCode.OK;
        }
    }
}
