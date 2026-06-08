using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CatFactApp
{
    public class ApiService
    {
        public async Task<CatFact> GetFact()
        {

            HttpClient client = new();

            string url = "https://meowfacts.herokuapp.com/";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new CatFact();
            }

            string json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CatFact>(json);

            return result;
        }

        public async Task<string> GetDogURL()
        {
            HttpClient client = new();

            string url = "https://dog.ceo/api/breeds/image/random";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return "None";
            }

            string json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<DogResponse>(json);

            return result.message;


        }


    }
}
