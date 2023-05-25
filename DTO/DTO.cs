// LibrosClientesDTO

public class LibrosClientesDTO
{
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? Idlibro { get; set; }
        public string? NombreLibro { get; set; }
}




// CategoriaDTO
public class CategoriaDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? EdadRecomendada { get; set; }
    public string? Imagen { get; set; }
}



// ClienteDTO
public class ClienteDTO
{
    public int Id { get; set; }
    public string? Correo { get; set; }
    public string? Contrasenya { get; set; }
    public string? NombreUser { get; set; }
    public string? Rol { get; set; }
    public decimal? Saldo { get; set; }
    public string? FechaCreacion { get; set; }
}



// EmpleadoDTO
public class EmpleadoDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Correo { get; set; }
    public string? Residencia { get; set; }
    public string? Nacionalidad { get; set; }
    public int TiendaId { get; set; } 
}



// LibroDTO
public class LibroDTO
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public decimal? Precio { get; set; }
    public string? Autor { get; set; }
    public int? Paginas { get; set; }
    public bool? EnVenta { get; set; }
    public string? FechaPublicacion { get; set; }
    public int CategoriaId { get; set; } 
}


// TiendaDTO
public class TiendaDTO
{
    public int Id { get; set; }
    public string? Comunidad { get; set; }
    public string? Localidad { get; set; }
    public string? Calle { get; set; }
    public int? CodigoPostal { get; set; }
    public int? Trabajadores { get; set; }
    public string? HorarioAtencion { get; set; }
    // public int LibroId { get; set; }
    
}


