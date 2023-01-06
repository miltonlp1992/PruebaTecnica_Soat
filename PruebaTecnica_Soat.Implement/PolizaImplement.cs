using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica_Soat.Data.Models;
using PruebaTecnica_Soat.Data;
using PruebaTecnica_Soat.Entities;
using PruebaTecnica_Soat.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PruebaTecnica_Soat.Implement
{
    public class PolizaImplement : IPoliza
    {
        public List<PolizaResponse> GetPolizaAll()
        {
            try
            {
                var polizas = PolizaData.GetPolizaAll();

                var result = (from pol in polizas
                              select getPolizaResponse(pol)).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }        
        public PolizaResponse GetPolizaPorId(int id)
        {
            try
            {                
                var poliza = PolizaData.GetPolizaPorId(id);
                return getPolizaResponse(poliza);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public PolizaResponse GetPolizaPorPlaca(string placa)
        {
            try
            {
                var poliza = PolizaData.GetPolizaPorPlaca(placa);
                return getPolizaResponse(poliza);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public string ValidatePoliza(PolizaRequest p)
        {
            var tomador = TomadorData.GetTomadorPorId(p.IdTomador);
            if (tomador == null)
                return "El Tomador no existe en el sistema";
                        
            var ciudad = CiudadData.GetCiudadPorId(p.IdCiudad);
            if (ciudad == null)
                return "La ciudad no existe en el sistema";

            if (!ciudad.PermiteSoat)
                return "No se permite la venta de SOAT en la ciudad";

            if (DateTime.Now.Date > p.FechaVencPolizaActual)
                return "Su póliza actual ya esta vencida";

            return string.Empty;                   
        }
        public int InsertPoliza(PolizaRequest polReq)
        {
            try
            {
                var pol = new Poliza()
                {
                    FechaInicio = polReq.FechaInicio,
                    FechaFin = polReq.FechaFin,
                    IdTomador = polReq.IdTomador,
                    Placa = polReq.Placa,
                    FechaVencPolizaActual = polReq.FechaVencPolizaActual,
                    IdCiudad = polReq.IdCiudad
                };

                int id = PolizaData.InsertPoliza(pol);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }            
        }
        public bool UpdatePoliza(int id,PolizaRequest polReq)
        {
            try
            {
                var pol = new Poliza()
                {
                    Id = id,
                    FechaInicio = polReq.FechaInicio,
                    FechaFin = polReq.FechaFin,
                    IdTomador = polReq.IdTomador,
                    Placa = polReq.Placa,
                    FechaVencPolizaActual = polReq.FechaVencPolizaActual,
                    IdCiudad = polReq.IdCiudad
                };

                PolizaData.UpdatePoliza(pol);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        #region Helpers
        private PolizaResponse getPolizaResponse(Poliza pol)
        {
            return new PolizaResponse
            {
                Id = pol.Id,
                FechaInicio = pol.FechaInicio,
                FechaFin = pol.FechaFin,
                FechaVencPolizaActual = pol.FechaVencPolizaActual,
                Placa = pol.Placa,
                Ciudad = new CiudadResponse { Id = pol.IdCiudad, Nombre = pol.IdCiudadNavigation.Nombre, PermiteSoat = true },
                Tomador = new TomadorResponse { Id = pol.IdTomador, Nombre = pol.IdTomadorNavigation.Nombre, NroDocumento = pol.IdTomadorNavigation.NroDocumento }
            };
        }
        #endregion

    }
    
}
