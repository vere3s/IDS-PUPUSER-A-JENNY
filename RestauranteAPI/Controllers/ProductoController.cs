using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
   [Route("api/[controller]")]
        [ApiController]
        public class ProductoController : ControllerBase
        {
            private readonly ProductoService _productoService;

            public ProductoController()
            {
                _productoService = new ProductoService();
            }

            [HttpPost]
            public IActionResult Insertar([FromBody] Productos producto)
            {
                if (_productoService.Insertar(producto))
                    return Ok(new { message = "Producto insertado correctamente" });
                else
                    return BadRequest(new { message = "Error al insertar el producto" });
            }

            [HttpPut]
            public IActionResult Actualizar([FromBody] Productos producto)
            {
                if (_productoService.Actualizar(producto))
                    return Ok(new { message = "Producto actualizado correctamente" });
                else
                    return BadRequest(new { message = "Error al actualizar el producto" });
            }

            [HttpDelete("{id}")]
            public IActionResult Eliminar(int id)
            {
                if (_productoService.Eliminar(id))
                    return Ok(new { message = "Producto eliminado correctamente" });
                else
                    return BadRequest(new { message = "Error al eliminar el producto" });
            }
        }
    }