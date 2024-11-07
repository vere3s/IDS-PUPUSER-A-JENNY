using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Categorias
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la categoria no puede superar los 50 caracteres.")]
        public string Categoria { get; set; }
    }
}
