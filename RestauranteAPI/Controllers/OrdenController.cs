using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System.Data;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenController()
        {
            _ordenService = new OrdenService();
        }

        // POST: api/orden
        [HttpPost]
        public IActionResult InsertarOrden([FromBody] Ordenes orden)
        {
            if (orden == null)
            {
                return BadRequest("La orden no puede ser nula.");
            }

            int idOrden = _ordenService.Insertar(orden);

            if (idOrden == -1)
            {
                return StatusCode(500, "Ocurrió un error al insertar la orden.");
            }

            return CreatedAtAction(nameof(ObtenerOrden), new { id = idOrden }, idOrden);
        }

        // PUT: api/orden/5
        [HttpPut("{id}")]
        public IActionResult ActualizarOrden(int id, [FromBody] Ordenes orden)
        {
            if (orden == null || id != orden.IdOrden)
            {
                return BadRequest("Los datos de la orden son incorrectos.");
            }

            bool resultado = _ordenService.Actualizar(orden);

            if (resultado)
            {
                return NoContent(); // 204 No Content (éxito, pero no se devuelve contenido)
            }

            return StatusCode(500, "Ocurrió un error al actualizar la orden.");
        }

        // DELETE: api/orden/5
        [HttpDelete("{id}")]
        public IActionResult EliminarOrden(int id)
        {
            bool resultado = _ordenService.Eliminar(id);

            if (resultado)
            {
                return NoContent();
            }

            return StatusCode(500, "Ocurrió un error al eliminar la orden.");
        }

        // GET: api/ordenes/pendientes/sin-mesa
        [HttpGet("pendientes/sin-mesa")]
        public IActionResult ObtenerOrdenesPendientesSinMesa()
        {
            DataTable ordenesPendientes = _ordenService.ObtenerOrdenesPendientesSinMesa();

            if (ordenesPendientes.Rows.Count == 0)
            {
                return NotFound("No se encontraron órdenes pendientes sin mesa.");
            }

            return Ok(ordenesPendientes); // Devuelve las órdenes pendientes sin mesa
        }

        // GET: api/ordenes/pendientes/con-mesa
        [HttpGet("pendientes/con-mesa")]
        public IActionResult ObtenerOrdenesPendientesConMesa()
        {
            DataTable ordenesPendientes = _ordenService.ObtenerOrdenesPendientesConMesa();

            if (ordenesPendientes.Rows.Count == 0)
            {
                return NotFound("No se encontraron órdenes pendientes con mesa.");
            }

            return Ok(ordenesPendientes); // Devuelve las órdenes pendientes con mesa
        }

        // GET: api/ordenes/5
        [HttpGet("{id}")]
        public IActionResult ObtenerOrden(int id)
        {
            // Aquí podrías implementar la lógica para obtener una orden por su ID
            // Por ejemplo, crear un método en el servicio OrdenService que retorne un objeto Orden
            return Ok();
        }
    }
}
