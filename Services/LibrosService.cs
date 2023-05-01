using api_librerias_paco.Models;

public class LibroService
{
    private readonly ILibroRepository _libroRepository;

    public LibroService(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public LibroDTO ObtenerLibroPorId(int id)
    {
        Libros libro = _libroRepository.ObtenerLibroPorId(id);
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
        FechaPublicacion = libro.FechaPublicacion
    };
}

}