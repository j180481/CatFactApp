namespace CatFactApp;

public partial class SavedFactsPage : ContentPage
{

    public SavedFactsPage()
	{
        InitializeComponent();

        UpdateList();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        SavedFactsHeader.FontSize = PreferencesService.HeaderSize;
        ButtonAscending.FontSize = PreferencesService.BodySize;
        ButtonDescending.FontSize = PreferencesService.BodySize;
        await UpdateList();
    }

    private List<DisplayFact> AscendingBubbleSort(List<DisplayFact> facts)
    {
        var sorted = new List<DisplayFact>(facts);
        DisplayFact temp;
        bool swapped = false;

        for (int i = 0; i < sorted.Count - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < sorted.Count - 1; j++)
            {
                if (sorted[j].time > sorted[j + 1].time)
                {
                    temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        return sorted;
    }

    private List<DisplayFact> DescendingBubbleSort(List<DisplayFact> facts)
    {
        var sorted = new List<DisplayFact>(facts);
        DisplayFact temp;
        bool swapped = false;

        for (int i = 0; i < sorted.Count - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < sorted.Count - 1; j++)
            {
                if (sorted[j].time < sorted[j + 1].time)
                {
                    temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }

        return sorted;
    }

    public async Task UpdateList()
	{
        var facts = await App.DatabaseService.GetFactsAsync();
        foreach (var fact in facts)
            fact.FontSize = PreferencesService.BodySize;
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = facts;

    }

    private async void ButtonAscending_Clicked(object sender, EventArgs e)
    {
        var facts = await App.DatabaseService.GetFactsAsync();
        var sorted = AscendingBubbleSort(facts);
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = sorted;
    }

    private async void ButtonDescending_Clicked(object sender, EventArgs e)
    {
        var facts = await App.DatabaseService.GetFactsAsync();
        var sorted = DescendingBubbleSort(facts);
        FactsCollectionView.ItemsSource = null;
        FactsCollectionView.ItemsSource = sorted;
    }
}