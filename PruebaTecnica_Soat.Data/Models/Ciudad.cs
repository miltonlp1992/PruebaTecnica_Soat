using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica_Soat.Data.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            //Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? PermiteSoat { get; set; }
        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
