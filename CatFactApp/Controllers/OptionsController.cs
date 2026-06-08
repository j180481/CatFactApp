using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFactApp.Models;
using CatFactApp.Services;


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

        public async Task ExportFactsControl()
        {
            var facts = await App.DatabaseService.GetFactsAsync();
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "SavedFacts.txt");

            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            foreach (var fact in facts)
                await streamWriter.WriteLineAsync(fact.fact);

            await Share.Default.RequestAsync(new ShareFileRequest
            {
                Title = "Export Saved Facts",
                File = new ShareFile(targetFile)
            });
        }

        public int GetCurrentSizeControl()
        {
            return PreferencesService.HeaderSize;
        }

    }
}
