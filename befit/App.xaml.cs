namespace befit
{
    public partial class App : Application
    {
        public App()
        {
            //try
            //{
                InitializeComponent();

                MainPage = new AppShell();
        }

            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine($"App initialization failed: {ex}");
            //    throw; // This will help you see the exact error
            //}

        
    }
}