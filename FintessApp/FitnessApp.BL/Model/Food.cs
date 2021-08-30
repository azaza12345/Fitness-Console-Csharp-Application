using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: Checking for invalid value
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public string Name { get; }

        /// <summary>
        ///     Proteins for 100g of Food
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        ///     Fats for 100g of Food
        /// </summary>
        public double Fats { get; }

        /// <summary>
        ///     Carbohydrates for 100g of Food
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        ///     Calories for 100g of Food
        /// </summary>
        public double Calories { get; }

        private double ProteinsOneGram => Proteins / 100.0;
        private double FatsOneGram => Fats / 100.0;
        private double CarbohydratesOneGram => Carbohydrates / 100.0;
        private double CaloriesOneGram => Calories / 100.0;
    }
}