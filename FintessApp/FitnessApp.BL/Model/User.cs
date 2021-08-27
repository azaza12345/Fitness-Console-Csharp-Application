using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class User
    {
        #region Properties
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthData { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name"> Name </param>
        /// <param name="gender">Gender </param>
        /// <param name="birthData">Birth Data</param>
        /// <param name="weight"> Weight </param>
        /// <param name="height"> Height </param>
        public User(string name, Gender gender, DateTime birthData, double weight, double height)
        {
            #region Check Conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender));
            }
            if (birthData < DateTime.Parse("01.01.1900") || BirthData >= DateTime.Now)
            {
                throw new ArgumentException("Invalid birthDate");
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Invalid weight");
            }
            if (height <= 0)
            {
                throw new ArgumentException("Invalid height");
            }
            #endregion
            
            Name = name;
            Gender = gender;
            BirthData = birthData;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}