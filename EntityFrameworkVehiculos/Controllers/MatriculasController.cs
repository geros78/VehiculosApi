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
    public class MatriculasController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public MatriculasController(VehiculosDbContext context)
        {
            _context = context;

        }

        // GET: api/<MatriculasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculasDTO>>> Get()
        {

            var matricula = await _context.Matriculas.Select(x =>
            new MatriculasDTO
            {
                //Id = x.Id,
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo

            }).ToListAsync();
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }
        }

        // GET api/<MatriculasController>/5
        [HttpGet("{Numero}")]
        public async Task<ActionResult<MatriculasDTO>> Get(string Numero)
        {
            var matricula = await _context.Matriculas.Select(x =>
            new MatriculasDTO
            {
                //Id = x.Id,
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo

            }).FirstOrDefaultAsync(x => x.Numero == Numero);
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }

        }
        // POST api/<MatriculasController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculasDTO matricula)
        {
            try
            {
                var entity = new Matriculas()
                {
                    //Id = matricula.Id,
                    Numero = matricula.Numero,
                    FechaExpedicion = matricula.FechaExpedicion,
                    ValidaHasta = matricula.ValidaHasta,
                    Activo = matricula.Activo

                };
                _context.Matriculas.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }

        // PUT api/<MatriculasController>/5
        [HttpPut("{Numero}")]
        public async Task<HttpStatusCode> Put(MatriculasDTO matricula)
        {
            try
            {
                var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Numero == matricula.Numero);
                //entity.Id = matricula.Id;
                entity.Numero = matricula.Numero;
                entity.FechaExpedicion = matricula.FechaExpedicion;
                entity.ValidaHasta= matricula.ValidaHasta;
                entity.Activo = matricula.Activo;
                

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return HttpStatusCode.Accepted;
        }

        // DELETE api/<MatriculasController>/5
        [HttpDelete("{Numero}")]
        public async Task<HttpStatusCode> Delete(string Numero)
        {
            try
            {
                var matricula = _context.Matriculas.Find(Numero);

                var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Numero == Numero);
                entity.Activo = false;
                _context.Entry(entity).State = EntityState.Modified;

                _context.Matriculas.Attach(entity);
                _context.Matriculas.Remove(entity);
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
