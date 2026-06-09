//using Android.OS;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using CatFactApp.Controllers;
using CatFactApp.Services;

namespace CatFactApp.Views;

public partial class OptionsMenuPage : ContentPage
{
    OptionsController controller = new OptionsController();

    public OptionsMenuPage()
	{
		InitializeComponent();

    }

    /// <summary>
    /// Saving the font size as a preference, it is applied to every page on appearing.
    /// Resource utilized: https://en.ittrip.xyz/c-sharp/maui-font-size-by-resolution
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        OptionsHeader.FontSize = controller.GetHeaderSize();
        ButtonSmall.FontSize = controller.GetBodySize();
        ButtonMedium.FontSize = controller.GetBodySize();
        ButtonLarge.FontSize = controller.GetBodySize();
        ButtonExport.FontSize = controller.GetBodySize();
        ButtonTest.FontSize = controller.GetBodySize();
        ButtonReset.FontSize = controller.GetBodySize();

        SetButton();
    }

    private void SetButton()
    {
        ButtonSmall.BorderWidth = 0;
        ButtonMedium.BorderWidth = 0;
        ButtonLarge.BorderWidth = 0;
        ButtonSmall.BorderColor = Colors.Transparent;
        ButtonMedium.BorderColor = Colors.Transparent;
        ButtonLarge.BorderColor = Colors.Transparent;

        //retrieve the current header font size as an int from the saved preference
        int currentHeader = controller.GetHeaderSize();

        //Then check it to determine which button is set as active visually in the UI
        if (currentHeader == 18)
        {
            ButtonSmall.BorderWidth = 3;
            ButtonSmall.BorderColor = Colors.Green;
        }

        else if (currentHeader == 22)
        {
            ButtonMedium.BorderWidth = 3;
            ButtonMedium.BorderColor = Colors.Green;
        }

        else if (currentHeader == 26)
        {
            ButtonLarge.BorderWidth = 3;
            ButtonLarge.BorderColor = Colors.Green;
        }

    }

    private void ButtonSmall_Clicked(object sender, EventArgs e)
    {
        ButtonSmall.IsEnabled = false;

        controller.SetSmallControl();

        
        OptionsHeader.FontSize = controller.GetHeaderSize();
        ButtonSmall.FontSize = controller.GetBodySize();
        ButtonMedium.FontSize = controller.GetBodySize();
        ButtonLarge.FontSize = controller.GetBodySize();
        ButtonExport.FontSize = controller.GetBodySize();
        ButtonTest.FontSize = controller.GetBodySize();
        ButtonReset.FontSize = controller.GetBodySize();

        SetButton();

        ButtonSmall.IsEnabled = true;

    }

    private void ButtonMedium_Clicked(object sender, EventArgs e)
    {

        ButtonMedium.IsEnabled = false;

        controller.SetMediumControl();


        OptionsHeader.FontSize = controller.GetHeaderSize();
        ButtonSmall.FontSize = controller.GetBodySize();
        ButtonMedium.FontSize = controller.GetBodySize();
        ButtonLarge.FontSize = controller.GetBodySize();
        ButtonExport.FontSize = controller.GetBodySize();
        ButtonTest.FontSize = controller.GetBodySize();
        ButtonReset.FontSize = controller.GetBodySize();

        SetButton();

        ButtonMedium.IsEnabled = true;

    }

    private void ButtonLarge_Clicked(object sender, EventArgs e)
    {
        ButtonLarge.IsEnabled = false;

        controller.SetLargeControl();


        OptionsHeader.FontSize = controller.GetHeaderSize();
        ButtonSmall.FontSize = controller.GetBodySize();
        ButtonMedium.FontSize = controller.GetBodySize();
        ButtonLarge.FontSize = controller.GetBodySize();
        ButtonExport.FontSize = controller.GetBodySize();
        ButtonTest.FontSize = controller.GetBodySize();
        ButtonReset.FontSize = controller.GetBodySize();

        SetButton();

        ButtonLarge.IsEnabled = true;

    }

    /// <summary>
    /// Exports the saved facts to a text file.
    /// Resource referenced for writing inside the emulator: https://learn.microsoft.com/en-us/answers/questions/991205/how-to-write-a-text-file-in-maui
    /// </summary>
    private async void ButtonExport_Clicked(object sender, EventArgs e)
    {
        ButtonExport.IsEnabled = false;

        bool response =  await controller.ExportFactsControl();

        if (response == true)
        {
            await DisplayAlert("Export", "Success", "Ok");
        }
        else
        {
            await DisplayAlert("Export", "Failed", "Ok");
        }

        ButtonExport.IsEnabled = true;
    }

    private async void ButtonTest_Clicked(object sender, EventArgs e)
    {

        ButtonTest.IsEnabled = false;

        bool test = await controller.TestApiControl();

        if (test == true)
        {
            await DisplayAlert("Test","Api Test Successful", "Ok");
        }
        else
        {
            await DisplayAlert("Test", "Api Test Failed", "Ok");
        }

        ButtonTest.IsEnabled = true;
    }

    private void ButtonReset_Clicked(object sender, EventArgs e)
    {

        ButtonReset.IsEnabled = false;

        controller.ResetDefaultsControl();


        OptionsHeader.FontSize = controller.GetHeaderSize();
        ButtonSmall.FontSize = controller.GetBodySize();
        ButtonMedium.FontSize = controller.GetBodySize();
        ButtonLarge.FontSize = controller.GetBodySize();
        ButtonExport.FontSize = controller.GetBodySize();
        ButtonTest.FontSize = controller.GetBodySize();
        ButtonReset.FontSize = controller.GetBodySize();

        SetButton();

        ButtonReset.IsEnabled = true;
    }
}