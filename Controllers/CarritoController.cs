// using api_librerias_paco.Models;
// using api_librerias_paco.Services;
// using Microsoft.AspNetCore.Mvc;
// using api_librerias_paco.Context;

// using Microsoft.EntityFrameworkCore;

// namespace api_librerias_paco.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class LibrosController : ControllerBase
//     {
//         private readonly LibreriaContext _dbContext;
//         public LibrosController(LibreriaContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         // GET: api/Libros
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Libros>>> GetLibros([FromQuery] string? orderBy = "")
//         {
//             IQueryable<Libros> librosQuery = _dbContext.Libro;


//             if (orderBy == "PrecioAscendente")
//             {
//                 librosQuery = librosQuery.OrderBy(l => l.Precio);
//             }

//             if (orderBy == "PrecioDescendente")
//             {
//                 librosQuery = librosQuery.OrderByDescending(l => l.Precio);
//             }

//             if (orderBy == null)
//             {
//                 return await _dbContext.Libro.ToListAsync();
//             }

//             var libros = await librosQuery.ToListAsync();

//             return Ok(libros);
//         }


//         // GET libros de la base por id
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Libros>> GetLibros(int id)
//         {
//             if (_dbContext.Libro == null)
//             {
//                 return BadRequest("No se ha encontrado ningún libro con ese Id");
//             }
//             var libro = await _dbContext.Libro.FindAsync(id);

//             if (libro == null)
//             {
//                 return BadRequest("No se ha encontrado ningún libro con ese Id");
//             }
//             return libro;

//         }



//         [HttpPost("")]

//         public async Task<ActionResult<Libros>> PostLibros(Libros libros)
//         {
//             _dbContext.Libro.Add(libros);
//             await _dbContext.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetLibros), new { id = libros.Id }, libros);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutClientes([FromBody] Libros libros)
//         {
//             _dbContext.Entry(libros).State = EntityState.Modified;

//             try
//             {
//                 _dbContext.Libro.Update(libros);
//                 await _dbContext.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {

//                 throw;
//             }
//             return Ok();
//         }

//         private bool LibrosExists(long id)
//         {
//             return (_dbContext.Libro?.Any(e => e.Id == id)).GetValueOrDefault();
//         }



//         [HttpDelete("{id}")]

//         public async Task<IActionResult> DeleteLibros(int id)
//         {
//             if (_dbContext.Libro == null)
//             {
//                 return NotFound();
//             }
//             var libro = await _dbContext.Libro.FindAsync(id);
//             if (libro == null)
//             {
//                 return NotFound();
//             }
//             _dbContext.Libro.Remove(libro);
//             await _dbContext.SaveChangesAsync();

//             return NoContent();
//         }


//         [HttpGet("titulo/{titulo}")]
//         public async Task<ActionResult<Libros>> GetNombreLibros(string titulo)
//         {

//             var libro = await _dbContext.Libro.FirstOrDefaultAsync(l => l.Titulo == titulo);

//             if (libro == null)
//             {
//                 return BadRequest("No se ha encontrado ningún libro con este nombre");
//             }

//             return libro;
//         }



//     }
// }

