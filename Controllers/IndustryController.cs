using Microsoft.AspNetCore.Mvc;
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
            List<IndustryModel> industries = await _repository.GetIndustries();
            return View(industries);
        }
    }
}
