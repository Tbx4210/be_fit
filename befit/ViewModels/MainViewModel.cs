using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using befit.Models;

namespace befit.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // User Profile
        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        // Today's Workouts
        private ObservableCollection<ExerciseRoutineModel> _todaysWorkouts;
        public ObservableCollection<ExerciseRoutineModel> TodaysWorkouts
        {
            get => _todaysWorkouts;
            set
            {
                _todaysWorkouts = value;
                OnPropertyChanged(nameof(TodaysWorkouts));
            }
        }

        // Diet Plan
        private ObservableCollection<DietPlanModel> _todaysMeals;
        public ObservableCollection<DietPlanModel> TodaysMeals
        {
            get => _todaysMeals;
            set
            {
                _todaysMeals = value;
                OnPropertyChanged(nameof(TodaysMeals));
            }
        }

        // Workout History
        private WorkoutHistoryModel _lastWorkout;
        public WorkoutHistoryModel LastWorkout
        {
            get => _lastWorkout;
            set
            {
                _lastWorkout = value;
                OnPropertyChanged(nameof(LastWorkout));
            }
        }

        public MainViewModel()
        {
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Initialize with sample data
            CurrentUser = new UserModel
            {
                Name = "Test User",
                Age = 30,
                Weight = 70.5,
                Height = 175,
                FitnessGoal = "Lose 5kg"
            };

            TodaysWorkouts = new ObservableCollection<ExerciseRoutineModel>
            {
                new ExerciseRoutineModel
                {
                    ExerciseName = "Push-ups",
                    Sets = 3,
                    Reps = 15,
                    Duration = 10,
                    Difficulty = "Beginner"
                },
                new ExerciseRoutineModel
                {
                    ExerciseName = "Squats",
                    Sets = 4,
                    Reps = 12,
                    Duration = 15,
                    Difficulty = "Intermediate"
                }
            };

            TodaysMeals = new ObservableCollection<DietPlanModel>
            {
                new DietPlanModel
                {
                    MealName = "Oatmeal",
                    MealType = "Breakfast",
                    Calories = 300,
                    Protein = 10,
                    Carbohydrates = 50,
                    Fat = 5
                },
                new DietPlanModel
                {
                    MealName = "Grilled Chicken",
                    MealType = "Lunch",
                    Calories = 450,
                    Protein = 35,
                    Carbohydrates = 30,
                    Fat = 15
                }
            };

            LastWorkout = new WorkoutHistoryModel
            {
                ExerciseName = "Deadlifts",
                Sets = 4,
                Reps = 8,
                Date = DateTime.Now.AddDays(-1),
                CaloriesBurned = 280
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
