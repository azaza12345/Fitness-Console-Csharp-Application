using System;
using System.Collections.Generic;
using System.Linq;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISE_FILE_NAME = "exercise.dat";
        private const string ACTIVITY_FILE_NAME = "activity.dat";
        private readonly User _user;

        public ExerciseController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, _user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, act, _user);
                Exercises.Add(exercise);
            }

            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(EXERCISE_FILE_NAME) ?? new List<Activity>();
        }

        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
            Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}