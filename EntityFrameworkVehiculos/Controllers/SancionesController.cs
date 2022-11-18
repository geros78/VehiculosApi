using EntityFrameworkVehiculos.DAL.DbContext;
using EntityFrameworkVehiculos.DAL.Entities;
using EntityFrameworkVehiculos.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkVehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionesController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public SancionesController(VehiculosDbContext context)
        {
            _context = context;

        }

        // GET: api/<SancionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {

            var sancion = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                //Id = x.Id,
                Id = x.Id,
                FechaActual = x.FechaActual,
                Sancion = x.Sancion,
                Observacion = x.Observacion,
                Valor = x.Valor,
                ConductorId = x.ConductorId

            }).ToListAsync();
            if (sancion == null)
            {
                return NotFound();
            }
            else
            {
                return sancion;
            }
        }

        // GET api/<SancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            var matricula = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                //Id = x.Id,
                Id = x.Id,
                FechaActual = x.FechaActual,
                Sancion = x.Sancion,
                Observacion = x.Observacion,
                Valor = x.Valor,
                ConductorId = x.ConductorId

            }).FirstOrDefaultAsync(x => x.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }

        }

        // POST api/<SancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sancion )
        {
            try
            {
                var entity = new Sanciones()
                {
                    //Id = matricula.Id,
                    Id = sancion.Id,
                    FechaActual = DateTime.Now,
                    Sancion = sancion.Sancion,
                    Observacion = sancion.Observacion,
                    Valor = sancion.Valor,
                    ConductorId = sancion.ConductorId

                };
                _context.Sanciones.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }

        // PUT api/<SancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sancion)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.Id == sancion.Id);
                //entity.Id = matricula.Id;
                entity.Id = sancion.Id;
                entity.FechaActual = DateTime.Now;
                entity.Sancion = sancion.Sancion;
                entity.Observacion = sancion.Observacion;
                entity.Valor = sancion.Valor;
                entity.ConductorId = sancion.ConductorId;


                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return HttpStatusCode.Accepted;
        }

        // DELETE api/<SancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var entity = new Sanciones()
                {
                    Id = id
                };

                _context.Sanciones.Attach(entity);
                _context.Sanciones.Remove(entity);
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
