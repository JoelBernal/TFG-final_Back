using api_librerias_paco.Models;
using api_librerias_paco.Context;

using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;

        private readonly EmpleadoService _empleadosService;
        public EmpleadosController(LibreriaContext dbContext, EmpleadoService empleadosService)
        {
            _dbContext = dbContext;
            _empleadosService = empleadosService;
        }

        // GET: api/Empleados
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            if (_dbContext.Empleados == null)
            {
                return NotFound();
            }
            return await _dbContext.Empleados.ToListAsync();
        }

        // // GET Empleados de la base por id
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Empleados>> GetEmpleados(int id)
        // {

        //     ClienteDTO empleados = _empleadosService.ObtenerClientePorId(id);

        //     if (_dbContext.Empleados == null)
        //     {
        //         return NotFound();
        //     }
        //     var empleados = await _dbContext.Empleados.FindAsync(id);

        //     if (empleados == null)
        //     {
        //         return BadRequest("No se ha encontrado ningún cliente con ese Id");
        //     }
        //     return empleados;

        // }



        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleados(int id)
        {
            var empleados = await _dbContext.Empleados.FindAsync(id);

            if (empleados == null)
            {
                return BadRequest("No se ha encontrado ningún empleado con ese Id");
            }

            // Mapeo manual de Empleados a EmpleadosDTO
            var empleadoDTO = new EmpleadoDTO
            {
                // Asigna los valores de la entidad Empleados a las propiedades correspondientes del DTO
                Id = empleados.Id,
                Nombre = empleados.Nombre,
                // Asigna otros campos necesarios en el DTO
                // ...
            };

            return empleadoDTO;
        }




        [HttpPost("")]

        public async Task<ActionResult<Empleados>> PostEmpleados(Empleados empleados)
        {
            _dbContext.Empleados.Add(empleados);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmpleados), new { id = empleados.Id }, empleados);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleadoss([FromBody] Empleados empleados)
        {
            _dbContext.Entry(empleados).State = EntityState.Modified;

            try
            {
                _dbContext.Empleados.Update(empleados);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok();
        }

        private bool EmpleadosExists(long id)
        {
            return (_dbContext.Empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            if (_dbContext.Empleados == null)
            {
                return NotFound();
            }
            var empleados = await _dbContext.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            _dbContext.Empleados.Remove(empleados);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}


