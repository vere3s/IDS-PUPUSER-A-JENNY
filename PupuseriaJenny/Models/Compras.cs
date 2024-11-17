using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CREATE TABLE Compra (
//    idCompra INT PRIMARY KEY AUTO_INCREMENT,
//    idEmpleado INT,
//    idPedidoCompra INT,
//    comentario VARCHAR(200),7
//    total DECIMAL(10, 2),
//    fecha DATE,
//    FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado),
//    FOREIGN KEY (idPedidoCompra) REFERENCES PedidoCompra(idPedidoCompra)
//);

namespace PupuseriaJenny.Models
{

    internal class Compras
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
        public virtual PedidoCompra PedidoCompra { get; set; }
    }
}
