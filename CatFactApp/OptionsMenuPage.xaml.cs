//using Android.OS;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace CatFactApp;

public partial class OptionsMenuPage : ContentPage
{
    ApiService service = new ApiService();

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
    }

    private void ButtonSmall_Clicked(object sender, EventArgs e)
    {
        PreferencesService.HeaderSize = 18;
        PreferencesService.BodySize = 12;

        
        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;
    }

    private void ButtonMedium_Clicked(object sender, EventArgs e)
    {
        PreferencesService.HeaderSize = 22;
        PreferencesService.BodySize = 14;

        
        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;
    }

    private void ButtonLarge_Clicked(object sender, EventArgs e)
    {
        PreferencesService.HeaderSize = 26;
        PreferencesService.BodySize = 18;

        
        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;
    }

    /// <summary>
    /// Exports the saved facts to a text file.
    /// Resource referenced for writing inside the emulator: https://learn.microsoft.com/en-us/answers/questions/991205/how-to-write-a-text-file-in-maui
    /// </summary>
    public async void ButtonExport_Clicked(object sender, EventArgs e)
    {
        var facts = await App.DatabaseService.GetFactsAsync();
        string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "SavedFacts.txt");

        using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);
        foreach (var fact in facts)
        {
            await streamWriter.WriteLineAsync(fact.fact);
        }


    }

    public async void ButtonTest_Clicked(object sender, EventArgs e)
    {
        try
        {
            var fact = await service.GetFact();
            await DisplayAlert("Success", "API Fetched Successfully", "Okay");
        }
        catch (Exception)
        {
            await DisplayAlert("Failed", "API Could Not Be fetched", "Okay");
        }
    }

    private void ButtonReset_Clicked(object sender, EventArgs e)
    {
        PreferencesService.HeaderSize = 22;
        PreferencesService.BodySize = 14;


        OptionsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonSmall.FontSize = PreferencesService.BodySize;
        ButtonMedium.FontSize = PreferencesService.BodySize;
        ButtonLarge.FontSize = PreferencesService.BodySize;
        ButtonExport.FontSize = PreferencesService.BodySize;
        ButtonTest.FontSize = PreferencesService.BodySize;
        ButtonReset.FontSize = PreferencesService.BodySize;
    }
}