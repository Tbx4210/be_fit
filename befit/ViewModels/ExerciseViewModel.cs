using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using befit.Models;

namespace befit.ViewModels
{
    public class ExerciseViewModel : INotifyPropertyChanged
    {
        private ExerciseRoutineModel _newExercise = new();
        public ExerciseRoutineModel NewExercise
        {
            get => _newExercise;
            set
            {
                _newExercise = value;
                OnPropertyChanged(nameof(NewExercise));
            }
        }

        public ObservableCollection<ExerciseRoutineModel> AllExercises { get; } = new();
        public ObservableCollection<ExerciseRoutineModel> CustomExercises =>
            new(AllExercises.Where(x => x.IsCustom));

        public ObservableCollection<ExerciseRoutineModel> FavoriteExercises =>
            new(AllExercises.Where(x => x.IsFavorite));

        public List<string> MuscleGroups { get; } = new()
        {
            "Chest", "Back", "Legs", "Arms", "Core", "Full Body"
        };

        public List<string> DifficultyLevels { get; } = new()
        {
            "Beginner", "Intermediate", "Advanced"
        };

        public ICommand SaveExerciseCommand { get; }
        public ICommand GoToCreateExerciseCommand { get; }

        public ExerciseViewModel()
        {
            LoadDefaultExercises();

            SaveExerciseCommand = new Command(() =>
            {
                if (ValidateExercise())
                {
                    AddCustomExercise(NewExercise);
                    NewExercise = new ExerciseRoutineModel();
                    Shell.Current.DisplayAlert("Success", "Exercise saved!", "OK");
                }
            });
        }

        private bool ValidateExercise()
        {
            if (string.IsNullOrWhiteSpace(NewExercise.ExerciseName))
            {
                Shell.Current.DisplayAlert("Error", "Please enter an exercise name", "OK");
                return false;
            }

            if (NewExercise.Sets <= 0)
            {
                Shell.Current.DisplayAlert("Error", "Sets must be greater than 0", "OK");
                return false;
            }

            if (NewExercise.Reps <= 0)
            {
                Shell.Current.DisplayAlert("Error", "Reps must be greater than 0", "OK");
                return false;
            }

            return true;
        }

        private void LoadDefaultExercises()
        {
            AllExercises.Add(new ExerciseRoutineModel
            {
                ExerciseName = "Push-ups",
                Sets = 3,
                Reps = 15,
                Difficulty = "Beginner",
                MuscleGroup = "Chest",
                IsCustom = false
            });

            AllExercises.Add(new ExerciseRoutineModel
            {
                ExerciseName = "Squats",
                Sets = 4,
                Reps = 12,
                Difficulty = "Intermediate",
                MuscleGroup = "Legs",
                IsCustom = false
            });
        }

        public void AddCustomExercise(ExerciseRoutineModel exercise)
        {
            exercise.Id = Guid.NewGuid().ToString();
            exercise.IsCustom = true;
            AllExercises.Add(exercise);
            OnPropertyChanged(nameof(CustomExercises));
            OnPropertyChanged(nameof(AllExercises));
        }

        public void ToggleFavorite(string exerciseId)
        {
            var exercise = AllExercises.FirstOrDefault(x => x.Id == exerciseId);
            if (exercise != null)
            {
                exercise.IsFavorite = !exercise.IsFavorite;
                OnPropertyChanged(nameof(FavoriteExercises));
                OnPropertyChanged(nameof(AllExercises));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
