using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnica_Soat.Data.Models;
using PruebaTecnica_Soat.Entities;
namespace PruebaTecnica_Soat.Data
{
    public class PolizaData
    {        

        public static IEnumerable<Poliza> GetPolizaAll()
        {
            IEnumerable<Poliza> polizasResult;
            using (var context = new PruebaTecnicaSoatContext())
                polizasResult = context.Polizas.Include(p => p.IdCiudadNavigation).Include(p => p.IdTomadorNavigation).ToList();
            return polizasResult;           
        }

        public static Poliza GetPolizaPorId(int id)
        {            
            IEnumerable<Poliza> pol;
            using (var context = new PruebaTecnicaSoatContext())
                pol = context.Polizas.Where(p => p.Id == id).Include(p => p.IdCiudadNavigation).Include(p => p.IdTomadorNavigation).ToList();

            return pol.FirstOrDefault();
        }

        public static Poliza GetPolizaPorPlaca(string placa)
        {
            IEnumerable<Poliza> pol;
            using (var context = new PruebaTecnicaSoatContext())
                pol = context.Polizas.Where(p => p.Placa == placa).Include(p => p.IdCiudadNavigation).Include(p => p.IdTomadorNavigation).ToList();

            return pol.FirstOrDefault();
        }

        public static int InsertPoliza(Poliza pol)
        {
            using (var context = new PruebaTecnicaSoatContext())
            {
                context.Polizas.Add(pol);
                context.SaveChanges();
            }
            return pol.Id;    
        }

        public static void UpdatePoliza(Poliza pol)
        {
            using (var context = new PruebaTecnicaSoatContext())
            {
                context.Polizas.Update(pol);
                context.SaveChanges();
            }
        }
    }

    //public class Data
    //{
    //    public 

    //    public Data
    //}
}
