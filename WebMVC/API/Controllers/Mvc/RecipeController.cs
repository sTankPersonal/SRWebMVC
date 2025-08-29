using Microsoft.AspNetCore.Mvc;
using WebMVC.Contracts.DTOs.Recipe;
using WebMVC.Models.DTOs;
using WebMVC.Models.ViewModels;

namespace WebMVC.API.Controllers.Mvc
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

        public async Task<IActionResult> Index(
            string? searchName,
            string? searchIngredient,
            string? searchCategory,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var url = $"/api/recipe?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchName))
                url += $"&recipeName={Uri.EscapeDataString(searchName)}";
            if (!string.IsNullOrWhiteSpace(searchIngredient))
                url += $"&ingredientName={Uri.EscapeDataString(searchIngredient)}";
            if (!string.IsNullOrWhiteSpace(searchCategory))
                url += $"&categoryName={Uri.EscapeDataString(searchCategory)}";

            var recipes = await _httpClient.GetFromJsonAsync<List<RecipeDto>>(url) ?? new List<RecipeDto>();

            var viewModel = new RecipeListViewModel
            {
                Recipes = recipes,
                SearchName = searchName,
                SearchIngredient = searchIngredient,
                SearchCategory = searchCategory,
                PageNumber = pageNumber,
                PageSize = pageSize,
                HasNextPage = recipes.Count == pageSize
            };

            return View("List", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _httpClient.GetFromJsonAsync<RecipeDto>($"/api/recipe/{id}");
            if (recipe == null)
                return NotFound();

            return View("Delete", recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/recipe/{id}");
            // Optionally handle response errors here
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _httpClient.GetFromJsonAsync<RecipeDto>($"/api/recipe/{id}");
            if (recipe == null)
                return NotFound();

            return View("Details", recipe);
        }

        [HttpGet, ActionName("Create")]
        public IActionResult CreateStep1()
        {
            return View("CreateStep1", new RecipeCreateStep1ViewModel());
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep1(RecipeCreateStep1ViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("CreateStep1", vm);

            var createDto = new CreateRecipeDto
            {
                Name = vm.Name,
                PrepTime = vm.PrepTime,
                CookTime = vm.CookTime
            };

            var response = await _httpClient.PostAsJsonAsync("/api/recipe", createDto);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create recipe.");
                return View("CreateStep1", vm);
            }

            var createdRecipe = await response.Content.ReadFromJsonAsync<RecipeDto>();
            int recipeId = createdRecipe?.Id ?? 0;

            // Redirect to step 2
            return RedirectToAction("Edit", new { id = recipeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _httpClient.GetFromJsonAsync<RecipeDto>($"/api/recipe/{id}");
            if (recipe == null)
                return NotFound();
            var vm = new RecipeCreateViewModel
            {
                Name = recipe.Name,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                Categories = recipe.Categories ?? new List<RecipeCategoryDto>(),
                Ingredients = recipe.Ingredients ?? new List<RecipeIngredientDto>(),
                Steps = recipe.Steps ?? new List<RecipeStepDto>()
            };

            ViewBag.RecipeId = id;
            return View("Edit", vm);
        }

        [HttpPost("Recipe/{id}/updaterecipe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRecipe(int id, [FromForm] EditRecipeDto dto)
        {
            await _httpClient.PutAsJsonAsync($"/api/recipe/{id}", dto);
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost("Recipe/{id}/addcategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(int id, AddCategoryDto dto)
        {
            await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addcategory", dto);
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost("Recipe/{id}/addingredient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(int id, AddIngredientDto dto)
        {
            await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addingredient", dto);
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost("Recipe/{id}/addstep")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStep(int id, AddStepDto dto)
        {
            dto.RecipeId = id; // Ensure RecipeId is set in DTO
            await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addstep", dto);
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveIngredient(int id, int ingredientId)
        {
            var response = await _httpClient.DeleteAsync($"/api/recipe/{id}/removeingredient/{ingredientId}");
            if (!response.IsSuccessStatusCode)
                TempData["Error"] = "Failed to remove ingredient.";
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCategory(int id, int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"/api/recipe/{id}/removecategory/{categoryId}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to remove category.";
            }
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveStep(int id, int instructionId)
        {
            var response = await _httpClient.DeleteAsync($"/api/recipe/{id}/removeinstruction/{instructionId}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to remove instruction.";
            }
            return RedirectToAction("Edit", new { id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIngredient(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["Error"] = "Ingredient name is required.";
                return RedirectToAction("Edit", new { id });
            }

            var payload = new { Name = name };
            var response = await _httpClient.PostAsJsonAsync("/api/ingredient", payload);

            if (!response.IsSuccessStatusCode)
                TempData["Error"] = "Failed to create ingredient.";

            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["Error"] = "Category name is required.";
                return RedirectToAction("Edit", new { id });
            }

            var payload = new { Name = name };
            var response = await _httpClient.PostAsJsonAsync("/api/category", payload);

            if (!response.IsSuccessStatusCode)
                TempData["Error"] = "Failed to create category.";

            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuantity(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["Error"] = "Quantity name is required.";
                return RedirectToAction("Edit", new { id });
            }

            var payload = new { Name = name };
            var response = await _httpClient.PostAsJsonAsync("/api/quantity", payload);

            if (!response.IsSuccessStatusCode)
                TempData["Error"] = "Failed to create quantity.";

            return RedirectToAction("Edit", new { id });
        }
    }
}
