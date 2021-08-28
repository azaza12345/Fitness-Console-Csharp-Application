using System;
using System.Collections.Generic;
using System.Linq;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        public Eating Eating { get; }
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eatings.dat";
        private readonly User _user;
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            _user = user ?? throw new ArgumentNullException("User can't be null");
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(_user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}