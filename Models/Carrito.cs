namespace api_librerias_paco.Models

{

    public class Carrito

    {       
        public int Id { get; set; }
        

        public double? PrecioTotal { get; set; }
        public int? CantidadProductos { get; set; }
        public bool? EstadoCarrito { get; set; }

        public string? MetodosPago { get; set; }


    }
}