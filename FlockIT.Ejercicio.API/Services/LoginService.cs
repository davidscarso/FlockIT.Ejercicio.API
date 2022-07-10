using FlockIT.Ejercicio.API.Models;
using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace FlockIT.Ejercicio.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger<LoginService> _logger;

        public LoginService(ILogger<LoginService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public UserLogin Validate(LoginData loginData)
        {
            _logger.LogInformation($"Trying to validate: {loginData.UserName}");

            try
            {
                var result = new UserLogin();
                if (loginData.UserName.Equals("FCosmes")
                    && loginData.Password.Equals("qwerty2022"))
                {
                    result.Name = "Fulanito Cosmes";
                    result.Token = "123456789-qwaszx";
                    result.IsHaveAccess = true;
                    result.Messaje = "Acceso correcto";

                    _logger.LogInformation($"Was validated: {loginData.UserName}");

                }
                else
                {
                    result.Name = null;
                    result.Token = null;
                    result.IsHaveAccess = false;
                    result.Messaje = "Usuario o Clave Incorrectos. Sin Acceso.";

                    _logger.LogInformation($"Could not be validated: {loginData.UserName}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"an exception occurred: {ex.Message}, StackTrace: {ex.StackTrace}");

                return null;
            }

        }
    }
}
