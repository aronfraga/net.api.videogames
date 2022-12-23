using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using videogames_api.Models;
using videogames_api.Utils;
using static System.Net.WebRequestMethods;

namespace videogames_api.Services {
    public class VideogameService {

        public async Task<VideogameApiMain> GetAllDataApi() {
            string url = "https://api.rawg.io/api/games?key=86495924444f4f4ebc340686b46b25c7";
            
            HttpClient client = new HttpClient();
            var httpResponse = await client.GetAsync(url);
            var posts = new VideogameApiMain();

            if (httpResponse.IsSuccessStatusCode) {
                var content = await httpResponse.Content.ReadAsStringAsync();
                posts = JsonSerializer.Deserialize<VideogameApiMain>(content);
            }

            return posts;
        }
    }
}