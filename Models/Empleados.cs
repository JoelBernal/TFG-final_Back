namespace api_librerias_paco.Models
{

    public class Empleados

    {       
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Dni { get; set; }

        public string? Correo { get; set; }
        public string? Residencia { get; set; }
        public string? Nacionalidad { get; set; }

    }
}