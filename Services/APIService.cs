using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MoviesApp.Models;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;

namespace MoviesApp.Services
{
    public class APIService : IAPIService
    {
        private static string API_URL;

        public APIService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            API_URL = builder.GetSection("ApiSetting:ApiUrl").Value;
        }

        public async Task<List<Movie>> GetMovieByName(string name)
        {
            List<Movie> movies = new List<Movie>();

            var client = new HttpClient();
            string URL;
            if (!string.IsNullOrEmpty(name))
            {
                URL = API_URL + "&s=" + name;
            }
            else
            {
                URL = API_URL + "&s=the lord of the rings";
            }
            var response = await client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<Responses>(result).Search;
            }

            return movies;
        }

        public async Task<Movie> GetMovieById(string ID)
        {
            Movie movie = new Movie();

            var client = new HttpClient();
            var response = await client.GetAsync(API_URL + "&i=" + ID);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(result);
            }

            return movie;
        }
    }
}
