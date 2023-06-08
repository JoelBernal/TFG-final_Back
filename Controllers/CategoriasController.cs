using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using api_librerias_paco.Context;

using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly ILogger<CategoriasController> _logger;
        public CategoriasController(LibreriaContext dbContext, ILogger<CategoriasController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            var categorias = await _dbContext.Categorias.ToListAsync();

            // Mapea las entidades Categorias a sus correspondientes DTO
            var categoriasDTO = categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                EdadRecomendada = c.EdadRecomendada,
                Imagen = c.Imagen
            });

            return Ok(categoriasDTO);
        }

        // GET: api/Categorias/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            // Mapea la entidad Categoria a su correspondiente DTO
            var categoriaDTO = new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                EdadRecomendada = categoria.EdadRecomendada,
                Imagen = categoria.Imagen
            };

            return categoriaDTO;
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoriaDTO)
        {
            // Realiza cualquier validación o transformación necesaria en el DTO antes de guardarlo en la base de datos

            var categoria = new Categorias
            {
                // Mapea los valores del DTO a una instancia de la entidad original Categorias
                Nombre = categoriaDTO.Nombre,
                Descripcion = categoriaDTO.Descripcion,
                EdadRecomendada = categoriaDTO.EdadRecomendada,
                Imagen = categoriaDTO.Imagen
            };

            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();

            // Mapea la entidad Categoria creada a su correspondiente DTO
            var nuevaCategoriaDTO = new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                EdadRecomendada = categoria.EdadRecomendada,
                Imagen = categoria.Imagen
            };

            return CreatedAtAction(nameof(GetCategoria), new { id = nuevaCategoriaDTO.Id }, nuevaCategoriaDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
            {
                return BadRequest();
            }

            var categoria = await _dbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            // Realiza cualquier validación o transformación necesaria en el DTO antes de actualizar la entidad

            // Actualiza los valores de la entidad original Categorias con los valores del DTO
            categoria.Nombre = categoriaDTO.Nombre;
            categoria.Descripcion = categoriaDTO.Descripcion;
            categoria.EdadRecomendada = categoriaDTO.EdadRecomendada;
            categoria.Imagen = categoriaDTO.Imagen;

            try
            {
                _dbContext.Categorias.Update(categoria);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        // DELETE: api/Categorias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _dbContext.Categorias.Remove(categoria);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}

