using CatFactApp.Models;
using CatFactApp.Views;
using CatFactApp.Services;

namespace CatFactApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute("AboutPage", typeof(Views.AboutPage));
            Routing.RegisterRoute("OptionsMenuPage", typeof(Views.OptionsMenuPage));
            Routing.RegisterRoute("SavedFactsPage", typeof(Views.SavedFactsPage));
        }

        private static SQLService _databaseService = default!;

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        public static SQLService DatabaseService
        {
            get
            {
                if (_databaseService == null)
                {
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "catfacts.db3");
                    _databaseService = new SQLService(dbPath);
                }
                return _databaseService;
            }
        }
    }
}