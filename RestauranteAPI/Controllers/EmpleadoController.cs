using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    [Authorize]
    public class EmpleadoController : ControllerBase
        {
            private readonly EmpleadoService _empleadoService;

            public EmpleadoController()
            {
                _empleadoService = new EmpleadoService();
            }

        // Obtener todos los empleados
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                List<Empleado> empleados = _empleadoService.ObtenerTodos();

                // Verificamos si la lista es null o vacía
                if (empleados == null || !empleados.Any())
                {
                    return NotFound(new { message = "No se encontraron empleados." });
                }

                // Si se encontraron empleados, los retornamos en la respuesta
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                // En caso de que ocurra una excepción, capturamos el error y lo retornamos
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                return StatusCode(500, new { message = "Hubo un error al obtener los empleados.", error = ex.Message });
            }
        }


        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            Empleado empleado = _empleadoService.ObtenerPorId(id);
            if (empleado == null)
                return NotFound(new { message = "Empleado no encontrado." });

            return Ok(empleado);  // Si se encuentra el empleado, devolvemos Ok
        }


        // Insertar un nuevo empleado
        [HttpPost]
      //  [Authorize(Roles = "Admin")]
        public IActionResult Insertar([FromBody] Empleado empleado)
            {
                if (_empleadoService.Insertar(empleado))
                    return Ok(new { message = "Empleado insertado correctamente." });
                else
                    return BadRequest(new { message = "Error al insertar el empleado." });
            }

            // Actualizar un empleado existente
            [HttpPut("{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Actualizar(int id, [FromBody] Empleado empleado)
            {
                empleado.IdEmpleado = id; // Aseguramos que el ID del empleado coincida con el que llega en la URL
                if (_empleadoService.Actualizar(empleado))
                    return Ok(new { message = "Empleado actualizado correctamente." });
                else
                    return BadRequest(new { message = "Error al actualizar el empleado." });
            }

            // Eliminar un empleado
            [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Eliminar(int id)
            {
                if (_empleadoService.Eliminar(id))
                    return Ok(new { message = "Empleado eliminado correctamente." });
                else
                    return BadRequest(new { message = "Error al eliminar el empleado." });
            }
        }
    }
