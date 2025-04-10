using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace befit.ViewModels;
public class RegisterViewModel : INotifyPropertyChanged
{
    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

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

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    private string _confirmPassword;
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _confirmPassword = value;
            OnPropertyChanged();
        }
    }

    public ICommand RegisterCommand { get; }
    public ICommand GoToLoginCommand { get; }

    public RegisterViewModel()
    {
        RegisterCommand = new Command(OnRegisterClicked);
        GoToLoginCommand = new Command(OnLoginClicked);
    }

    private async void OnRegisterClicked()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
            string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Please fill in all required fields", "OK");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await Shell.Current.DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }

        // TODO: Replace with actual registration logic
        await Shell.Current.DisplayAlert("Success", "Registration successful!", "OK");
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