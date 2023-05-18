using api_librerias_paco.Models;

public interface ICarritoRepository
{
    CarritoDTO ObtenerCarritoPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearCarrito, ActualizarCarrito, EliminarCarrito, etc.
}