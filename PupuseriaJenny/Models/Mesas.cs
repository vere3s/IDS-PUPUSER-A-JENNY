using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Mesas
    {
        public int IdMesa { get; set; }
        [Required(ErrorMessage = "El numero de la mesa es obligatorio.")]
        public string NumeroMesa { get; set; }
    }
}
