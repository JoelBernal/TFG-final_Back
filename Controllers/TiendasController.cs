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
        public TiendasController(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Tiendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiendas>>> GetTiendas([FromQuery] string? orderBy = "")
        {
            IQueryable<Tiendas> tiendasQuery = _dbContext.Tiendas;

            if (orderBy == null)
            {
                return await _dbContext.Tiendas.ToListAsync();
            }

            if (orderBy == "MasTrabajadores")
            {
                tiendasQuery = tiendasQuery.OrderByDescending(t => t.Trabajadores);
            }

            if (orderBy == "MenosTrabajadores")
            {
                tiendasQuery = tiendasQuery.OrderBy(t => t.Trabajadores);
            }

            var donOmar = await tiendasQuery.ToListAsync();

            return Ok(donOmar);
        }

        // GET clientes de la base por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiendas>> GetTiendas(int id)
        {
            if (_dbContext.Tiendas == null)
            {
                return BadRequest("No hay ninguna tienda con ese Id asignado");
            }
            var tienda = await _dbContext.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return BadRequest("No hay ninguna tienda con ese Id asignado");
            }
            return tienda;

        }

        [HttpPost("")]

        public async Task<ActionResult<Tiendas>> PostTiendas(Tiendas tiendas)
        {
            _dbContext.Tiendas.Add(tiendas);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTiendas), new { id = tiendas.Id }, tiendas);
        }

        [HttpPut("")]
        public async Task<IActionResult> PutClientes([FromBody] Tiendas tiendas)
        {
            _dbContext.Entry(tiendas).State = EntityState.Modified;

            try
            {
                _dbContext.Tiendas.Update(tiendas);
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
            if (_dbContext.Tiendas == null)
            {
                return NotFound();
            }
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

