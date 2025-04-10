using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using befit.Utilities;

namespace befit.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    // Properties with backing fields
    private string _email = string.Empty;
    private string _password = string.Empty;
    private bool _isBusy;

    public string Email
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(EmailError)); // Update error message
                OnPropertyChanged(nameof(EmailIsValid)); // Update validation state
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PasswordError));
                OnPropertyChanged(nameof(PasswordIsValid));
            }
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy != value)
            {
                _isBusy = value;
                OnPropertyChanged();
                // Update button enable state
                (LoginCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    // Validation properties
    public bool EmailIsValid => ValidationHelper.IsValidEmail(Email);
    public bool PasswordIsValid => ValidationHelper.IsValidPassword(Password);

    public string EmailError => !EmailIsValid && !string.IsNullOrEmpty(Email)
        ? "Invalid email format" : null;

    public string PasswordError => !PasswordIsValid && !string.IsNullOrEmpty(Password)
        ? "Password must be 6+ characters" : null;

    // Commands
    public ICommand LoginCommand { get; }
    public ICommand GoToRegisterCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(async () => await LoginAsync(),
            () => !IsBusy && EmailIsValid && PasswordIsValid);

        GoToRegisterCommand = new Command(async () =>
            await Shell.Current.GoToAsync(nameof(RegisterPage)));
    }

    private async Task LoginAsync()
    {
        try
        {
            IsBusy = true;

            // Simulate network call
            await Task.Delay(1500);

            if (/* Your auth success check */ true)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    // INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}