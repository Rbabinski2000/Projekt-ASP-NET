using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Data;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Controllers;
using Projekt_ASP_NET.Services;
using Data.Entities;
using Projekt_ASP_NET.Interfaces;

namespace Testy
{
    public class TravelControllerTest
    {
        
        [Fact]
        public void IndexAction_ReturnsView()
        {
            // Arrange
            var dbContextMock = new Mock<AppDbContext>();
            var travelServiceMock = new Mock<MemoryTravelService>(dbContextMock.Object); // Jeśli TravelService przyjmuje DbContext w konstruktorze

            var controller = new TravelController(travelServiceMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsViewWithTravelDetails()
        {
            // Arrange
            var mockTravelService = new Mock<ITravelService>();
            mockTravelService.Setup(service => service.FindById(It.IsAny<int>())).ReturnsAsync(new TravelEntity());

            var controller = new TravelController(mockTravelService.Object);

            // Act
            var result = controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<TravelEntity>(viewResult.Model);
            Assert.NotNull(model);
        }
        [Fact]
        public async Task Create_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockTravelService = new Mock<ITravelService>();
            var controller = new TravelController(mockTravelService.Object);
            var travelEntity = new TravelEntity
            {
                Id = 2,
                Name = "Niezapomniana Podróż-Egipt",
                StartDate = DateTime.Parse("01/02/2013"),
                EndDate = DateTime.Parse("10/02/2013"),
                StartPlace = "Kraków",
                EndPlace = "Egipt",
                Participants = "Kamil,Dawid,Gabryś",
                GuideId = 2,
                Created = DateTime.Now
            };

            // Act
            var result = controller.Create(travelEntity);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockTravelService.Verify(x => x.Add(It.IsAny<TravelEntity>()), Times.Once);
        }

        [Fact]
        public async Task Update_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockTravelService = new Mock<ITravelService>();
            var controller = new TravelController(mockTravelService.Object);
            var travelEntity = new TravelEntity
            {
                Id = 2,
                Name = "Niezapomniana Podróż-Egipt",
                StartDate = DateTime.Parse("01/02/2013"),
                EndDate = DateTime.Parse("10/02/2013"),
                StartPlace = "Kraków",
                EndPlace = "Egipt",
                Participants = "Kamil,Dawid,Gabryś",
                GuideId = 2,
                Created = DateTime.Now
            };
            controller.Create(travelEntity);
            // Act
            travelEntity.Name = "Egipt";
            var result =  controller.Update(travelEntity);
            var database=mockTravelService.Object.FindById(travelEntity.Id);
            // Assert
            //Assert.Equal(database.Result.Name, "Egipt");
            var isupdate4d= Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", isupdate4d.ActionName);
            mockTravelService.Verify(x => x.Update(It.IsAny<TravelEntity>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockTravelService = new Mock<ITravelService>();
            var controller = new TravelController(mockTravelService.Object);
            var travelEntity = new TravelEntity
            {
                Id = 2,
                Name = "Niezapomniana Podróż-Egipt",
                StartDate = DateTime.Parse("01/02/2013"),
                EndDate = DateTime.Parse("10/02/2013"),
                StartPlace = "Kraków",
                EndPlace = "Egipt",
                Participants = "Kamil,Dawid,Gabryś",
                GuideId = 2,
                Created = DateTime.Now
            };

            // Act
            var result =controller.Delete(travelEntity);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockTravelService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

    }
}
