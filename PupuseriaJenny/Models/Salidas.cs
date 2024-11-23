using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Salidas
    {
        public int IdSalida { get; set; }
        public int? IdProducto { get; set; }
        public int? IdIngrediente { get; set; }
        [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de salida no es válida.")]
        public DateTime FechaSalida { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int CantidadSalida { get; set; }

        [Required(ErrorMessage = "El costo unitario de salida es obligatorio.")]
        public decimal CostoUnitarioSalida { get; set; }

        [Required(ErrorMessage = "El costo total es obligatorio.")]
        public decimal CostoTotalSalida { get; set; }
    }
}
