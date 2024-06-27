using Xunit;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    public class UserControllerTests
    {

        [Fact]
        public void Index_ReturnsViewResult_WithListOfUsers()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<System.Collections.Generic.List<User>>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public void Details_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var controller = new UserController();
            controller.Create(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

            // Act
            var result = controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal("Test User", model.Name);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Details(100000);

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

    
 
       
    }
}


















