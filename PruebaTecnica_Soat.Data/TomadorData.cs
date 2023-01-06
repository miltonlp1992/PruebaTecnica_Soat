using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Soat.Data.Models;
using PruebaTecnica_Soat.Entities;

namespace PruebaTecnica_Soat.Data
{
    public class TomadorData
    {
        public static TomadorResponse GetTomadorPorId(int id)
        {
            Tomador t;
            using (var context = new PruebaTecnicaSoatContext())            
                t = context.Tomadors.Find(id);
            
            if (t == null)
                return null;

            var tomador = new TomadorResponse()
            {
                Id = t.Id,
                Nombre = t.Nombre,
                NroDocumento = t.NroDocumento
            };

            return tomador;
        }  
    }
}
