using befit.ViewModels;
using Microsoft.Maui.Controls;  
namespace befit;

public partial class CreateExercisePage : ContentPage
{
    public CreateExercisePage(ExerciseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}