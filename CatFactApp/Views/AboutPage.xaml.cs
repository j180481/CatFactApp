using CatFactApp.Controllers;
using CatFactApp.Services;
namespace CatFactApp.Views;
using System.Windows.Input;

public partial class AboutPage : ContentPage
{

    AboutController controller = new AboutController();

    /// <summary>
    /// In the xaml, the labels are connected to a gesture tap recognizer.
    /// The tap recognizer is bound to the tap command, with the api url as the command parameter.
    /// On being tapped, it passes the url (or the string) parameter into TapCommand which opens the link in the systems default browser.
    /// Resource: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-10.0#create-a-hyperlink
    /// </summary>
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