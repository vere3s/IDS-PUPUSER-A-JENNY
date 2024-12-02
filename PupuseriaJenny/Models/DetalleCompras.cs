using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class DetalleCompras
    {
        public int? IdProducto { get; set; }
        public int? IdIngrediente { get; set; }
        public int Cantidad { get; set; }
        public decimal precioDetalle { get; set; }
        public decimal subtotalDetallePedido { get; set; }
        public int? idDetallePedidoCompra { get; set; }

      
        public string Tipo { get; set; } // Puede ser "Producto" o "Ingrediente"
        
        public decimal CostoUnitario { get; set; }
       

            // Constructor para productos
        public DetalleCompras(int idProducto, decimal costoUnitario, int cantidad, int idIngrediente)
        {
        if (Tipo == "Producto")
        {

            IdProducto = idProducto;
            CostoUnitario = costoUnitario;
            Cantidad = cantidad;

        }else if( Tipo == "Ingrediente")
        {
            IdIngrediente = idIngrediente;
            CostoUnitario = costoUnitario;
            Cantidad = cantidad;
        }

               
        }

        // Constructor para ingredientes
            
        }


    }

