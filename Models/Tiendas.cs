namespace api_librerias_paco.Models
{

    public class Tiendas
    {
        public int Id { get; set; }

        

        public string? Comunidad { get; set; }
        public string? Localidad { get; set; }
        public string? Calle { get; set; }

        public int? Codigopostal { get; set; }

        public int? Trabajadores { get; set; }

        public string? HorarioAtencion { get; set; }


        public  int LibroId {get;set;}

        public virtual Libros Libros { get; set; }
        

    }
}