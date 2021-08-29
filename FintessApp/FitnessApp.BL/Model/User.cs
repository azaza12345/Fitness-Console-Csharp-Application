using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class User
    {
        /// <summary>
        ///     Create new User
        /// </summary>
        /// <param name="name"> Name </param>
        /// <param name="gender">Gender </param>
        /// <param name="birthDate">Birth Data</param>
        /// <param name="weight"> Weight </param>
        /// <param name="height"> Height </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check Conditions

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (gender == null) throw new ArgumentNullException(nameof(gender));
            if (birthDate < DateTime.Parse("01.01.1900") || BirthDate >= DateTime.Now)
                throw new ArgumentException("Invalid birthDate");
            if (weight <= 0) throw new ArgumentException("Invalid weight");
            if (height <= 0) throw new ArgumentException("Invalid height");

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }

        #region Properties

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;

        #endregion
    }
}