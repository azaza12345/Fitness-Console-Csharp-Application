using System;
using FitnessApp.BL.Controller;

namespace FintessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is Fitness Application");
            
            Console.WriteLine("Please, input user name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Please, enter Gender: ");
                var gender = Console.ReadLine();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");
                var birthDate = ParseBirthDate();
                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseBirthDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Please, enter Birth Date(dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }

                Console.WriteLine("Incorrect Birth Date Type");
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Please, enter {name}");
                if (double.TryParse(Console.ReadLine(), out var value))
                {
                    return value;
                }
                Console.WriteLine($"Incorrect {name}");
            }
        }
    }
}