using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactApp
{
    public class SQLService
    {

        private SQLiteAsyncConnection database;

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

        public SQLService(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<DisplayFact>().Wait();
        }

        public Task<List<DisplayFact>> GetFactsAsync()
        {
            return database.Table<DisplayFact>().ToListAsync();
        }

        public async Task<int> SaveFactAsync(DisplayFact fact)
        {
            var allFacts = await GetFactsAsync();

            if (allFacts.Count >= 10)
            {
                var sorted = AscendingBubbleSort(allFacts);
                var oldest = sorted[0];
                await database.DeleteAsync(oldest);
            }

            return await database.InsertAsync(fact);
        }

        public Task<int> DeleteFactAsync(DisplayFact fact)
        {
            return database.DeleteAsync(fact);
        }
    }
}
