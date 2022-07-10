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
    public class DataGeoController : ControllerBase
    {
        private readonly IDataGeoService _dataGeoService;
        private readonly ILogger<DataGeoController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataGeoController(ILogger<DataGeoController> logger, IDataGeoService dataGeoService)
        {
            _dataGeoService = dataGeoService ?? throw new ArgumentNullException(nameof(dataGeoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet("{name}")]
        [ProducesResponseType(typeof(GeoPoint), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetGeoPointByNameAsync(string name)
        {
            _logger.LogInformation($"Getting GetGeoPoint for: {name}");

            var res = await _dataGeoService.GetPointByNameAsync(name);

            if (res == null) return NotFound();
            else return Ok(res);
        }
    }
}
