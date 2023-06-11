using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class CategoriaService : ICategoriaRepository
{
    private readonly LibreriaContext _dbContext;

    public CategoriaService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CategoriaDTO ObtenerCategoriaPorId(int id)
    {
        Categorias categoria = _dbContext.Categorias.FirstOrDefault(c => c.Id == id);
        CategoriaDTO categoriaDTO = ConvertirACategoriaDTO(categoria);
        return categoriaDTO;
    }

    private CategoriaDTO ConvertirACategoriaDTO(Categorias categoria)
    {
        return new CategoriaDTO
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion,
            EdadRecomendada = categoria.EdadRecomendada,
            Imagen = categoria.Imagen
            // Incluir todos los campos necesarios del modelo CategoriaDTO
        };
    }

}