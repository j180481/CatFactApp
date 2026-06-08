using System.Threading.Tasks;

namespace CatFactApp
{
    public partial class MainPage : ContentPage
    {

        int count = 0;

        int dogCount = 10;

        bool dogTime = false;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CatFactsHeader.FontSize = PreferencesService.HeaderSize;
            FactLabel.FontSize = PreferencesService.BodySize;
            CounterBtn.FontSize = PreferencesService.BodySize;
            AboutButton.FontSize = PreferencesService.BodySize;
            OptionsButton.FontSize = PreferencesService.BodySize;
            SavedButton.FontSize = PreferencesService.BodySize;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {

            ApiService service = new ApiService();

            count++;

            if (count == dogCount)
            {
                string url = await service.GetDogURL();

                AnimalImage.Source = url;

                CatFactsHeader.Text = "Dog Time!!!!";

                FactLabel.Text = "Ruff ruff ruff ruff ruff ruff ruff... woof";

                count = 0;

                return;

            }

            CatFactsHeader.Text = "Meow Facts!";

            AnimalImage.Source = "cat.png";

            CatFact fact = await service.GetFact();


            FactLabel.Text = fact.data[0];

            


            SemanticScreenReader.Announce(FactLabel.Text);
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AboutPage");
        }

        private async void OnOptionsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("OptionsMenuPage");
        }

        private async void OnSavedFactsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SavedFactsPage");
        }

        private async void OnFactLabelHeld(object sender, EventArgs e)
        {
            

            var fact = new DisplayFact
            {
                fact = FactLabel.Text,
                time = DateTime.Now
            };

            await App.DatabaseService.SaveFactAsync(fact);

            await DisplayAlert("Saved!", "Cat fact saved.", "Ok");

        }

    }

    
}
