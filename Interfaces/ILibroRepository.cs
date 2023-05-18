using api_librerias_paco.Models;

public interface ILibroRepository
{
    LibroDTO ObtenerLibroPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearLibro, ActualizarLibro, EliminarLibro, etc.
}