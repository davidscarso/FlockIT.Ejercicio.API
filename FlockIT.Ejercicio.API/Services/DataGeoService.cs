using FlockIT.Ejercicio.API.Models;
using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Services
{
    // puede usar un gateway o conectarce direco a la api
    // https://apis.datos.gob.ar/georef/api/provincias
    // https://datosgobar.github.io/georef-ar-api/
    // https://apis.datos.gob.ar/georef/api/provincias?nombre=Sgo. del Estero

    public class DataGeoService : IDataGeoService
    {
        private readonly ILogger<DataGeoService> _logger;

        // set endpoint and your access key
        private const string _url = "https://apis.datos.gob.ar/georef/api/";
        private const string _endpoint = "provincias";

        private const string _urlAPI = _url + _endpoint + "?nombre=";

        public DataGeoService(ILogger<DataGeoService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GeoPoint> GetPointByNameAsync(string name)
        {
            _logger.LogInformation($"GetPointByNameAsync: {name}");


            using (var httpClient = new HttpClient())
            {
                DatosGeograficos datosGeo = new DatosGeograficos();
                GeoPoint geoPoint = null;


                using (var response = await httpClient.GetAsync(_urlAPI + name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    datosGeo = JsonConvert.DeserializeObject<DatosGeograficos>(apiResponse);
                    if (datosGeo.Cantidad > 0)
                        geoPoint = new GeoPoint
                        {
                            Lat = datosGeo.Provincias[0].Centroide.Lat,
                            Lon = datosGeo.Provincias[0].Centroide.Lon
                        };
                }

                return geoPoint;
            }
        }
    }
}
