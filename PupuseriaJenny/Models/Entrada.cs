using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Entrada
    {

        public int? idProducto { get; set; }
        public int? idIngrediente { get; set; }
        public DateTime fechaEntrada { get; set; }
        public int cantidadEntrada { get; set; }
        public decimal costoUnitarioEntrada { get; set; }
        public int idCompra { get; set; }
    }
}
