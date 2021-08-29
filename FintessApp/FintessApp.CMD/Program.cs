using System;
using System.Globalization;
using System.Resources;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FintessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru");
            var resourceManager = new ResourceManager("FintessApp.CMD.Languages.Messages", typeof(Program).Assembly);
            
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
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
            
            Console.WriteLine("What are you going to do?");
            Console.WriteLine("E - enter Eating");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.food, foods.weight);

                foreach (var food in eatingController.Eating.Foods)
                {
                    Console.WriteLine(food.Key.Name);
                }
            }
        }

        private static (Food food, double weight) EnterEating()
        {
            Console.Write("Please, Enter Product Name: ");
            var food = Console.ReadLine();
            
            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");

            Console.WriteLine("Enter weight of product");
            var weight = ParseDouble("product weight");

            var product = new Food(food, calories, proteins, fats, carbohydrates);
            return (product, weight);
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