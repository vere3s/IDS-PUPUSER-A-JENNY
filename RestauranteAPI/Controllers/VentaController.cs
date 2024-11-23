using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _ventaService;
        private readonly ILogger<VentaController> _logger;

        // Inyección de dependencias para VentaService y ILogger
        public VentaController(VentaService ventaService, ILogger<VentaController> logger)
        {
            _ventaService = ventaService;
            _logger = logger;
        }

        // Obtener todas las ventas
        /*[HttpGet]
        public IActionResult ObtenerVentas()
        {
            try
            {
                // Llamar al servicio para obtener las ventas
                var ventas = _ventaService.ObtenerVentas();  // Suponiendo que hay un método para obtener ventas

                if (ventas == null || !ventas.Any())
                {
                    return NotFound(new { message = "No se encontraron ventas." });
                }

                return Ok(ventas);
            }
            catch (Exception ex)
            {
                // Loguear el error
                _logger.LogError($"Error al obtener ventas: {ex.Message}", ex);
                return StatusCode(500, new { message = "Hubo un error al obtener las ventas.", error = ex.Message });
            }
        }
        */
        // Insertar una nueva venta
        [HttpPost]
        public IActionResult Insertar([FromBody] Ventas venta)
        {
            if (venta == null)
            {
                return BadRequest(new { message = "La venta no puede ser nula." });
            }

            if (venta.IdEmpleado <= 0 || venta.IdDetalleVenta <= 0 || venta.TotalVenta <= 0)
            {
                return BadRequest(new { message = "Datos inválidos. Asegúrese de que todos los campos son correctos." });
            }

            try
            {
                var resultado = _ventaService.Insertar(venta);

                if (resultado)
                {
                
                    return Ok(new { message = "Ventas insertada correctamente." });
                }

                return BadRequest(new { message = "Error al insertar la venta." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar venta: {ex.Message}", ex);
                return StatusCode(500, new { message = "Hubo un error al insertar la venta.", error = ex.Message });
            }
        }

        // Actualizar una venta existente
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Ventas venta)
        {
            if (venta == null)
            {
                return BadRequest(new { message = "La venta no puede ser nula." });
            }

            if (venta.IdVenta != id)
            {
                return BadRequest(new { message = "El ID de la venta no coincide con el ID en la URL." });
            }

            try
            {
                var resultado = _ventaService.Actualizar(venta);

                if (resultado)
                {
                    return Ok(new { message = "Venta actualizada correctamente." });
                }

                return BadRequest(new { message = "Error al actualizar la venta." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar venta {id}: {ex.Message}", ex);
                return StatusCode(500, new { message = "Hubo un error al actualizar la venta.", error = ex.Message });
            }
        }

        // Eliminar una venta
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var resultado = _ventaService.Eliminar(id);

                if (resultado)
                {
                    return Ok(new { message = "Venta eliminada correctamente." });
                }

                return BadRequest(new { message = "Error al eliminar la venta." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar venta {id}: {ex.Message}", ex);
                return StatusCode(500, new { message = "Hubo un error al eliminar la venta.", error = ex.Message });
            }
        }
    }
}
