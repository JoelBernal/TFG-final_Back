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
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _dbContext.Clientes.ToListAsync();

            // Mapea las entidades Clientes a sus correspondientes DTO
            var clientesDTO = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Correo = c.Correo,
                Contrasenya = c.Contrasenya,
                NombreUser = c.NombreUser,
                Rol = c.Rol,
                Saldo = c.Saldo,
                FechaCreacion = c.FechaCreacion
            }).ToList();

            return clientesDTO;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            // Mapea la entidad Cliente a su correspondiente DTO
            var clienteDTO = new ClienteDTO
            {
                Id = cliente.Id,
                Correo = cliente.Correo,
                Contrasenya = cliente.Contrasenya,
                NombreUser = cliente.NombreUser,
                Rol = cliente.Rol,
                Saldo = cliente.Saldo,
                FechaCreacion = cliente.FechaCreacion
            };

            return clienteDTO;
        }

        [HttpPost("")]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO clienteDTO)
        {
            // Realiza cualquier validación o transformación necesaria en el DTO antes de guardarlo en la base de datos
            Console.WriteLine(clienteDTO.FechaCreacion);
            Console.WriteLine("---------------------------------------------------------------");
            var cliente = new Clientes
            {
                // Mapea los valores del DTO a una instancia de la entidad original Clientes
                Correo = clienteDTO.Correo,
                Contrasenya = clienteDTO.Contrasenya,
                NombreUser = clienteDTO.NombreUser,
                Rol = clienteDTO.Rol,
                Saldo = clienteDTO.Saldo,
            };

            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();

            // Mapea la entidad Cliente creada a su correspondiente DTO
            var nuevoClienteDTO = new ClienteDTO
            {
                Id = cliente.Id,
                Correo = cliente.Correo,
                Contrasenya = cliente.Contrasenya,
                NombreUser = cliente.NombreUser,
                Rol = cliente.Rol,
                Saldo = cliente.Saldo,
            };

            return CreatedAtAction(nameof(GetCliente), new { id = nuevoClienteDTO.Id }, nuevoClienteDTO);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<int>> Login([FromBody] Dictionary<string, string> values)
        {
            if (!values.TryGetValue("correo", out string correo) || !values.TryGetValue("contrasenya", out string contrasenya))
            {
                return BadRequest("Los campos 'correo' y 'contrasenya' son requeridos.");
            }
            int id = _clientesService.Login(correo, contrasenya);
            if(id == 0){
                return NotFound("Usuario no encontrado");
            }
            return id;


        } 



        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.Id)
            {
                return BadRequest();
            }

            var cliente = await _dbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            // Realiza cualquier validación o transformación necesaria en el DTO antes de actualizar la entidad

            // Actualiza los valores de la entidad original Clientes con los valores del DTO
            cliente.Correo = clienteDTO.Correo;
            cliente.Contrasenya = clienteDTO.Contrasenya;
            cliente.NombreUser = clienteDTO.NombreUser;
            cliente.Rol = clienteDTO.Rol;
            cliente.Saldo = clienteDTO.Saldo;
            cliente.FechaCreacion = clienteDTO.FechaCreacion;

            try
            {
                _dbContext.Clientes.Update(cliente);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        // DELETE: api/Clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
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



