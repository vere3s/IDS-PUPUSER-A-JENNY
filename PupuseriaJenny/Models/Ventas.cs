using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        [Required(ErrorMessage = "El empleado es obligatorio.")]
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "El detalle de la venta es obligatorio.")]
        public int IdDetalleVenta { get; set; }
        [Required(ErrorMessage = "El total de la venta es obligatorio.")]
        public decimal TotalVenta { get; set; }
    }
}
