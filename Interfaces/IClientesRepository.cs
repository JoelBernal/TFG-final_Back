using api_librerias_paco.Models;

public interface IClientesRepository
{
    Clientes ObtenerClientePorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearCliente, ActualizarCliente, EliminarCliente, etc.
}