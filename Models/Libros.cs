using Newtonsoft.Json;


namespace api_librerias_paco.Models
{

    public class Libros
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }
        public decimal? Precio { get; set; }
        public string? Autor { get; set; }

        public int? Paginas { get; set; }

        public bool? EnVenta { get; set; }

        public int ISBN { get; set; }

        public string Imagen {get; set;}

        public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<Tiendas> Tiendas { get; set; }

        public virtual ICollection<LibrosClientes> LibrosClientes { get; set; } 

        public Categorias Categorias { get; set; } 
        public int CategoriaId { get; set; } // Foreign key

    }
}