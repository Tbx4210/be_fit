using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace befit.ViewModels;

public class ForgotPasswordViewModel : INotifyPropertyChanged
{
    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public ICommand ResetPasswordCommand { get; }
    public ICommand GoToLoginCommand { get; }

    public ForgotPasswordViewModel()
    {
        ResetPasswordCommand = new Command(OnResetClicked);
        GoToLoginCommand = new Command(OnLoginClicked);
    }

    private async void OnResetClicked()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter your email", "OK");
            return;
        }

        // TODO: Replace with actual password reset logic
        await Shell.Current.DisplayAlert("Success", "Password reset link sent to your email", "OK");
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void OnLoginClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}