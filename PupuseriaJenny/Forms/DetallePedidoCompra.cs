using System.Security.Permissions;

namespace PupuseriaJenny.Forms
{
    public class DetallePedidoCompra
    {
        public int IdPedidoCompra { get;  set; }
        public int IdProducto { get;  set; }
        public int CantidadDetallePedidoProducto { get; set; }
        public decimal PrecioDetallePedidoProducto { get;  set; }
        public int IdIngrediente { get;  set; }
        public int CantidadDetallePedidoIngrediente { get; set; }

        public decimal PrecioDetallePedidoIngrediente { get; set; }

    }
}