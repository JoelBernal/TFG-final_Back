using api_librerias_paco.Models;

public interface ICarritoRepository
{
    Carrito ObtenerCarritoPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearCarrito, ActualizarCarrito, EliminarCarrito, etc.
}