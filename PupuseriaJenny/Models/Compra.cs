

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PupuseriaJenny.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El ID del pedido de compra es obligatorio.")]
        [ForeignKey("PedidoCompra")]
        public int IdPedidoCompra { get; set; }

        [StringLength(200, ErrorMessage = "El comentario no puede superar los 200 caracteres.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El total debe ser un valor positivo menor a 1,000,000.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "La fecha de la compra es obligatoria.")]
        public DateTime Fecha { get; set; }

        // Propiedades de navegación para las claves foráneas
        public virtual Empleado Empleado { get; set; }
        public virtual PedidoCompra pedidoCompra { get; set; }
    }
}
