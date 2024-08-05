using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using IndustryApiExample.Models;
using IndustryApiExample.Repositories;

namespace IndustryApiExample.Controllers
{
    public class IndustryController : Controller
    {
        private readonly IIndustryRepository _repository;

        public IndustryController(IIndustryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Call the industry API and store the response in a variable
            //var industryResponse = await MakeGetRequest("http://api.example.com/api/industries");

            List<IndustryModel> industries = await _repository.GetIndustries();

            return View(industries);

            //if (industryResponse != null)
            //    return View(industryResponse);
            //else
            //    return ViewStaticData();
        }

        private async Task<string> MakeGetRequest(string url)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Failed to get industries from {url}: Status Code - {(int)response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error making GET request: {ex.Message}");
                return null;
            }
        }

        private IActionResult ViewStaticData()
        {
            // Return some static data in case the external API call fails
            var industryModel = new IndustryModel
            {
                //Industry = "Software Development",
                //Description = "The process of designing, developing, and testing software applications.",
                //Positions = new string[] { "Software Engineer", "DevOps Engineer" },
                //AverageSalaries = new AverageSalary[]
                //{
                //    new AverageSalary { Title = "Software Engineer", Salary = "$100,000 - $200,000 per year" },
                //    new AverageSalary { Title = "DevOps Engineer", Salary = "$80,000 - $150,000 per year" }
                //}
            };

            return View(industryModel);
        }
    }
}