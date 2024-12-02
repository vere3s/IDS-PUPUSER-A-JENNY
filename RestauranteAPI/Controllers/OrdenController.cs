using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System.Collections.Generic;
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

            return CreatedAtAction("creado", new { id = idOrden }, idOrden);
        }

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
                return NoContent(); 
            }

            return StatusCode(500, "Ocurrió un error al actualizar la orden.");
        }

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

        [HttpGet("pendientes/sin-mesa")]
        public IActionResult ObtenerOrdenesPendientesSinMesa()
        {
            DataTable ordenesPendientes = _ordenService.ObtenerOrdenesPendientesSinMesa();
            var ordenesDTO = _ordenService.ConvertirDataTableALista(ordenesPendientes);

            if (ordenesDTO.Count == 0)
            {
                return NotFound("No se encontraron órdenes pendientes sin mesa.");
            }

            return Ok(ordenesDTO);
        }

        [HttpGet("pendientes/con-mesa")]
        public IActionResult ObtenerOrdenesPendientesConMesa()
        {
            DataTable ordenesPendientes = _ordenService.ObtenerOrdenesPendientesConMesa();
            var ordenesDTO = _ordenService.ConvertirDataTableALista(ordenesPendientes);

            if (ordenesDTO.Count == 0)
            {
                return NotFound("No se encontraron órdenes pendientes con mesa.");
            }

            return Ok(ordenesDTO);
        }

       /* [HttpGet("{id}")]
        public IActionResult ObtenerOrden(int id)
        {
            var orden = _ordenService.ObtenerPorId(id);

            if (orden == null)
            {
                return NotFound($"No se encontró la orden con ID {id}.");
            }

            return Ok(orden);
        }*/
    }
}
