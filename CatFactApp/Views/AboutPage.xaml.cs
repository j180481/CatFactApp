namespace CatFactApp;
using System.Windows.Input;

public partial class AboutPage : ContentPage
{

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AboutPage()
	{
		InitializeComponent();
		BindingContext = this;
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