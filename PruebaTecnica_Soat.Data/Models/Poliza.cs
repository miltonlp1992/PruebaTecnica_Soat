using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica_Soat.Data.Models
{
    public partial class Poliza
    {
        public int Id { get; set; }
        public int IdTomador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVencPolizaActual { get; set; }
        public string Placa { get; set; }
        public int IdCiudad { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Tomador IdTomadorNavigation { get; set; }
    }
}
