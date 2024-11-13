using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Cargos
    {
        public int IdCargo { get; set; }
        [Required(ErrorMessage = "El nombre del cargo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la categoria no puede superar los 50 caracteres.")]
        public string cargo { get; set; }
    }
}
