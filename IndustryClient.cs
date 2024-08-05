// IndustryApiExample.Repositories.cs
using IndustryApiExample.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace IndustryApiExample.Repositories
{
    public interface IIndustryRepository
    {
        Task<List<IndustryModel>> GetIndustries();
    }

    public class IndustryRepository : IIndustryRepository
    {
        public async Task<List<IndustryModel>> GetIndustries()
        {
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync("https://api.example.com/api/industries");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<IndustryModel>>(json);
                }
                else
                {
                    throw new Exception($"Failed to get industries. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Load failsafe data if API call fails using the provided JSON file.
                var jsonFileContent = File.ReadAllText("faislafedata.json");
                return JsonConvert.DeserializeObject<List<IndustryModel>>(jsonFileContent);
            }
        }
    }
}
