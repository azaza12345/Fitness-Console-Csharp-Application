using System;

namespace FitnessApp.BL.Model
{
    public class Gender
    {
        /// <summary>
        /// Gender name
        /// </summary>
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name field is Empty!", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}