using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Kardex
    {
        public int IdKardex { get; set; }
        public int? IdProducto { get; set; }
        public int? IdIngrediente { get; set; }
        public DateTime FechaMovimientoKardex { get; set; }
        public string TipoMovimientoKardex { get; set; }
        public decimal CantidadKardex { get; set; }
        public decimal CostoUnitarioKardex { get; set; }
        public decimal SaldoCantidadKardex { get; set; }
        public decimal SaldoValorKardex { get; set; }
    }
}
