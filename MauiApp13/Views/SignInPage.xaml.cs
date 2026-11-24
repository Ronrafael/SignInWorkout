using MauiApp13.ViewModels;

namespace MauiApp13.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInViewModel();
    }
}