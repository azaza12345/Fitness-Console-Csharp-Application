using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name field is Empty!", nameof(name));
            Name = name;
        }

        /// <summary>
        ///     Gender name
        /// </summary>
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}