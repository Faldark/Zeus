using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Zeux.Test.Server.Controllers;
using Zeux.Test.Server.Models;
using Zeux.Test.Services;

namespace Zeux.Test.Server.UnitTests.Controllers
{
    public class AccountControllerTests
    {
        [Fact]
        public async void Token_ReturnsToken_WhenLoginAndPasswordIsValid()
        {
            var login = "admin";
            var password = "admin";
            var role = "admin";

            var objectToReturn = new User
            {
                Login = login,
                Password = password,
                Role = role
            };

            // Arrange
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.FindUser(login, password))
                .ReturnsAsync(objectToReturn);
            var controller = new AccountController(mockService.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var tokenModel = new AccountController.TokenModel {username = login, password = password };

            // Act
            await controller.Token(tokenModel);

            var tokenString = GetCookieValueFromResponse(controller.Response, "jwt-token");
            var token = new JwtSecurityToken(tokenString);

            // Assert
            Assert.Equal("application/json", controller.Response.ContentType);
            Assert.Equal(3, tokenString.Split('.').Length);
            Assert.Equal(AuthOptions.Issuer, token.Claims.First().Issuer);
        }

        string GetCookieValueFromResponse(HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)
            foreach (var header in headers)
                if (header.StartsWith($"{cookieName}="))
                {
                    var p1 = header.IndexOf('=');
                    var p2 = header.IndexOf(';');
                    return header.Substring(p1 + 1, p2 - p1 - 1);
                }
            return null;
        }
    }
}
