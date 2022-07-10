using FlockIT.Ejercicio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockIT.Ejercicio.API.Services.Interfaces
{
    /// <summary>
    /// Limula un log con credenciales Hardcod 
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Valida y realiza login, devuelve un Usuario 
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        public UserLogin Validate(LoginData loginData);

    }
}
