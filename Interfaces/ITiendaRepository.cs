using api_librerias_paco.Models;

public interface ITiendaRepository
{
    Tiendas ObtenerTiendaPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearTienda, ActualizarTienda, EliminarTienda, etc.
}