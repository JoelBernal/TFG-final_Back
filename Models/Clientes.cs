namespace api_librerias_paco.Models
{

    public class Clientes

    {       
        public int Id { get; set; }

        public string? Correo { get; set; }
        public string? Contrasenya { get; set; }
        public string? NombreUser { get; set; }
        public string? Rol { get; set; }

        public decimal? Saldo { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

       
        public virtual ICollection<LibrosClientes> LibrosClientes { get; set; } 
        

    }
}