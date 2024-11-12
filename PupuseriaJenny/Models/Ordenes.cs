using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    internal class Ordenes
    {
        public int IdOrden { get; set; }
        public int IdMesa { get; set; }
        [StringLength(100, ErrorMessage = "El nombre del cliente no puede superar los 100 caracteres.")]
        public string ClienteOrden { get; set; }
        [Required(ErrorMessage = "La fecha de orden es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de orden no es válida.")]
        public DateTime FechaOrden { get; set; }
        [Required(ErrorMessage = "El tipo de orden es obligatorio.")]
        public string TipoOrden { get; set; }
        [Required(ErrorMessage = "El estado de orden es obligatorio.")]
        public string EstadoOrden { get; set; }
        [StringLength(200, ErrorMessage = "El comentario no puede superar los 200 caracteres.")]
        public string ComentarioOrden { get; set; }
    }
}
