using CatFactApp.Controllers;
using CatFactApp.Models;
using CatFactApp.Services;

namespace CatFactApp.Views;

public partial class SavedFactsPage : ContentPage
{

    SavedFactsController controller = new SavedFactsController();

    public SavedFactsPage()
	{
        InitializeComponent();

        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        SavedFactsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonAscending.FontSize = PreferencesService.BodySize;
        ButtonDescending.FontSize = PreferencesService.BodySize;
        await UpdateList();
    }


    public async Task UpdateList()
	{
        var facts = await controller.GetFactsControl();
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = facts;

    }

    private async void ButtonAscending_Clicked(object sender, EventArgs e)
    {
        var facts = await controller.GetAscendingControl();
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = facts;
    }

    private async void ButtonDescending_Clicked(object sender, EventArgs e)
    {
        var facts = await controller.GetDescendingControl();
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = facts;
    }


    /// <summary>
    /// Takes the swiped item, if it isnt null it casts it to a DisplayFact class object.
    /// Then it calls the database service delete function to delete the item and then updates the collection view.
    /// Primary Research Resource for code: https://www.youtube.com/watch?v=BHBYHC_9URc
    /// </summary>
    private async void OnDeleteSwipeInvoked(object sender, EventArgs e)
    {

        var swipedItem = sender as SwipeItem;

        if (swipedItem is null) return;

        var fact = swipedItem.BindingContext as DisplayFact;

        await controller.DeleteFactControl(fact);

        await UpdateList();
    }

}