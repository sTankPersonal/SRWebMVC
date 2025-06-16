using Microsoft.AspNetCore.Mvc;
using SRwebMVC.Models.DTOs;
using SRwebMVC.Models.ViewModels;

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
                CookTime = vm.CookTime,
                Steps = new List<RecipeStepDto>() // Empty for now
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
            return RedirectToAction("Attach", new { id = recipeId });
        }

        [HttpGet, ActionName("Attach")]
        public async Task<IActionResult> CreateStep2(int id)
        {
            var recipe = await _httpClient.GetFromJsonAsync<RecipeDto>($"/api/recipe/{id}");
            if (recipe == null)
                return NotFound();

            var categories = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/api/category");
            var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDto>>("/api/ingredient");
            var quantities = await _httpClient.GetFromJsonAsync<List<QuantityDto>>("/api/quantity");

            var vm = new RecipeCreateViewModel
            {
                Name = recipe.Name,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
            };
            ViewBag.RecipeId = id;
            return View("CreateStep2", vm);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateStep2(int id, RecipeCreateViewModel vm)
        //{
        //    // Attach categories
        //    foreach (var catId in vm.SelectedCategoryIds)
        //        await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addcategory", new AddCategoryDto { CategoryId = catId });

        //    // Attach ingredients
        //    foreach (var ing in vm.Ingredients)
        //        await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addingredient", new AddIngredientDto
        //        {
        //            IngredientId = ing.IngredientId,
        //            Amount = ing.Amount,
        //            QuantityId = ing.QuantityId
        //        });

        //    // Attach steps (optional: PATCH or PUT if you want to update steps)
        //    // You can add a PATCH endpoint for steps if needed.

        //    return RedirectToAction("Details", new { id });
        //}

        [HttpPost, ActionName("Attach")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep2(int id, RecipeCreateViewModel vm, string action)
        {
            if (action == "addCategory")
            {
                var category = await _httpClient.GetFromJsonAsync<CategoryDto>($"/api/category/{vm.NewCategoryId}");
                if (category != null && !vm.Categories.Any(c => c.Id == category.Id))
                {
                    vm.Categories.Add(category);
                }
            }

            else if (action == "addIngredient" && vm.NewIngredientId > 0 && vm.NewIngredientAmount > 0 && vm.NewIngredientQuantityId > 0)
            {
                var ingredient = await _httpClient.GetFromJsonAsync<IngredientDto>($"/api/ingredient/{vm.NewIngredientId}");
                var quantity = await _httpClient.GetFromJsonAsync<QuantityDto>($"/api/quantity/{vm.NewIngredientQuantityId}");
                if (ingredient != null && quantity != null)
                {
                    vm.Ingredients.Add(new RecipeIngredientDto
                    {
                        IngredientId = ingredient.Id,
                        IngredientName = ingredient.Name,
                        Amount = vm.NewIngredientAmount,
                        QuantityId = quantity.Id,
                        QuantityName = quantity.Name
                    });
                }
            }
            else if (action == "addStep" && !string.IsNullOrWhiteSpace(vm.NewStepDescription))
            {
                int nextStep = (vm.Steps.Count > 0) ? vm.Steps.Max(s => s.StepNumber) + 1 : 1;
                vm.Steps.Add(new RecipeStepDto
                {
                    StepNumber = nextStep,
                    Description = vm.NewStepDescription
                });
            }
            else if (action == "finish")
            {
                // Attach categories
                foreach (var category in vm.Categories)
                    await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addcategory", new AddCategoryDto { CategoryId = category.Id });

                // Attach ingredients
                foreach (var ing in vm.Ingredients)
                    await _httpClient.PatchAsJsonAsync($"/api/recipe/{id}/addingredient", new AddIngredientDto
                    {
                        IngredientId = ing.IngredientId,
                        Amount = ing.Amount,
                        QuantityId = ing.QuantityId
                    });

                // Attach steps (if you have a PATCH endpoint for steps, call it here)

                return RedirectToAction("Details", new { id });
            }

            ViewBag.RecipeId = id;
            // Clear new item fields after add
            vm.NewCategoryId = 0;
            vm.NewIngredientId = 0;
            vm.NewIngredientAmount = 0;
            vm.NewIngredientQuantityId = 0;
            vm.NewStepDescription = string.Empty;
            return View("CreateStep2", vm);
        }
    }
}
