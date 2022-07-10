using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Models
{
    public class UserLogin
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public bool IsHaveAccess { get; set; }

        public string Messaje { get; set; }

    }
}
