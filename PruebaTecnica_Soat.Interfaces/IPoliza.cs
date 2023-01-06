using PruebaTecnica_Soat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_Soat.Interfaces
{
    public interface IPoliza
    {
        
        List<PolizaResponse> GetPolizaAll();
        PolizaResponse GetPolizaPorId(int id);
        PolizaResponse GetPolizaPorPlaca(string placa);
        string ValidatePoliza(PolizaRequest p);
        int InsertPoliza(PolizaRequest polReq);
        bool UpdatePoliza(int id, PolizaRequest polReq);
    }
}
