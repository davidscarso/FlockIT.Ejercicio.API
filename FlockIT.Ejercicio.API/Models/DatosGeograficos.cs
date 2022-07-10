using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlockIT.Ejercicio.API.Models
{
    public class DatosGeograficos
    {
        public long Cantidad { get; set; }

        public long Inicio { get; set; }

        public Parametros Parametros { get; set; }

        public List<Provincia> Provincias { get; set; }

        public long Total { get; set; }
    }

    public class Parametros
    {
        public string Nombre { get; set; }
    }

    public class Provincia
    {
        public Centroide Centroide { get; set; }

        [JsonConverter(typeof(string))]
        public long Id { get; set; }

        public string Nombre { get; set; }
    }

    public class Centroide
    {
        public double Lat { get; set; }

        public double Lon { get; set; }
    }
}