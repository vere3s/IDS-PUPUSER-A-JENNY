using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede superar los 100 caracteres.")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El costo unitario es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El costo unitario debe ser positivo y menor a 1,000,000.")]
        public decimal CostoUnitarioProducto { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser positivo y menor a 1,000,000.")]
        public decimal PrecioProducto { get; set; }

        [ForeignKey("Categoria")]
        public int? IdCategoria { get; set; } // Permite nulos si no se especifica una categoría

        public byte[] ImagenProducto { get; set; } // Campo para almacenar la imagen como un arreglo de bytes

        // Propiedad de navegación para la relación con la tabla RG_Categoria
        public virtual Categorias Categoria { get; set; }

    }
}
