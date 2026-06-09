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

        AboutButton.IsEnabled = true;
        OptionsButton.IsEnabled = true;
        SavedButton.IsEnabled = true;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        CounterBtn.IsEnabled = false;
        
        var response = await controller.GetFactControl();
        if (response.headerText == "Null")
        {
            await DisplayAlert("Error", "Potential Connection error.", "Ok");
            CounterBtn.IsEnabled = true;
            return;
        }
        else
        {
            CatFactsHeader.Text = response.headerText;
            FactLabel.Text = response.factText;
            AnimalImage.Source = response.imageSource;
        }

        CounterBtn.IsEnabled = true;

    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        AboutButton.IsEnabled = false;

        await controller.GoToAboutControl();

       
    }

    private async void OnOptionsClicked(object sender, EventArgs e)
    {
        OptionsButton.IsEnabled = false;

        await controller.GoToOptionsControl();

        
    }

    private async void OnSavedFactsClicked(object sender, EventArgs e)
    {
        SavedButton.IsEnabled = false;

        await controller.GoToSavedFactsControl();

        
    }

    private async void OnFactLabelHeld(object sender, EventArgs e)
    {


        int result = await controller.SaveFactControl(FactLabel.Text, CatFactsHeader.Text);

        if (result == -1)
        {
            return;
        }

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


