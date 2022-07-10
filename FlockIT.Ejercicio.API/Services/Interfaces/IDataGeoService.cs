using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Services.Interfaces
{
    /// <summary>
    /// consume datos de la api publica
    /// https://apis.datos.gob.ar/georef/api/provincias
    /// https://datosgobar.github.io/georef-ar-api/
    /// El segundo tiene que, consumiendo la API pública https://apis.datos.gob.ar/georef/api/provincias, 
    /// retornar lat y long de una provincia por nombre(https://datosgobar.github.io/georef-ar-api/)
    /// </summary>
    interface IDataGeoService
    {
        public UserLogin Validate(LoginData loginData);

    }
}
