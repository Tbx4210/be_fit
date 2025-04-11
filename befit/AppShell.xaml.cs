using befit.ViewModels;

using befit;

namespace befit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = services.GetRequiredService<AppShell>();
            //MainPage = new NavigationPage(new LoginPage());
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
