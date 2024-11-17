using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE DetallePedidoProducto (
//    idDetallePedidoProducto INT PRIMARY KEY AUTO_INCREMENT,
//    idPedidoCompra INT,
//    idProducto INT,
//    cantidadProducto INT NOT NULL,
//    precio DECIMAL(10, 2),
//   subtotal DECIMAL(10, 2) AS (cantidadProducto * precio),
//    FOREIGN KEY (idPedidoCompra) REFERENCES PedidoCompra(idPedidoCompra),
//    FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)
//);

namespace PupuseriaJenny.Models
{
    internal class PedidoCompra
    {
        [Key]
        public int IdDetallePedidoProducto { get; set; }

        [Required(ErrorMessage = "El ID del pedido de compra es obligatorio.")]
        [ForeignKey("PedidoCompra")]
        public int IdPedidoCompra { get; set; }

        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "La cantidad de producto es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de producto debe ser al menos 1.")]
        public int CantidadProducto { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser un valor positivo menor a 1,000,000.")]
        public decimal Precio { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Range(0.01, 999999999.99, ErrorMessage = "El subtotal debe ser un valor positivo.")]
        public decimal Subtotal { get; set; }

        // Propiedades de navegación para las claves foráneas
        public virtual PedidoCompra pedidoCompra { get; set; }
        public virtual Producto producto { get; set; }
    }
}
