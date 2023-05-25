using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using api_librerias_paco.Context;

using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        public LibrosController(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetLibros([FromQuery] string? orderBy = "")
        {
            IQueryable<Libros> librosQuery = _dbContext.Libro;

            if (orderBy == "PrecioAscendente")
            {
                librosQuery = librosQuery.OrderBy(l => l.Precio);
            }

            if (orderBy == "PrecioDescendente")
            {
                librosQuery = librosQuery.OrderByDescending(l => l.Precio);
            }

            if (orderBy == null)
            {
                var libros = await _dbContext.Libro.ToListAsync();

                // Mapea las entidades Libros a sus correspondientes DTO
                var librosDTO = libros.Select(l => new LibroDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Precio = l.Precio,
                    Autor = l.Autor,
                    Paginas = l.Paginas,
                    EnVenta = l.EnVenta,
                    FechaPublicacion = l.FechaPublicacion,
                    CategoriaId = l.CategoriaId
                });

                return Ok(librosDTO);
            }

            var librosOrdenados = await librosQuery.ToListAsync();

            // Mapea las entidades Libros a sus correspondientes DTO
            var librosOrdenadosDTO = librosOrdenados.Select(l => new LibroDTO
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Precio = l.Precio,
                Autor = l.Autor,
                Paginas = l.Paginas,
                EnVenta = l.EnVenta,
                FechaPublicacion = l.FechaPublicacion,
                CategoriaId = l.CategoriaId
            });

            return Ok(librosOrdenadosDTO);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDTO>> GetLibros(int id)
        {
            var idlibro = await _dbContext.Libro.FindAsync(id);

            if (idlibro == null)
            {
                return BadRequest("No se ha encontrado ningún libro con ese Id");
            }

            // Mapea la entidad Empleados a su correspondiente DTO
            var LibroDTO = new LibroDTO
            {
                Id = idlibro.Id,
                Titulo = idlibro.Titulo,
                Precio = idlibro.Precio,
                Autor = idlibro.Autor,
                Paginas = idlibro.Paginas,
                EnVenta = idlibro.EnVenta,
                FechaPublicacion = idlibro.FechaPublicacion,
                CategoriaId = idlibro.CategoriaId
            };

            return LibroDTO;
        }



        [HttpPost("")]
        public async Task<ActionResult<LibroDTO>> PostLibros(LibroDTO libroDTO)
        {
            // Realiza cualquier validación o transformación necesaria en el DTO antes de guardarlo en la base de datos

            var libro = new Libros
            {
                // Mapea los valores del DTO a una instancia de la entidad original Libros
                Titulo = libroDTO.Titulo,
                Precio = libroDTO.Precio,
                Autor = libroDTO.Autor,
                Paginas = libroDTO.Paginas,
                EnVenta = libroDTO.EnVenta,
                FechaPublicacion = libroDTO.FechaPublicacion,
                CategoriaId = libroDTO.CategoriaId
            };

            _dbContext.Libro.Add(libro);
            await _dbContext.SaveChangesAsync();

            // Mapea la entidad Libros creada a su correspondiente DTO
            var nuevoLibroDTO = new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                Autor = libro.Autor,
                Paginas = libro.Paginas,
                EnVenta = libro.EnVenta,
                FechaPublicacion = libro.FechaPublicacion,
                CategoriaId = libro.CategoriaId
            };

            return CreatedAtAction(nameof(GetLibros), new { id = nuevoLibroDTO.Id }, nuevoLibroDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, LibroDTO libroDTO)
        {
            if (id != libroDTO.Id)
            {
                return BadRequest();
            }

            var libro = await _dbContext.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            // Realiza cualquier validación o transformación necesaria en el DTO antes de actualizar la entidad

            // Actualiza los valores de la entidad original Libros con los valores del DTO
            libro.Titulo = libroDTO.Titulo;
            libro.Precio = libroDTO.Precio;
            libro.Autor = libroDTO.Autor;
            libro.Paginas = libroDTO.Paginas;
            libro.EnVenta = libroDTO.EnVenta;
            libro.FechaPublicacion = libroDTO.FechaPublicacion;
            libro.CategoriaId = libroDTO.CategoriaId;

            try
            {
                _dbContext.Libro.Update(libro);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibros(int id)
        {
            var libro = await _dbContext.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            _dbContext.Libro.Remove(libro);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("titulo/{titulo}")]
        public async Task<ActionResult<LibroDTO>> GetNombreLibros(string titulo)
        {
            var libro = await _dbContext.Libro.FirstOrDefaultAsync(l => l.Titulo == titulo);

            if (libro == null)
            {
                return BadRequest("No se ha encontrado ningún libro con este nombre");
            }

            // Mapea la entidad Libros a su correspondiente DTO
            var libroDTO = new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                Autor = libro.Autor,
                Paginas = libro.Paginas,
                EnVenta = libro.EnVenta,
                FechaPublicacion = libro.FechaPublicacion,
                CategoriaId = libro.CategoriaId
            };

            return libroDTO;
        }



    }
}

