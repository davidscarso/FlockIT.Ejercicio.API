using FlockIT.Ejercicio.API.Models;
using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace FlockIT.Ejercicio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataGeoController : ControllerBase
    {
        private readonly IDataGeoService _dataGeoService;
        private readonly ILogger<DataGeoController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataGeoController(ILogger<DataGeoController> logger,
                                 IDataGeoService dataGeoService)
        {
            _dataGeoService = dataGeoService ?? throw new ArgumentNullException(nameof(dataGeoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        [ProducesResponseType(typeof(UserLogin), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostLogin([FromBody] LoginData loginData)
        {
            _logger.LogInformation($"Mensaje para el log con valor: {loginData.UserName}");


            var res = _dataGeoService.Validate(loginData);
            if (res == null) return BadRequest();
            else return Ok(res);

        }
    }
}
