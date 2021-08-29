using System;
using FitnessApp.BL.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-19);
            var gender = "man";
            var weight = 90;
            var height = 180;

            // ACT
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreNotSame(weight, controller.CurrentUser.Weight);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
        }

        [TestMethod]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            // ACT
            var userController = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}