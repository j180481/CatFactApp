using System.Threading.Tasks;
using CatFactApp.Controllers;
using CatFactApp.Models;
namespace CatFactApp.Views;

public partial class MainPage : ContentPage
{

    MainController controller = new MainController();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CatFactsHeader.FontSize = Services.PreferencesService.HeaderSize;
        FactLabel.FontSize = Services.PreferencesService.BodySize;
        CounterBtn.FontSize = Services.PreferencesService.BodySize;
        AboutButton.FontSize = Services.PreferencesService.BodySize;
        OptionsButton.FontSize = Services.PreferencesService.BodySize;
        SavedButton.FontSize = Services.PreferencesService.BodySize;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        CounterBtn.IsEnabled = false;
        
        var (headerText, factText, imageSource) = await controller.GetFactControl();
        if (headerText == "Null")
        {
            await DisplayAlert("Error", "Potential Connection error.", "Ok");
            return;
        }
        else
        {
            CatFactsHeader.Text = headerText;
            FactLabel.Text = factText;
            AnimalImage.Source = imageSource;
        }

        CounterBtn.IsEnabled = true;

    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        AboutButton.IsEnabled = false;

        await controller.GoToAboutControl();

        AboutButton.IsEnabled = true;
    }

    private async void OnOptionsClicked(object sender, EventArgs e)
    {
        OptionsButton.IsEnabled = false;

        await controller.GoToOptionsControl();

        OptionsButton.IsEnabled = true;
    }

    private async void OnSavedFactsClicked(object sender, EventArgs e)
    {
        SavedButton.IsEnabled = false;

        await controller.GoToSavedFactsControl();

        SavedButton.IsEnabled = true;
    }

    private async void OnFactLabelHeld(object sender, EventArgs e)
    {


        if (FactLabel.Text == "Meow!!!") return;

        if (CatFactsHeader.Text == "Dog Time!!!!") return;

        int result = await controller.SaveFactControl(FactLabel.Text);

        if (result == 0)
        {
            await DisplayAlert("Not Saved.", "Cat fact already saved", "Ok");
        }
        else
        {
            await DisplayAlert("Saved!", "Cat fact saved.", "Ok");
        }
    }

}


