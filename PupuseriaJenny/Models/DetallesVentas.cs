using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class DetallesVentas
    {
        public int IdDetalleVenta { get; set; }
        [Required(ErrorMessage = "La orden es obligatoria.")]
        public int IdOrden { get; set; }
        [Required(ErrorMessage = "El producto es obligatorio.")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "La receta es obligatoria.")]
        public int IdReceta { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int CantidadDetalleVenta { get; set; }
        [Required(ErrorMessage = "El SubTotalDetalleVenta es obligatorio.")]
        public decimal SubTotalDetalleVenta { get; set; }
    }
}
