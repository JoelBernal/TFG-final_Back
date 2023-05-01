using api_librerias_paco.Models;

public class CarritoService
{
    private readonly ICarritoRepository _carritoRepository;

    public CarritoService(ICarritoRepository carritoRepository)
    {
        _carritoRepository = carritoRepository;
    }

    public CarritoDTO ObtenerCarritoPorId(int id)
    {
        Carrito carrito = _carritoRepository.ObtenerCarritoPorId(id);
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