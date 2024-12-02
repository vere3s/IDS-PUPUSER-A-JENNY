using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class DetallePedidoProducto
    {
        public int Id { get; set; }
            public int IdPedidoCompra { get; set; }
            public int IdProducto { get; set; }
            public int CantidadDetallePedidoProducto { get; set; }
            public decimal PrecioDetallePedidoProducto { get; set; }
       

    }
}
