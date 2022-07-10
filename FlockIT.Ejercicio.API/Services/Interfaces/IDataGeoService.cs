using FlockIT.Ejercicio.API.Models;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Services.Interfaces
{
    /// <summary>
    /// El segundo tiene que, consumiendo la API pública https://apis.datos.gob.ar/georef/api/provincias, 
    /// retornar lat y long de una provincia por nombre(https://datosgobar.github.io/georef-ar-api/)
    /// </summary>
    public interface IDataGeoService
    {
        Task<GeoPoint> GetPointByNameAsync(string name);
    }
}
