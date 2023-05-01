using api_librerias_paco.Models;

public class EmpleadoService
{
    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadoService(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public EmpleadoDTO ObtenerEmpleadoPorId(int id)
    {
        Empleados empleado = _empleadoRepository.ObtenerEmpleadoPorId(id); // Asegúrate de que este método tenga el nombre correcto.
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