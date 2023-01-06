using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PruebaTecnica_Soat.API2.JWT;
using PruebaTecnica_Soat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_Soat.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AppSettings _appSettings;
        public AuthController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Post(LoginVM login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!login.User.Equals(_appSettings.User) || !login.Password.Equals(_appSettings.Password))
                    return Unauthorized(new { MEnsaje = "Credenciales no válidas" });

                var token = TokenGenerator.GenerateTokenJwt(login.User, _appSettings.SecretKey);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Problem(detail:ex.ToString(), title: ex.Message);
                throw;
            }
            
        }
    }
}
