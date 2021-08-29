using System;
using System.Globalization;
using System.Resources;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FintessApp.CMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru");
            var resourceManager = new ResourceManager("FintessApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Please, enter Gender: ");
                var gender = Console.ReadLine();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");
                var birthDate = ParseDateTime("Birth Date");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What are you going to do?");
                Console.WriteLine("E - enter Eating");
                Console.WriteLine("A - enter Activity");
                Console.WriteLine("Q - quit application");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.food, foods.weight);
                        foreach (var food in eatingController.Eating.Foods) Console.WriteLine(food.Key.Name);
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Start, exe.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} / {item.Start} : {item.Finish}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.Write("Enter exercise name: ");
            var name = Console.ReadLine();

            var caloriesPerMinute = ParseDouble("Calories Per Minute");
            
            var start = ParseDateTime("exercise start time");
            var finish = ParseDateTime("exercise finish time");

            return (start, finish, new Activity(name, caloriesPerMinute));
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime dateTime;
            while (true)
            {
                Console.WriteLine($"Please, {value} Date(dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateTime)) break;

                Console.WriteLine($"Incorrect {value} Type");
            }

            return dateTime;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Please, enter {name}");
                if (double.TryParse(Console.ReadLine(), out var value)) return value;
                Console.WriteLine($"Incorrect {name}");
            }
        }
    }
}