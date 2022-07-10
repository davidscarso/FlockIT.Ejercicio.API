using FlockIT.Ejercicio.API.Models;
using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginController(ILogger<LoginController> logger,
                                ILoginService logingService)
        {
            _loginService = logingService ?? throw new ArgumentNullException(nameof(logingService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserLogin), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostLogin([FromBody] LoginData loginData)
        {
            _logger.LogInformation($"Mensaje para el log con valor: {loginData.UserName}");


            var res = _loginService.Validate(loginData);
            if (res == null) return BadRequest();
            else return Ok(res);

        }
    }
}
