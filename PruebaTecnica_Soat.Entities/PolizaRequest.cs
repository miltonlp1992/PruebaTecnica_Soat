using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_Soat.Entities
{
    public class PolizaRequest
    {
        [Required]
        public int IdTomador { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public DateTime FechaVencPolizaActual { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public int IdCiudad { get; set; }
    }
}
