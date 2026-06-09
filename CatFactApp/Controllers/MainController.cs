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
        ApiService apiService = new ApiService();
        int count = 0;
        int dogCount = 10;

        public int GetHeaderSize()
        {
            return PreferencesService.HeaderSize;
        }

        public int GetBodySize()
        {
            return PreferencesService.BodySize;
        }
    


        /// <summary>
        /// Getting the fact for display and returning with strings to update display with
        /// </summary>
        public async Task<(string headerText, string factText, string imageSource)> GetFactControl()
        {

            //Update the count, if it equals 10
            count++;
            if (count == dogCount)
            {
                //we try to retrieve the dog url to be set as the ImageSource
                try
                {
                    string dogUrl = await apiService.GetDogURL();

                    //return the count to zero
                    count = 0;

                    /*
                        return a tuple with three strings:
                        1. The HeaderText for dog time
                        2. the fact label text for dog time
                        3. and the url for the dog image
                        These are set in the view to update the UI
                    */
                    return ("Dog Time!!!!", "Ruff ruff ruff ruff ruff ruff ruff... woof", dogUrl);
                }
                catch
                {

                    // if it catches set the count to zero and return a tuple with strings indicating nothing could be retrieved
                    count = 0;

                    return ("Null", "null", "null");
                }
            }
            try // If it isn't dog time, try to get the cat fact
            {
                CatFact fact = await apiService.GetFact();

                /* 
                    return a tuble with three strings:
                    1. the string for the header when it is a cat fact
                    2. the string of returned fact from the api
                    3. the cat image from Resources/Images
                */
                return ("Meow Facts!", fact.data[0], "cat.png");
            }
            catch
            {
                // if it catches set the minus the current count to not lose pace and return a tuple with strings indicating nothing could be retrieved
                count -= 1;

                return ("Null", "null", "null");
            }
        } 

        /// <summary>
        /// Validates that the fact label is a valid fact before saving to database.
        /// </summary>
        public async Task<int> SaveFactControl(string factText, string factHeader)
        {
            /*
             In the view we pass the factLabel and catfactheader
             If the factLabel is currently the default "Meow!!!"
             Or we are currently in dog time, by checking the factHeader
             Then we return -1 
            */
            if (factText == "Meow!!!" || factHeader == "Dog Time!!!!")
            {
                return -1;
            }

            //Otherwise, create the display fact
            var fact = new DisplayFact
            {
                fact = factText,
                time = DateTime.Now
            };

            //Save the fact
            int response = await App.DatabaseService.SaveFactAsync(fact);

            return response;
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
