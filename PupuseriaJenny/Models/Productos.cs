using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede superar los 100 caracteres.")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El costo unitario del producto es obligatorio.")]
        public decimal CostoUnitarioProducto { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        public decimal PrecioProducto { get; set; }

        [Required(ErrorMessage = "La categoria del producto es obligatorio.")]
        public string IdCategoria { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio.")]
        public int IdProveedor { get; set; }
    }
}
