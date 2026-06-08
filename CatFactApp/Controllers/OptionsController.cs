using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFactApp.Models;
using CatFactApp.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;


namespace CatFactApp.Controllers
{
    public class OptionsController
    {

        ApiService _apiService = new ApiService();

        public void SetSmallControl()
        {
            PreferencesService.HeaderSize = 18;
            PreferencesService.BodySize = 12;
        }

        public void SetMediumControl()
        {
            PreferencesService.HeaderSize = 22;
            PreferencesService.BodySize = 14;
        }

        public void SetLargeControl()
        {
            PreferencesService.HeaderSize = 26;
            PreferencesService.BodySize = 18;
        }

        public void ResetDefaultsControl()
        {
            PreferencesService.HeaderSize = 22;
            PreferencesService.BodySize = 14;
        }

        public async Task<bool> TestApiControl()
        {
            try
            {
                await _apiService.GetFact();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// Resource: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=android
        /// </summary>
        public async Task ExportFactsControl()
        {
            var facts = await App.DatabaseService.GetFactsAsync();

            string file = "";
            foreach (var fact in facts)
            {
                file += fact.fact + "\n";
            }

            using var stream = new MemoryStream(Encoding.Default.GetBytes(file));

            var result = await FileSaver.Default.SaveAsync("SavedFacts.txt", stream, CancellationToken.None);
            if (result.IsSuccessful)
            {
                await Toast.Make("File Saved").Show(CancellationToken.None);
            }
            else
            {
                await Toast.Make("File Failed to save").Show(CancellationToken.None);
            }



        }

    }
}
