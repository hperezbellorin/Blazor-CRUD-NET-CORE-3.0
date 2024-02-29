using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Data
{
    public class Cliente
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        public string Nombre {  get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "* Mail incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        public string Telefono { get; set; }

        public DateTime FechaAlta { get; set; }
    }
        
}
