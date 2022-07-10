using FlockIT.Ejercicio.API.Models;
using FlockIT.Ejercicio.API.Services;
using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace FlockIT.Ejercicio.Test
{
    public class Login
    {
        Mock<ILogger<LoginService>> _loggerMock;

        ILoginService _loginservice;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<LoginService>>();
            _loginservice = new LoginService(_loggerMock.Object);
        }

        [Test]
        public void ShouldHaveAcces()
        {
            var userLogin = _loginservice.Validate(new LoginData() { UserName = "FCosmes", Password = "qwerty2022" });

            Assert.IsNotNull(userLogin);
            Assert.IsTrue(userLogin.IsHaveAccess);
            Assert.IsTrue(userLogin.Name.Equals("Fulanito Cosmes"));
            Assert.IsTrue(userLogin.Token.Equals("123456789-qwaszx"));
        }

        [Test]
        public void ShouldNotHaveAcces()
        {
            var userLogin1 = _loginservice.Validate(new LoginData() { UserName = "JPerez", Password = "23232323232" });

            Assert.IsNotNull(userLogin1);
            Assert.IsFalse(userLogin1.IsHaveAccess);
            Assert.IsNull(userLogin1.Name);
            Assert.IsNull(userLogin1.Token);

            var userLogin2 = _loginservice.Validate(new LoginData() { UserName = "FCosmes", Password = "23232323232" });

            Assert.IsNotNull(userLogin2);
            Assert.IsFalse(userLogin2.IsHaveAccess);
            Assert.IsNull(userLogin2.Name);
            Assert.IsNull(userLogin2.Token);
        }
    }
}