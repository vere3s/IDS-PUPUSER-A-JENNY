using System.Data;
using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly DetalleVentaService _detalleVentaService;

        public DetalleVentaController()
        {
            _detalleVentaService = new DetalleVentaService();
        }

        // Insertar un nuevo detalle de venta
        [HttpPost]
        public IActionResult Insertar([FromBody] DetallesVentas detallesVenta)
        {
            if (detallesVenta == null)
            {
                return BadRequest(new { message = "Los detalles de venta no pueden ser nulos." });
            }

            try
            {
                int idDetalleVenta = _detalleVentaService.Insertar(detallesVenta);

                if (idDetalleVenta > 0)
                {
                    // Devolver respuesta con ubicación del nuevo recurso y el objeto creado
                    return CreatedAtAction(nameof(ObtenerDetallesPorOrdenPendiente), new { idOrden = detallesVenta.IdOrden }, new { message = "Detalle de venta insertado correctamente.", idDetalleVenta });
                }
                else
                {
                    return BadRequest(new { message = "Error al insertar el detalle de venta." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hubo un error al insertar el detalle de venta.", error = ex.Message });
            }
        }

        // Actualizar un detalle de venta
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] DetallesVentas detallesVenta)
        {
            if (detallesVenta == null || detallesVenta.IdDetalleVenta != id)
            {
                return BadRequest(new { message = "El ID del detalle de venta no coincide." });
            }

            try
            {
                bool resultado = _detalleVentaService.Actualizar(detallesVenta);

                if (resultado)
                {
                    return Ok(new { message = "Detalle de venta actualizado correctamente." });
                }
                else
                {
                    return BadRequest(new { message = "Error al actualizar el detalle de venta." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hubo un error al actualizar el detalle de venta.", error = ex.Message });
            }
        }

        // Eliminar un detalle de venta
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                bool resultado = _detalleVentaService.Eliminar(id);

                if (resultado)
                {
                    return Ok(new { message = "Detalle de venta eliminado correctamente." });
                }
                else
                {
                    return BadRequest(new { message = "Error al eliminar el detalle de venta." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hubo un error al eliminar el detalle de venta.", error = ex.Message });
            }
        }

        // Obtener detalles de venta por orden pendiente
        [HttpGet("orden/{idOrden}")]
        public IActionResult ObtenerDetallesPorOrdenPendiente(int idOrden)
        {
            try
            {
                var detalles = _detalleVentaService.ObtenerDetallesPorOrdenPendiente(idOrden);

                if (detalles == null || detalles.Rows.Count == 0)
                {
                    return NotFound(new { message = "No se encontraron detalles de venta para la orden pendiente." });
                }

                // Convertir DataTable a lista de objetos
                var listaDetalles = new List<object>();
                foreach (DataRow row in detalles.Rows)
                {
                    listaDetalles.Add(new
                    {
                        IdDetalleVenta = row["idDetalleVenta"],
                        IdProducto = row["idProducto"],
                        NombreProducto = row["nombreProducto"],
                        Cantidad = row["cantidadDetalleVenta"],
                        Precio = row["precioProducto"],
                        SubTotal = row["subTotalDetalleVenta"]
                    });
                }

                return Ok(listaDetalles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Hubo un error al obtener los detalles de la orden pendiente.", error = ex.Message });
            }
        }
    }
}
