using api_librerias_paco.Models;
using api_librerias_paco.Context;

public class EmpleadoService : IEmpleadoRepository
{
    private readonly LibreriaContext _dbContext;

    public EmpleadoService(LibreriaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public EmpleadoDTO ObtenerEmpleadoPorId(int id)
    {
        Empleados empleado = _dbContext.Empleados.FirstOrDefault(c => c.Id == id); // Asegúrate de que este método tenga el nombre correcto.
        EmpleadoDTO empleadoDTO = ConvertirAEmpleadoDTO(empleado);
        return empleadoDTO;
    }

    private EmpleadoDTO ConvertirAEmpleadoDTO(Empleados empleado)
    {
        // Lógica de conversión aquí
        // Ejemplo:
        return new EmpleadoDTO
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Apellidos = empleado.Apellidos,
            Dni = empleado.Dni,
            Correo = empleado.Correo,
            Residencia = empleado.Residencia,
            Nacionalidad = empleado.Nacionalidad,
            // Agrega más campos si es necesario
        };
    }
}