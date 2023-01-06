using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica_Soat.Implement;
using PruebaTecnica_Soat.Data.Models;
using PruebaTecnica_Soat.Entities;
using PruebaTecnica_Soat.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica_Soat.API2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolizaController : ControllerBase
    {
        private readonly IPoliza _poliza;        

        public PolizaController(IPoliza poliza)
        {            
            _poliza = poliza;
        }
        // GET: api/<PolizaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {                
                //var polImp = new PolizaImplement();
                var polizas = _poliza.GetPolizaAll();

                if (polizas == null || polizas.Count == 0)
                    return NotFound();

                return Ok(polizas);
            }
            catch (Exception ex)
            {
                return Problem(detail:ex.ToString(), title:ex.Message);
                throw;
            }
            
        }

        // GET api/<PolizaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //var polImp = new PolizaImplement();
                var poliza = _poliza.GetPolizaPorId(id);

                if(poliza == null)
                    return NotFound();

                return Ok(poliza);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), title: ex.Message);
                throw;
            }
        }

        [HttpGet("GetPoliza/{placa}")]
        public IActionResult GetPoliza(string placa)
        {
            try
            {
                //var polImp = new PolizaImplement();
                var poliza = _poliza.GetPolizaPorPlaca(placa);

                if (poliza == null)
                    return NotFound();

                return Ok(poliza);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), title: ex.Message);
                throw;
            }
        }

        // POST api/<PolizaController>
        [HttpPost]
        public IActionResult Post([FromBody] PolizaRequest p)
        {
            try
            {
                if (!ModelState.IsValid)
                    BadRequest(ModelState);

                //var polImp = new PolizaImplement();

                var msjValidation = _poliza.ValidatePoliza(p);
                if (!string.IsNullOrEmpty(msjValidation))
                    return BadRequest(new { ErrorValidation = msjValidation } );

                var id = _poliza.InsertPoliza(p);

                if (id == 0)
                    return Problem(detail: "Error realizando el insert a la tabla Poliza", title: "Error Insert");

                return Ok(new { Id = id });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), title: ex.Message);
                throw;
            }
        }

        // PUT api/<PolizaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PolizaRequest p)
        {
            try
            {
                if (!ModelState.IsValid)
                    BadRequest(ModelState);

                //var polImp = new PolizaImplement();

                var msjValidation = _poliza.ValidatePoliza(p);
                if (!string.IsNullOrEmpty(msjValidation))
                    return BadRequest(new { ErrorValidation = msjValidation });

                var updated = _poliza.UpdatePoliza(id,p);

                if (!updated)
                    return Problem(detail: "Error realizando el update a la tabla Poliza", title: "Error Update");

                return Ok(new { Updated = updated });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), title: ex.Message);
                throw;
            }
        }
       
    }
}
