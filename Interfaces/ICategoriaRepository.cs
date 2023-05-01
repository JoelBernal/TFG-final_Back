using api_librerias_paco.Models;

public interface ICategoriaRepository
{
    Categorias ObtenerCategoriaPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearCategoria, ActualizarCategoria, EliminarCategoria, etc.
}