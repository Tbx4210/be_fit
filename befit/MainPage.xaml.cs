using befit.View;
using befit.ViewModels;
using befit.Models;
namespace befit;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnUserDetailClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserDetail());
    }

    private async void OnAddExerciseClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddExercise());
    }

    private async void OnWorkoutHistoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WorkoutHistory());
    }

    private async void OnDietPlanClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DietPlanPage());
    }
}
