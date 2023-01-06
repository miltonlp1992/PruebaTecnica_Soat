using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_Soat.API2
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Debe ingresar el parametro User")]
        public string User { get; set; }

        [Required(ErrorMessage = "Debe ingresar el parametro Password")]
        public string Password { get; set; }
    }
}
