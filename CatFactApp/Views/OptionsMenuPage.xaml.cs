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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;

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

        if (PreferencesService.HeaderSize == 18)
        {
            ButtonSmall.BorderWidth = 3;
            ButtonSmall.BorderColor = Colors.Green;
        }

        else if (PreferencesService.HeaderSize == 22)
        {
            ButtonMedium.BorderWidth = 3;
            ButtonMedium.BorderColor = Colors.Green;
        }

        else if (PreferencesService.HeaderSize == 26)
        {
            ButtonLarge.BorderWidth = 3;
            ButtonLarge.BorderColor = Colors.Green;
        }

    }

    private void ButtonSmall_Clicked(object sender, EventArgs e)
    {
        controller.SetSmallControl();

        
        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;

        SetButton();

    }

    private void ButtonMedium_Clicked(object sender, EventArgs e)
    {
        controller.SetMediumControl();


        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;

        SetButton();
    }

    private void ButtonLarge_Clicked(object sender, EventArgs e)
    {
        controller.SetLargeControl();


        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;

        SetButton();

    }

    /// <summary>
    /// Exports the saved facts to a text file.
    /// Resource referenced for writing inside the emulator: https://learn.microsoft.com/en-us/answers/questions/991205/how-to-write-a-text-file-in-maui
    /// </summary>
    public async void ButtonExport_Clicked(object sender, EventArgs e)
    {
        await controller.ExportFactsControl();
    }

    public async void ButtonTest_Clicked(object sender, EventArgs e)
    {
        bool test = await controller.TestApiControl();

        if (test == true)
        {
            await DisplayAlert("Test","Api Test Successful", "Ok");
        }
        else
        {
            await DisplayAlert("Test", "Api Test Failed", "Ok");
        }

    }

    private void ButtonReset_Clicked(object sender, EventArgs e)
    {
        controller.ResetDefaultsControl();


        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;

        SetButton();

    }
}