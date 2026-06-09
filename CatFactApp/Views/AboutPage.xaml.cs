using CatFactApp.Controllers;
using CatFactApp.Services;
namespace CatFactApp.Views;
using System.Windows.Input;

public partial class AboutPage : ContentPage
{

    AboutController controller = new AboutController();

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AboutPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AboutHeader.FontSize = controller.GetHeaderSize();
        CatApiText.FontSize = controller.GetBodySize();
        CatApiLink.FontSize = controller.GetBodySize();
        DogApiText.FontSize = controller.GetBodySize();
        DogApiLink.FontSize = controller.GetBodySize();
        HelpText.FontSize = controller.GetBodySize();
    }

}