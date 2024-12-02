using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace PupuseriaJenny.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdEmpleado { get; set; }
        public int? IdDetallePedidoProducto { get; set; }
        public int? IdDetallePedidoIngrediente { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public string ComentarioCompra { get; set; }
    }
}
