using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRwebMVC.Data;
using SRwebMVC.Entities;
using SRwebMVC.Models.DTOs;
/* Recipes API
 * 
 * GETS:
 * Get all recipes (paginated)
 * - Query parameters for searching by name, category, ingredient, etc.
 * Get recipe by ID
 * 
 * POST:
 * Post a new recipe
 * 
 * PATCH:
 * Add a new ingredient to a recipe
 * Add a new category to a recipe
 * Add a new step to a recipe
 * Edit an existing recipe
 * 
 * DELETE:
 * Delete a recipe
 * Remove an ingredient from a recipe
 * Remove a category from a recipe
 * Remove a step from a recipe
 * 
 */
namespace SRwebMVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes([FromQuery] string? recipeName, [FromQuery] string? ingredientName, [FromQuery] string? categoryName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            IQueryable<Recipe> query = _context.Recipes
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Quantity)
                .Include(r => r.RecipeCategories).ThenInclude(rc => rc.Category);

            if (!string.IsNullOrWhiteSpace(recipeName))
                query = query.Where(r => r.Name.ToLower().Contains(recipeName.ToLower()));
            if (!string.IsNullOrWhiteSpace(ingredientName))
                query = query.Where(r => r.RecipeIngredients.Any(ri => ri.Ingredient.Name.ToLower().Contains(ingredientName.ToLower())));
            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(r => r.RecipeCategories.Any(rc => rc.Category.Name.ToLower().Contains(categoryName.ToLower())));

            query = query.OrderBy(r => r.Name).ThenBy(r => r.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var result = await query
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTime = r.PrepTime,
                    CookTime = r.CookTime,
                    Ingredients = r.RecipeIngredients.Select(ri => new RecipeIngredientDto
                    {
                        IngredientId = ri.IngredientId,
                        IngredientName = ri.Ingredient.Name,
                        Amount = ri.Amount,
                        QuantityId = ri.QuantityId,
                        QuantityName = ri.Quantity.Name
                    }).ToList(),
                    Categories = r.RecipeCategories.Select(rc => new RecipeCategoryDto
                    {
                        CategoryId = rc.CategoryId,
                        CategoryName = rc.Category.Name
                    }).ToList(),
                    Steps = r.Steps
                        .OrderBy(s => s.StepNumber)
                        .Select(s => new RecipeStepDto { StepNumber = s.StepNumber, Description = s.Description
                    }).ToList(),
                })
                .ToListAsync();

            return result;
        }

        // GET: api/recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Quantity)
                .Include(r => r.RecipeCategories).ThenInclude(rc => rc.Category)
                .Where(r => r.Id == id)
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTime = r.PrepTime,
                    CookTime = r.CookTime,
                    Ingredients = r.RecipeIngredients.Select(ri => new RecipeIngredientDto
                    {
                        IngredientId = ri.IngredientId,
                        IngredientName = ri.Ingredient.Name,
                        Amount = ri.Amount,
                        QuantityId = ri.QuantityId,
                        QuantityName = ri.Quantity.Name
                    }).ToList(),
                    Categories = r.RecipeCategories.Select(rc => new RecipeCategoryDto
                    {
                        CategoryId = rc.CategoryId,
                        CategoryName = rc.Category.Name
                    }).ToList(),
                    Steps = r.Steps
                        .OrderBy(s => s.StepNumber)
                        .Select(s => new RecipeStepDto { StepNumber = s.StepNumber, Description = s.Description
                    }).ToList(),
                })
                .FirstOrDefaultAsync();

            if (recipe == null)
                return NotFound();

            return recipe;
        }

        // POST: api/recipes
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe([FromBody] CreateRecipeDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Invalid recipe data.");
            Recipe recipe = new Recipe
            {
                Name = dto.Name,
                PrepTime = dto.PrepTime,
                CookTime = dto.CookTime,
                RecipeIngredients = new List<RecipeIngredient>(),
                RecipeCategories = new List<RecipeCategory>(),
                Steps = new List<RecipeStep>()
            };
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        // PUT: api/recipes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, [FromBody] CreateRecipeDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Invalid recipe data.");
            Recipe? recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound();
            recipe.Name = dto.Name;
            recipe.PrepTime = dto.PrepTime;
            recipe.CookTime = dto.CookTime;
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PATCH: api/recipes/{id}/addingredient
        [HttpPatch("{id}/addingredient")]
        public async Task<IActionResult> AddIngredientToRecipe(int id, [FromBody] AddIngredientDto dto)
        {
            Recipe? recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            Ingredient? ingredient = await _context.Ingredients.FindAsync(dto.IngredientId);
            if (ingredient == null)
                return NotFound("Ingredient not found.");

            Quantity? quantity = await _context.Set<Quantity>().FindAsync(dto.QuantityId);
            if (quantity == null)
                return NotFound("Quantity not found.");

            if (recipe.RecipeIngredients.Any(ri => ri.IngredientId == dto.IngredientId))
                return Conflict("Ingredient already exists in recipe.");

            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                RecipeId = id,
                IngredientId = dto.IngredientId,
                Amount = dto.Amount,
                QuantityId = dto.QuantityId,
                Recipe = recipe,
                Ingredient = ingredient,
                Quantity = quantity
            };

            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/recipes/{id}/addcategory
        [HttpPatch("{id}/addcategory")]
        public async Task<IActionResult> AddCategoryToRecipe(int id, [FromBody] AddCategoryDto dto)
        {
            Recipe? recipe = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            Category? category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
                return NotFound("Category not found.");

            if (recipe.RecipeCategories.Any(rc => rc.CategoryId == dto.CategoryId))
                return Conflict("Category already exists in recipe.");

            RecipeCategory recipeCategory = new RecipeCategory
            {
                RecipeId = id,
                CategoryId = dto.CategoryId,
                Recipe = recipe,
                Category = category
            };

            _context.RecipeCategories.Add(recipeCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/recipes/{id}/edit
        [HttpPatch("{id}/edit")]
        public async Task<IActionResult> EditRecipe(int id, [FromBody] EditRecipeDto dto)
        {
            Recipe? recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(dto.Name))
                recipe.Name = dto.Name;
            recipe.PrepTime = dto.PrepTime;
            recipe.CookTime = dto.CookTime;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PATCH : api/recipes/{id}/addstep
        [HttpPatch("{id}/addstep")]
        public async Task<IActionResult> AddStepToRecipe(int id, [FromBody] AddStepDto dto)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Steps)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            int nextStepNumber = recipe.Steps.Any() ? recipe.Steps.Max(s => s.StepNumber) + 1 : 1;

            var step = new RecipeStep
            {
                StepNumber = nextStepNumber,
                Description = dto.Description,
                RecipeId = id
            };

            recipe.Steps.Add(step);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return NotFound();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/recipes/{id}/removeingredient/{ingredientId}
        [HttpDelete("{id}/removeingredient/{ingredientId}")]
        public async Task<IActionResult> RemoveIngredientFromRecipe(int id, int ingredientId)
        {
            RecipeIngredient? recipeIngredient = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == id && ri.IngredientId == ingredientId);

            if (recipeIngredient == null)
                return NotFound();

            _context.RecipeIngredients.Remove(recipeIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/recipes/{id}/removecategory/{categoryId}]
        [HttpDelete("{id}/removecategory/{categoryId}")]
        public async Task<IActionResult> RemoveCategoryFromRecipe(int id, int categoryId)
        {
            RecipeCategory? recipeCategory = await _context.RecipeCategories
                .FirstOrDefaultAsync(rc => rc.RecipeId == id && rc.CategoryId == categoryId);

            if (recipeCategory == null)
                return NotFound();

            _context.RecipeCategories.Remove(recipeCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/recipes/{id}/removeinstruction/{instructionId}
        [HttpDelete("{id}/removeinstruction/{instructionId}")]
        public async Task<IActionResult> RemoveInstructionFromRecipe(int id, int instructionId)
        {
            RecipeStep? step = await _context.RecipeSteps
                .FirstOrDefaultAsync(s => s.RecipeId == id && s.StepNumber == instructionId);
            if (step == null)
                return NotFound();
            _context.RecipeSteps.Remove(step);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
