using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFactApp.Models;
using CatFactApp.Services;

namespace CatFactApp.Controllers
{
    public class MainController
    {
        ApiService _apiService = new ApiService();
        int count = 0;
        int dogCount = 10;

        public async Task<(string headerText, string factText, string imageSource)> GetFactControl()
        {
            count++;
            if (count == dogCount)
            {
                string dogUrl = await _apiService.GetDogURL();
                count = 0;
                return ("Dog Time!!!!", "Ruff ruff ruff ruff ruff ruff ruff... woof", dogUrl);
            }

            CatFact fact = await _apiService.GetFact();
            return ("Meow Facts!", fact.data[0], "cat.png");
        }

        public async Task SaveFactControl(string factText)
        {
            var fact = new DisplayFact
            {
                fact = factText,
                time = DateTime.Now
            };
            await App.DatabaseService.SaveFactAsync(fact);
        }

        public async Task GoToAboutControl()
        {
            await Shell.Current.GoToAsync("AboutPage");
        }

        public async Task GoToOptionsControl()
        {
            await Shell.Current.GoToAsync("OptionsMenuPage");
        }

        public async Task GoToSavedFactsControl()
        {
            await Shell.Current.GoToAsync("SavedFactsPage");
        }
    }
}
