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
        CatFactsHeader.FontSize = controller.GetHeaderSize();
        FactLabel.FontSize = controller.GetBodySize();
        CounterBtn.FontSize = controller.GetBodySize();
        AboutButton.FontSize = controller.GetBodySize();
        OptionsButton.FontSize = controller.GetBodySize();
        SavedButton.FontSize = controller.GetBodySize();

        //every time the page appears we reset the navigation buttons to true
        AboutButton.IsEnabled = true;
        OptionsButton.IsEnabled = true;
        SavedButton.IsEnabled = true;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        //When a navigation button is pressed, we set IsEnabled to false so user cant open multiple instances of the same page
        CounterBtn.IsEnabled = false;
        
        var response = await controller.GetFactControl();

        //We check the returned tuple to see if it contains the string "null"
        //If it does we display error message to the user
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

        //pass the factLabel.txt and CatFactsHeader.txt into the controller
        //This is so we can validate the factLabel.text is valid
        int result = await controller.SaveFactControl(FactLabel.Text, CatFactsHeader.Text);

        //if it is either the default text (meow) or the header indicates dog time
        //we simply return, do not allow the user to do anything with it
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


