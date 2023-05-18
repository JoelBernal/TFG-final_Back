using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class ClientesService : IClientesRepository
{

    private readonly LibreriaContext _dbContext;

    public ClientesService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ClienteDTO ObtenerClientePorId(int id)
    {
        Clientes cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == id);
        ClienteDTO clienteDTO = ConvertirAClienteDTO(cliente);
        return clienteDTO;
    }


    private ClienteDTO ConvertirAClienteDTO(Clientes cliente)
    {
        // Lógica de conversión aquí
        // Ejemplo:
        return new ClienteDTO
        {
            Id = cliente.Id,
            Correo = cliente.Correo,
            Contrasenya = cliente.Contrasenya,
            NombreUser = cliente.NombreUser,
            Saldo = cliente.Saldo,
            Rol = cliente.Rol,
            FechaCreacion = cliente.FechaCreacion,
            // Agrega más campos si es necesario
        };
    }
}