using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class CarritoService : ICarritoRepository
{
    private readonly LibreriaContext _dbContext;

    public CarritoService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CarritoDTO ObtenerCarritoPorId(int id)
    {
        Carrito carrito = _dbContext.Carrito.FirstOrDefault(c => c.Id == id);
        CarritoDTO carritoDTO = ConvertirACarritoDTO(carrito);
        return carritoDTO;
    }

    private CarritoDTO ConvertirACarritoDTO(Carrito carrito)
    {
        return new CarritoDTO
        {
            Id = carrito.Id,
            PrecioTotal = carrito.PrecioTotal,
            CantidadProductos = carrito.CantidadProductos,
            EstadoCarrito = carrito.EstadoCarrito,
            MetodosPago = carrito.MetodosPago
        };
    }
}