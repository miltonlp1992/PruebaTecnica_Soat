using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_Soat.Entities
{
    public class PolizaResponse
    {
        public int Id { get; set; }
        public TomadorResponse Tomador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVencPolizaActual { get; set; }
        public string Placa { get; set; }
        public CiudadResponse Ciudad { get; set; }
    }

    public class CiudadResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool PermiteSoat { get; set; }
    }

    public class TomadorResponse
    {
        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
    }

}
