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
    public class CiudadData
    {

        public static CiudadResponse GetCiudadPorId(int id)
        {
            Ciudad c;

            using (var context = new PruebaTecnicaSoatContext())
                c = context.Ciudads.Find(id);

            if (c == null)
                return null;

            var ciudad = new CiudadResponse()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                PermiteSoat = c.PermiteSoat ?? false
            };

            return ciudad;
        }
    }
}
