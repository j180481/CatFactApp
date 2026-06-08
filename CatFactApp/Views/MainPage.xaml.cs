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

        
        var (headerText, factText, imageSource) = await controller.GetFactControl();
        CatFactsHeader.Text = headerText;
        FactLabel.Text = factText;
        AnimalImage.Source = imageSource;
        


    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await controller.GoToAboutControl();
    }

    private async void OnOptionsClicked(object sender, EventArgs e)
    {
        await controller.GoToOptionsControl(); ;
    }

    private async void OnSavedFactsClicked(object sender, EventArgs e)
    {
        await controller.GoToSavedFactsControl();
    }

    private async void OnFactLabelHeld(object sender, EventArgs e)
    {

        if (FactLabel.Text == "Meow!!!") return;

        if (CatFactsHeader.Text == "Dog Time!!!!") return;

        await controller.SaveFactControl(FactLabel.Text);
        await DisplayAlert("Saved!", "Cat fact saved.", "Ok");

    }

}


