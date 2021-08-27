using System;
using FitnessApp.BL.Controller;

namespace FintessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is Fitness Application");
            
            Console.Write("Please, input user name");
            var name = Console.ReadLine();
            Console.WriteLine("Input gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Input Birth Date");
            var birthDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Input weight");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Input height");
            var height = double.Parse(Console.ReadLine());

            var user = new UserController(name, gender, birthDate, weight, height);
            user.Save();
        }
    }
}