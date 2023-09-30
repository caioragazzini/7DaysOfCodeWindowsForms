using GameofThronesAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameofThronesAPI.Services
{
    public class ThronesApiService : IThronesApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string uri = "https://thronesapi.com/api/v2/";
        private object response;

        public ThronesApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(uri);
        }

        public async Task<Characters> GetCharacterById(int id)
        {
            var response = await _httpClient.GetAsync($"Characters/{id}");
            try
            {              
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var character = JsonConvert.DeserializeObject<Characters>(content);
                return character;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível obter o personagem : " + response.StatusCode);
                throw ex;
            }
        }
        public async Task<List<Characters>> GetCharacter()
        {
            var response = await _httpClient.GetAsync($"Characters");
            try
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    PropertyNameCaseInsensitive = true
                };
                List<Characters> character = System.Text.Json.JsonSerializer.Deserialize<List<Characters>>(content, options);
                return character;

                


               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível obter o personagem : " + response.StatusCode);
                throw ex;
            }
        }

     
    }
}
