using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class LibroService : ILibroRepository
{
    private readonly LibreriaContext _dbContext;

    public LibroService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public LibroDTO ObtenerLibroPorId(int id)
    {
        Libros libro = _dbContext.Libro.FirstOrDefault(c => c.Id == id);
        LibroDTO libroDTO = ConvertirALibroDTO(libro);
        return libroDTO;
    }

    private LibroDTO ConvertirALibroDTO(Libros libro)
{
    return new LibroDTO
    {
        Id = libro.Id,
        Titulo = libro.Titulo,
        Autor = libro.Autor,
        Precio = libro.Precio,
        Paginas = libro.Paginas,
        EnVenta = libro.EnVenta,
        FechaPublicacion = libro.FechaPublicacion,
        ISBN = libro.ISBN,
        Imagen = libro.Imagen,
    };
}

}