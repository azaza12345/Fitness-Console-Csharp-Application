using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Activity Activity { get; set; }
        public User User { get; set; }
    }
}