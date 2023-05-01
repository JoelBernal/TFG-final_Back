using api_librerias_paco.Models;

public class TiendaService
{
    private readonly ITiendaRepository _tiendaRepository;

    public TiendaService(ITiendaRepository tiendaRepository)
    {
        _tiendaRepository = tiendaRepository;
    }

    public TiendaDTO ObtenerTiendaPorId(int id)
    {
        Tiendas tienda = _tiendaRepository.ObtenerTiendaPorId(id);
        TiendaDTO tiendaDTO = ConvertirATiendaDTO(tienda);
        return tiendaDTO;
    }

    private TiendaDTO ConvertirATiendaDTO(Tiendas tienda)
    {
        return new TiendaDTO
        {
            Id = tienda.Id,
            Comunidad = tienda.Comunidad,
            Localidad = tienda.Localidad,
            Calle = tienda.Calle,
            CodigoPostal = tienda.Codigopostal,
            Trabajadores = tienda.Trabajadores,
            HorarioAtencion = tienda.HorarioAtencion,

            // Incluir todos los campos necesarios del modelo TiendaDTO
        };
    }
}