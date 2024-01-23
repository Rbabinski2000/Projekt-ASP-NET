using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Projekt_ASP_NET;

namespace Testy
{
    public class ProgramTests : IClassFixture<WebApplicationFactory<Projekt_ASP_NET.Program>>
    {
        private readonly WebApplicationFactory<Projekt_ASP_NET.Program> _factory;

        public ProgramTests(WebApplicationFactory<Projekt_ASP_NET.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Program_StartsSuccessfully()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/"); // Replace "/" with your application route

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public void CanAccessTravelIndexPage()
        {
            // Arrange
            /*using (var driver = new ChromeDriver())
            {
                // Act
                driver.Navigate().GoToUrl(_factory.Server.BaseAddress + "/Travel/Index");

                // Assert
                Assert.Equal("Lista wycieczek - ASPPROJEKT", driver.Title);
            }*/
        }
    }
}
