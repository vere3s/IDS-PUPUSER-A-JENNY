using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
                // Obtenemos los productos desde el servicio
                DataTable productos = _categoriaService.ObtenerProductosPorCategoria(categoria);

                // Verificamos si no hay productos para la categoría
                if (productos == null || productos.Rows.Count == 0)
                {
                    return NotFound(new { message = "No se encontraron productos para esta categoría." });
                }

                // Convertir DataTable a una lista de objetos de tipo Producto
                var listaProductos = new List<Productos>();
                foreach (DataRow row in productos.Rows)
                {
                    listaProductos.Add(new Productos
                    {
                        IdProducto = Convert.ToInt32(row["idProducto"]),
                        NombreProducto = row["NombreProducto"].ToString(),
                        PrecioProducto = Convert.ToDecimal(row["PrecioProducto"]),
                        CostoUnitarioProducto = Convert.ToDecimal(row["CostoUnitarioProducto"])
                        // Asumiendo que tienes una columna llamada "ImagenUrl" en tu DataTable

                    });
                }

                // Si se encontraron productos, los retornamos en la respuesta
                return Ok(listaProductos);
            }
            catch (Exception ex)
            {
                // Registrar el error con un servicio de logging adecuado (por ejemplo, serilog, log4net, etc.)
               // _logger.LogError($"Error al obtener productos para la categoría {categoria}: {ex.Message}");

                // Devolver error con detalles
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
