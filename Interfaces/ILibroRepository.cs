using api_librerias_paco.Models;

public interface ILibroRepository
{
    Libros ObtenerLibroPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearLibro, ActualizarLibro, EliminarLibro, etc.
}