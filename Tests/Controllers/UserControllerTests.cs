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
            UserController.userlist.Add(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

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

        [Fact]
        public void Create_PostAction_AddsUserToListAndRedirects()
        {
            // Arrange
            var controller = new UserController();
            var newUser = new User { Id = 31, Name = "Test User", Email = "test@example.com" };

            // Act
            var result = controller.Create(newUser);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            Assert.Contains(newUser, UserController.userlist);
        }

        [Fact]
        public void Edit_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist.Add(new User { Id = 1, Name = "Test User", Email = "test@example.com" });

            // Act
            var result = controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal("Test User", model.Name);
        }

        [Fact]
        public void Edit_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Edit(10089700);

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Edit_PostAction_UpdatesUserAndRedirects()
        {
            // Arrange
            var controller = new UserController();
            var existingUser = new User { Id = 1003, Name = "Test User", Email = "test@example.com" };
            UserController.userlist.Add(existingUser);
            var updatedUser = new User { Id = 1003, Name = "Updated User", Email = "updated@example.com" };

            // Act
            var result = controller.Edit(1003, updatedUser);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            Assert.Equal("Updated User", existingUser.Name);
            Assert.Equal("updated@example.com", existingUser.Email);
        }

        [Fact]
        public void Edit_PostAction_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();
            var updatedUser = new User { Id = 13456789, Name = "Updated User", Email = "updated@example.com" };

            // Act
            var result = controller.Edit(13456789, updatedUser);

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist.Add(new User { Id = 19878, Name = "Test User", Email = "test@example.com" });

            // Act
            var result = controller.Delete(19878);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal("Test User", model.Name);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Delete(185538);

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Delete_PostAction_RemovesUserAndRedirects()
        {
            // Arrange
            var controller = new UserController();
            var existingUser = new User { Id = 1908, Name = "Test User", Email = "test@example.com" };
            UserController.userlist.Add(existingUser);

            // Act
            var result = controller.Delete(1908, new FormCollection());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Index", redirectToActionResult.RouteValues["action"]);
            Assert.DoesNotContain(existingUser, UserController.userlist);
        }

        [Fact]
        public void Delete_PostAction_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Delete(7491, new FormCollection());

            // Assert
            Assert.IsType<HttpNotFoundResult>(result);
        }
    }
}


















