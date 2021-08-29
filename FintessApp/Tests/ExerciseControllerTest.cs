using System;
using System.Linq;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class ExerciseControllerTest
    {
        [TestMethod]
        public void ExerciseTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 200));

            // ACT
            exerciseController.Add(activity, DateTime.Now.AddHours(-1), DateTime.Now);

            // Assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}