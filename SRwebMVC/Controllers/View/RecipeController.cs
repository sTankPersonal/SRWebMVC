using Microsoft.AspNetCore.Mvc;
using SRwebMVC.Models.DTOs;

namespace SRwebMVC.Controllers.View
{
    public class RecipeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public RecipeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("ApiClient");
        }
        public async Task<IActionResult> Index()
        {
            var recipes = await _httpClient.GetFromJsonAsync<List<RecipeDto>>("/api/recipe");
            return View("List", recipes ?? new List<RecipeDto>());
        }
    }
}
