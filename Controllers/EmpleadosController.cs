using api_librerias_paco.Models;
using api_librerias_paco.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly ILogger<EmpleadosController> _logger;

        private readonly EmpleadoService _empleadosService;
        public EmpleadosController(LibreriaContext dbContext, EmpleadoService empleadosService, ILogger<EmpleadosController> logger)
        {
            _dbContext = dbContext;
            _empleadosService = empleadosService;
            _logger = logger;
        }

[HttpGet("")]
public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
{
    var empleados = await _dbContext.Empleados.ToListAsync();

    // Mapea las entidades Empleados a sus correspondientes DTO
    var empleadosDTO = empleados.Select(e => new EmpleadoDTO
    {
        Id = e.Id,
        Nombre = e.Nombre,
        Apellidos = e.Apellidos,
        Dni = e.Dni,
        Correo = e.Correo,
        Residencia = e.Residencia,
        Nacionalidad = e.Nacionalidad,
        TiendaId = e.TiendaId
    }).ToList();

    return empleadosDTO;
}

[HttpGet("{id}")]
public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
{
    var empleado = await _dbContext.Empleados.FindAsync(id);

    if (empleado == null)
    {
        return BadRequest("No se ha encontrado ningún empleado con ese Id");
    }

    // Mapea la entidad Empleado a su correspondiente DTO
    var empleadoDTO = new EmpleadoDTO
    {
        Id = empleado.Id,
        Nombre = empleado.Nombre,
        Apellidos = empleado.Apellidos,
        Dni = empleado.Dni,
        Correo = empleado.Correo,
        Residencia = empleado.Residencia,
        Nacionalidad = empleado.Nacionalidad,
        TiendaId = empleado.TiendaId
    };

    return empleadoDTO;
}

[HttpPost("")]
public async Task<ActionResult<EmpleadoDTO>> PostEmpleado(EmpleadoDTO empleadoDTO)
{
    // Realiza cualquier validación o transformación necesaria en el DTO antes de guardarlo en la base de datos

    var empleado = new Empleados
    {
        // Mapea los valores del DTO a una instancia de la entidad original Empleados
        Nombre = empleadoDTO.Nombre,
        Apellidos = empleadoDTO.Apellidos,
        Dni = empleadoDTO.Dni,
        Correo = empleadoDTO.Correo,
        Residencia = empleadoDTO.Residencia,
        Nacionalidad = empleadoDTO.Nacionalidad,
        TiendaId = empleadoDTO.TiendaId
    };

    _dbContext.Empleados.Add(empleado);
    await _dbContext.SaveChangesAsync();

    // Mapea la entidad Empleados creada a su correspondiente DTO
    var nuevoEmpleadoDTO = new EmpleadoDTO
    {
        Id = empleado.Id,
        Nombre = empleado.Nombre,
        Apellidos = empleado.Apellidos,
        Dni = empleado.Dni,
        Correo = empleado.Correo,
        Residencia = empleado.Residencia,
        Nacionalidad = empleado.Nacionalidad,
        TiendaId = empleado.TiendaId
    };

    return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleadoDTO.Id }, nuevoEmpleadoDTO);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutEmpleado(int id, EmpleadoDTO empleadoDTO)
{
    if (id != empleadoDTO.Id)
    {
        return BadRequest();
    }

    var empleado = await _dbContext.Empleados.FindAsync(id);

    if (empleado == null)
    {
        return NotFound();
    }

    // Realiza cualquier validación o transformación necesaria en el DTO antes de actualizar la entidad

    // Actualiza los valores de la entidad original Empleados con los valores del DTO
    empleado.Nombre = empleadoDTO.Nombre;
    empleado.Apellidos = empleadoDTO.Apellidos;
    empleado.Dni = empleadoDTO.Dni;
    empleado.Correo = empleadoDTO.Correo;
    empleado.Residencia = empleadoDTO.Residencia;
    empleado.Nacionalidad = empleadoDTO.Nacionalidad;
    empleado.TiendaId = empleadoDTO.TiendaId;

    try
    {
        _dbContext.Empleados.Update(empleado);
        await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        throw;
    }

    return Ok();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteEmpleado(int id)
{
    var empleado = await _dbContext.Empleados.FindAsync(id);

    if (empleado == null)
    {
        return NotFound();
    }

    _dbContext.Empleados.Remove(empleado);
    await _dbContext.SaveChangesAsync();

    return NoContent();
}


    }
}


