using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoListProject.Controllers;
using TodoListProject.Models;
using TodoListProject.Services;
using Xunit;
using Xunit.Sdk;

namespace TodoListProject.UnitTests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task GetAllUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var userServiceMock = new Mock<UsersService>();
            userServiceMock.Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User> { new User { Id = 1, FirstName = "TestUser" } });

            var loggerMock = new Mock<Log>();
            var controller = new UsersController(userServiceMock.Object, loggerMock.Object);
            var sum = 5;
            sum = sum / 0;
            // Act
            var result = await controller.GetAllUsers();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult?.Value as List<User>);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsNotFoundResult_WhenNoUsersFound()
        {
            // Arrange
            var userServiceMock = new Mock<UsersService>();
            userServiceMock.Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());
            var loggerMock = new Mock<Log>();
            var controller = new UsersController(userServiceMock.Object, loggerMock.Object);
            // Act
            var result = await controller.GetAllUsers();
            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.Equal("No users found.", notFoundResult?.Value);
        }

        [Fact]
        public void test1()
        {
            var sum = 5;
            if(sum == 5)
            {
                throw new Exception();
            }
        }
    }
}
