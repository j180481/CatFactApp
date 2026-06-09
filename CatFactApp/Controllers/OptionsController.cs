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

        ApiService apiService = new ApiService();




        //Use this to retrieve the current saved header size as an int
        public int GetHeaderSize()
        {
            return PreferencesService.HeaderSize;
        }

        public int GetBodySize()
        {
            return PreferencesService.BodySize;
        }

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
                await apiService.GetFact();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Uses FileSaver. Allows user to choose where they save a file.
        /// Resource: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=android
        /// </summary>
        public async Task<int> ExportFactsControl()
        {
            //retrieve facts from database
            var facts = await App.DatabaseService.GetFactsAsync();

            //if the saved list is empty return without exporting
            if (facts.Count == 0)
            {
                return 0;
            }

            //build a string of all the facts with newlines between
            string file = "";
            foreach (var fact in facts)
            {
                file += fact.fact + "\n";
            }

            //pass the string to be converted to memory stream
            //FileSaver opens allowing user to choose where to save the string as a text file
            using var stream = new MemoryStream(Encoding.Default.GetBytes(file));
            var result = await FileSaver.Default.SaveAsync("SavedFacts.txt", stream, CancellationToken.None);

            //return 1 if successful or -1 if failed
            if (result.IsSuccessful)
            {
                return 1;
            }
            else
            {
                return -1;
            }



        }

    }
}
