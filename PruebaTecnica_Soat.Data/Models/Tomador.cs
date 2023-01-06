using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica_Soat.Data.Models
{
    public partial class Tomador
    {
        public Tomador()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
