using CatFactApp.Controllers;
using CatFactApp.Services;
namespace CatFactApp.Views;
using System.Windows.Input;

public partial class AboutPage : ContentPage
{

    AboutController controller = new AboutController();

    public AboutPage()
	{
		InitializeComponent();
		BindingContext = controller;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AboutHeader.FontSize = PreferencesService.HeaderSize;
        CatApiText.FontSize = PreferencesService.BodySize;
        CatApiLink.FontSize = PreferencesService.BodySize;
        DogApiText.FontSize = PreferencesService.BodySize;
        DogApiLink.FontSize = PreferencesService.BodySize;
        HelpText.FontSize = PreferencesService.BodySize;
    }

}