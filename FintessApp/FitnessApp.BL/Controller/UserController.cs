using System;
using System.Collections.Generic;
using System.Linq;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USER_FILE_NAME = "users.dat";

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        ///     Get List of Users Data
        /// </summary>
        /// <returns>Application user</returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        private void Save()
        {
            Save(USER_FILE_NAME, Users);
        }
    }
}