using System.Windows.Input;
using MauiApp13.Helpers;
using MauiApp13.Services;

namespace MauiApp13.ViewModels;

public class SignInViewModel : ViewModelBase
{
    private DBMokup _db;
    private string _userName = string.Empty;
    private string _password = string.Empty;
    private string _loginMessage = string.Empty;
    private bool _signInMessageVisible;
    private Color _signInMessageColor = Colors.Red;
    private bool _entryAsPassword;
    private string _passwordIconCode = string.Empty;

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
                (SignInCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string UserPassword
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
                (SignInCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string LoginMessage
    {
        get => _loginMessage;
        set
        {
            if (_loginMessage != value)
            {
                _loginMessage = value;
                OnPropertyChanged();
            }
        }
    }

    public bool SignInMessageVisible
    {
        get => _signInMessageVisible;
        set
        {
            if (_signInMessageVisible != value)
            {
                _signInMessageVisible = value;
                OnPropertyChanged();
            }
        }
    }

    public Color SignInMessageColor
    {
        get => _signInMessageColor;
        set
        {
            if (_signInMessageColor != value)
            {
                _signInMessageColor = value;
                OnPropertyChanged();
            }
        }
    }

    public bool EntryAsPassword
    {
        get => _entryAsPassword;
        set
        {
            if (_entryAsPassword != value)
            {
                _entryAsPassword = value;
                OnPropertyChanged();
            }
        }
    }

    public string PasswordIconCode
    {
        get => _passwordIconCode;
        set
        {
            if (_passwordIconCode != value)
            {
                _passwordIconCode = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand ShowPasswordCommand { get; }
    public ICommand SignInCommand { get; }

    public SignInViewModel()
    {
        _entryAsPassword = true;
        _passwordIconCode = FontHelper.CLOSED_EYE_ICON;
        _signInMessageVisible = false;
        _loginMessage = string.Empty;
        _db = new DBMokup();

        ShowPasswordCommand = new Command(TogglePasswordButton);
        SignInCommand = new Command(SignIn, () => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword)));
    }

    private void TogglePasswordButton()
    {
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;
        else
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }

    private void SignIn()
    {
        SignInMessageVisible = true;

        if (_db.IsExist(UserName, UserPassword))
        {
            LoginMessage = AppMessages.SignInMessageSuccess;
            SignInMessageColor = Colors.Green;
            // Navigate to MainPage
        }
        else
        {
            LoginMessage = AppMessages.SignMessageFail;
            SignInMessageColor = Colors.Red;
        }
    }
}
