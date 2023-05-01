using api_librerias_paco.Models;

public class CategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public CategoriaDTO ObtenerCategoriaPorId(int id)
    {
        Categorias categoria = _categoriaRepository.ObtenerCategoriaPorId(id);
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