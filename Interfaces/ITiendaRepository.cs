using api_librerias_paco.Models;

public interface ITiendaRepository
{
    TiendaDTO ObtenerTiendaPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearTienda, ActualizarTienda, EliminarTienda, etc.
}