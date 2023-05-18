using api_librerias_paco.Models;
using api_librerias_paco.Context;

using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;

        private readonly ClientesService _clientesService;
        public ClientesController(LibreriaContext dbContext, ClientesService clientesService)
        {
            _dbContext = dbContext;
            _clientesService = clientesService;
        }

        // GET: api/Clientes
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            if (_dbContext.Clientes == null)
            {
                return NotFound();
            }
            return await _dbContext.Clientes.ToListAsync();
        }

        // GET clientes de la base por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {

            ClienteDTO clientes = _clientesService.ObtenerClientePorId(id);

            if (_dbContext.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _dbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return BadRequest("No se ha encontrado ningún cliente con ese Id");
            }
            return cliente;

        }

        [HttpPost("")]

        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            _dbContext.Clientes.Add(clientes);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClientes), new { id = clientes.Id }, clientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes([FromBody] Clientes clientes)
        {
            _dbContext.Entry(clientes).State = EntityState.Modified;

            try
            {
                _dbContext.Clientes.Update(clientes);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok();
        }

        private bool ClientesExists(long id)
        {
            return (_dbContext.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (_dbContext.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}


