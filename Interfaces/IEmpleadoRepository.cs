using api_librerias_paco.Models;

public interface IEmpleadoRepository
{
    Empleados ObtenerEmpleadoPorId(int id);
    // Aquí puedes agregar otros métodos, como: CrearEmpleado, ActualizarEmpleado, EliminarEmpleado, etc.
}