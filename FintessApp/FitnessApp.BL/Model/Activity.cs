using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}