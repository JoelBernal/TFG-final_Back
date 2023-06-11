using api_librerias_paco.Models;
using api_librerias_paco.Services;
using api_librerias_paco.Context;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendasController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly ILogger<TiendasController> _logger;
        public TiendasController(LibreriaContext dbContext, ILogger<TiendasController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/Tiendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaDTO>>> GetTiendas([FromQuery] string? orderBy = "")
        {
            IQueryable<Tiendas> tiendasQuery = _dbContext.Tiendas;

            if (orderBy == null)
            {
                var tiendas = await _dbContext.Tiendas.ToListAsync();

                // Mapea las entidades Tiendas a sus correspondientes DTO
                var tiendasDTO = tiendas.Select(t => new TiendaDTO
                {
                    Id = t.Id,
                    Comunidad = t.Comunidad,
                    Localidad = t.Localidad,
                    Calle = t.Calle,
                    CodigoPostal = t.Codigopostal,
                    Trabajadores = t.Trabajadores,
                    HorarioAtencion = t.HorarioAtencion,
                    // LibroId = t.LibroId
                });

                return Ok(tiendasDTO);
            }

            if (orderBy == "MasTrabajadores")
            {
                tiendasQuery = tiendasQuery.OrderByDescending(t => t.Trabajadores);
            }

            if (orderBy == "MenosTrabajadores")
            {
                tiendasQuery = tiendasQuery.OrderBy(t => t.Trabajadores);
            }

            var tiendasOrdenadas = await tiendasQuery.ToListAsync();

            // Mapea las entidades Tiendas ordenadas a sus correspondientes DTO
            var tiendasOrdenadasDTO = tiendasOrdenadas.Select(t => new TiendaDTO
            {
                Id = t.Id,
                Comunidad = t.Comunidad,
                Localidad = t.Localidad,
                Calle = t.Calle,
                CodigoPostal = t.Codigopostal,
                Trabajadores = t.Trabajadores,
                HorarioAtencion = t.HorarioAtencion,
                // LibroId = t.LibroId
            });

            return Ok(tiendasOrdenadasDTO);
        }

        // GET tiendas de la base por id
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaDTO>> GetTiendas(int id)
        {
            var tienda = await _dbContext.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return BadRequest("No hay ninguna tienda con ese Id asignado");
            }

            // Mapea la entidad Tiendas a su correspondiente DTO
            var tiendaDTO = new TiendaDTO
            {
                Id = tienda.Id,
                Comunidad = tienda.Comunidad,
                Localidad = tienda.Localidad,
                Calle = tienda.Calle,
                CodigoPostal = tienda.Codigopostal,
                Trabajadores = tienda.Trabajadores,
                HorarioAtencion = tienda.HorarioAtencion,
                // LibroId = tienda.LibroId
            };

            return tiendaDTO;
        }

        [HttpPost("")]
        public async Task<ActionResult<TiendaDTO>> PostTiendas(TiendaDTO tiendaDTO)
        {
            // Realiza cualquier validación o transformación necesaria en el DTO antes de guardarlo en la base de datos

            var tienda = new Tiendas
            {
                // Mapea los valores del DTO a una instancia de la entidad original Tiendas
                Comunidad = tiendaDTO.Comunidad,
                Localidad = tiendaDTO.Localidad,
                Calle = tiendaDTO.Calle,
                Codigopostal = tiendaDTO.CodigoPostal,
                Trabajadores = tiendaDTO.Trabajadores,
                HorarioAtencion = tiendaDTO.HorarioAtencion,
                // LibroId = tiendaDTO.LibroId
            };

            _dbContext.Tiendas.Add(tienda);
            await _dbContext.SaveChangesAsync();

            // Mapea la entidad Tiendas creada a su correspondiente DTO
            var nuevaTiendaDTO = new TiendaDTO
            {
                Id = tienda.Id,
                Comunidad = tienda.Comunidad,
                Localidad = tienda.Localidad,
                Calle = tienda.Calle,
                CodigoPostal = tienda.Codigopostal,
                Trabajadores = tienda.Trabajadores,
                HorarioAtencion = tienda.HorarioAtencion,
                // LibroId = tienda.LibroId
            };

            return CreatedAtAction(nameof(GetTiendas), new { id = nuevaTiendaDTO.Id }, nuevaTiendaDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendas(int id, TiendaDTO tiendaDTO)
        {
            if (id != tiendaDTO.Id)
            {
                return BadRequest();
            }

            var tienda = await _dbContext.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }

            // Realiza cualquier validación o transformación necesaria en el DTO antes de actualizar la entidad

            // Actualiza los valores de la entidad original Tiendas con los valores del DTO
            tienda.Comunidad = tiendaDTO.Comunidad;
            tienda.Localidad = tiendaDTO.Localidad;
            tienda.Calle = tiendaDTO.Calle;
            tienda.Codigopostal = tiendaDTO.CodigoPostal;
            tienda.Trabajadores = tiendaDTO.Trabajadores;
            tienda.HorarioAtencion = tiendaDTO.HorarioAtencion;
            // tienda.LibroId = tiendaDTO.LibroId;

            try
            {
                _dbContext.Tiendas.Update(tienda);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }


        private bool TiendasExists(long id)
        {
            return (_dbContext.Tiendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiendas(int id)
        {
            var tienda = await _dbContext.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }

            _dbContext.Tiendas.Remove(tienda);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}

