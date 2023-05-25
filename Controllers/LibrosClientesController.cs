
using api_librerias_paco.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Services;
using api_librerias_paco.Models;

namespace api_librerias_paco.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class LibrosClientesController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly LibroClienteService _libroClienteService;

        public LibrosClientesController(LibreriaContext dbContext, LibroClienteService libroClienteService)
        {
            _dbContext = dbContext;
            _libroClienteService = libroClienteService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LibrosClientesDTO>> GetLibros(int id)
        {
            var iduser = await _dbContext.LibrosClientes.FindAsync(id);

            if (iduser == null)
            {
                return BadRequest("No se ha encontrado ningún registro con ese Id");
            }

            var LibrosClienteDTO = new LibrosClientesDTO
            {
                Id = iduser.Id,
                IdCliente = iduser.IdCliente,
                Idlibro = iduser.Idlibro,
                NombreLibro = iduser.NombreLibro,
            };

            return LibrosClienteDTO;
        }

        [HttpGet("/{idCliente}")]
        public async Task<ActionResult<IEnumerable<LibrosClientesDTO>>> GetLibrosIdCliente(int idCliente)
        {
            var librosDelCliente = await _dbContext.LibrosClientes
                .Where(lc => lc.IdCliente == idCliente)
                .ToListAsync();

            if (!librosDelCliente.Any())
            {
                return NotFound("No se ha encontrado ningún libro para el cliente con ese Id");
            }

            var librosClienteDTO = librosDelCliente.Select(lc => new LibrosClientesDTO
            {
                Id = lc.Id,
                IdCliente = lc.IdCliente,
                Idlibro = lc.Idlibro,
                NombreLibro = lc.NombreLibro,
            }).ToList();

            return Ok(librosClienteDTO);
        }



        [HttpPost]
        public async Task<ActionResult<LibrosClientesDTO>> PostLibroCliente(LibrosClientesDTO librosClientesDTO)
        {
            var libro = await _dbContext.Libro.FindAsync(librosClientesDTO.Idlibro);
            var cliente = await _dbContext.Clientes.FindAsync(librosClientesDTO.IdCliente);

            if (libro == null || cliente == null)
            {
                return BadRequest("Libro o cliente no encontrado");
            }

            var librosClientes = new LibrosClientes
            {
                IdCliente = librosClientesDTO.IdCliente,
                Idlibro = librosClientesDTO.Idlibro,
                NombreLibro = librosClientesDTO.NombreLibro,
            };

            _dbContext.LibrosClientes.Add(librosClientes);
            await _dbContext.SaveChangesAsync();

            librosClientesDTO.Id = librosClientes.Id;

            return CreatedAtAction(nameof(GetLibros), new { id = librosClientesDTO.Id }, librosClientesDTO);
        }



    }
}