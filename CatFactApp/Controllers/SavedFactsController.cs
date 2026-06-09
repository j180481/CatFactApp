using CatFactApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFactApp.Models;

namespace CatFactApp.Controllers
{
    public class SavedFactsController
    {

        public int GetHeaderSize()
        {
            return PreferencesService.HeaderSize;
        }

        public int GetBodySize()
        {
            return PreferencesService.BodySize;
        }



        public async Task<List<DisplayFact>> GetFactsControl()
        {
            var facts = await App.DatabaseService.GetFactsAsync();

            //setting the fact fontsize property so the text in the list can be same font size as the app
            foreach (var fact in facts)
                fact.FontSize = PreferencesService.BodySize;

            return facts;
        }

        public async Task DeleteFactControl(DisplayFact fact)
        {
            await App.DatabaseService.DeleteFactAsync(fact);
        }

        public async Task<List<DisplayFact>> GetAscendingControl()
        {
            var facts = await GetFactsControl();
            return AscendingBubbleSort(facts);
        }

        public async Task<List<DisplayFact>> GetDescendingControl()
        {
            var facts = await GetFactsControl();
            return DescendingBubbleSort(facts);
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

    }
}
