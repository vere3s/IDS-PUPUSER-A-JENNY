using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController()
        {
            _categoriaService = new CategoriaService();
        }

        // Obtener todas las categorías de productos
        
        [HttpGet]
        public IActionResult ObtenerCategorias()
        {
            try
            {
                List<string> categorias = _categoriaService.CategoriasProductos();

                // Filtrar para obtener solo la primera categoría
              ; // Esto devuelve la primera categoría si existe

                // Verificamos si encontramos una categoría
                if (categorias == null)
                {
                    return NotFound(new { message = "No se encontraron categorías." });
                }

                // Si se encontró una categoría, la retornamos en el formato esperado
                return Ok(new { categoria = categorias });
            }
            catch (Exception ex)
            {
                // En caso de que ocurra una excepción, capturamos el error y lo retornamos
                Console.WriteLine($"Error al obtener categorías: {ex.Message}");
                return StatusCode(500, new { message = "Hubo un error al obtener las categorías.", error = ex.Message });
            }
        }


        // Obtener productos por categoría
        [HttpGet("productos/{categoria}")]
        public IActionResult ObtenerProductosPorCategoria(string categoria)
        {
            try
            {
                DataTable productos = _categoriaService.ObtenerProductosPorCategoria(categoria);

                // Verificamos si no hay productos para la categoría
                if (productos == null || productos.Rows.Count == 0)
                {
                    return NotFound(new { message = "No se encontraron productos para esta categoría." });
                }

                // Si se encontraron productos, los retornamos en la respuesta
                return Ok(productos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return StatusCode(500, new { message = "Hubo un error al obtener los productos.", error = ex.Message });
            }
        }

        // Insertar una nueva categoría
        [HttpPost]
        public IActionResult Insertar([FromBody] Categorias categoria)
        {
            if (_categoriaService.Insertar(categoria))
                return Ok(new { message = "Categoría insertada correctamente." });
            else
                return BadRequest(new { message = "Error al insertar la categoría." });
        }

        // Actualizar una categoría existente
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Categorias categoria)
        {
            categoria.IdCategoria = id; // Aseguramos que el ID de la categoría coincida con el que llega en la URL
            if (_categoriaService.Actualizar(categoria))
                return Ok(new { message = "Categoría actualizada correctamente." });
            else
                return BadRequest(new { message = "Error al actualizar la categoría." });
        }

        // Eliminar una categoría
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            if (_categoriaService.Eliminar(id))
                return Ok(new { message = "Categoría eliminada correctamente." });
            else
                return BadRequest(new { message = "Error al eliminar la categoría." });
        }
    }
}
