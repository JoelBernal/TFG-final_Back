using api_librerias_paco.Models;

public class ClientesService
{
    private readonly IClientesRepository _clientesRepository;

    public ClientesService(IClientesRepository clientesRepository)
    {
        _clientesRepository = clientesRepository;
    }

    public ClienteDTO ObtenerClientePorId(int id)
    {
        Clientes cliente = _clientesRepository.ObtenerClientePorId(id);
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
            FechaCreacion = cliente.FechaCreacion,
            // Agrega más campos si es necesario
        };
    }
}