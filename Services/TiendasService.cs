using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class TiendaService : ITiendaRepository
{
    private readonly LibreriaContext _dbContext;

    public TiendaService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TiendaDTO ObtenerTiendaPorId(int id)
    {
        Tiendas tienda = _dbContext.Tiendas.FirstOrDefault(c => c.Id == id);
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