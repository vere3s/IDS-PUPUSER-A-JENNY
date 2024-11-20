using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    internal class Ingredientes
    {
        public int IdIngrediente { get; set; }

        [Required(ErrorMessage = "El nombre del ingrediente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del ingrediente no puede superar los 100 caracteres.")]
        public string NombreIngrediente { get; set; }
     

        [Required(ErrorMessage = "El precio del Ingrediente es obligatorio.")]
        public decimal PrecioIngrediente { get; set; }

        [Required(ErrorMessage = "La categoria del producto es obligatorio.")]
        public int IdCategoria { get; set; }

        public string ImagenIngrediente { get; set; }

    }
}
