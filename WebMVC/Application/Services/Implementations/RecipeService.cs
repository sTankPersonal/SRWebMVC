using System.Security.Cryptography.X509Certificates;
using WebMVC.Application.DTOs.Category;
using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.DTOs.Recipe;
using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;
using WebMVC.Domain.ValueObjects;
namespace WebMVC.Application.Services.Implementations
{
    public class RecipeService (IRecipeRepository recipeRepository, IRecipeValidator recipeValidator): IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;
        private readonly IRecipeValidator _recipeValidator = recipeValidator;

        public async Task<IEnumerable<RecipeDto>> GetAllAsync(RecipeQuery query)
        {
            IEnumerable<Recipe> recipes = await _recipeRepository.GetAllAsync(query);
            return recipes.Select(r => new RecipeDto
            {
                Id = r.Id,
                Name = r.Name,
                PrepTimeMinutes = r.PrepTimeMinutes,
                CookTimeMinutes = r.CookTimeMinutes,
                Servings = r.Servings,
                Ingredients = [.. r.RecipeIngredients.Select(ri => new IngredientMeasurementDto
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Amount = ri.Measurement.Amount,
                    Unit = new UnitDto
                    {
                        Id = ri.Measurement.Unit.Id,
                        Name = ri.Measurement.Unit.Name,
                    }
                })],
                Categories = [.. r.RecipeCategories.Select(rc => new CategoryDto
                {
                    Id = rc.Category.Id,
                    Name = rc.Category.Name,
                })],
                Instructions = [.. r.Instructions.OrderBy(i => i.StepNumber).Select(i => new InstructionDto
                {
                    Id = i.Id,
                    StepNumber = i.StepNumber,
                    Description = i.Description,
                })],
            });
        }
        public async Task<RecipeDto?> GetByIdAsync(int id)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return null;
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                CookTimeMinutes = recipe.CookTimeMinutes,
                Servings = recipe.Servings,
                Ingredients = [.. recipe.RecipeIngredients.Select(ri => new IngredientMeasurementDto
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Amount = ri.Measurement.Amount,
                    Unit = new UnitDto
                    {
                        Id = ri.Measurement.Unit.Id,
                        Name = ri.Measurement.Unit.Name,
                    }
                })],
                Categories = [.. recipe.RecipeCategories.Select(rc => new CategoryDto
                {
                    Id = rc.Category.Id,
                    Name = rc.Category.Name,
                })],
                Instructions = [.. recipe.Instructions.OrderBy(i => i.StepNumber).Select(i => new InstructionDto
                {
                    Id = i.Id,
                    StepNumber = i.StepNumber,
                    Description = i.Description,
                })],
            };
           
        }
        public async Task<RecipeDto?> CreateAsync(CreateRecipeDto recipeCreateDto)
        {
            Recipe recipe = new()
            {
                Name = recipeCreateDto.Name,
                PrepTimeMinutes = recipeCreateDto.PrepTimeMinutes,
                CookTimeMinutes = recipeCreateDto.CookTimeMinutes,
                Servings = recipeCreateDto.Servings,
                RecipeIngredients = [],
                RecipeCategories = [],
                Instructions = [],
            };
           
            await _recipeValidator.ValidateCreateAsync(recipe);
            await _recipeRepository.AddAsync(recipe);
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                CookTimeMinutes = recipe.CookTimeMinutes,
                Servings = recipe.Servings,
                Ingredients = [],
                Categories = [],
                Instructions = [],
            };
        }
        public async Task<RecipeDto?> UpdateAsync(int id, UpdateRecipeDto recipeUpdateDto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return null;
            recipe.Name = recipeUpdateDto.Name;
            recipe.PrepTimeMinutes = recipeUpdateDto.PrepTimeMinutes;
            recipe.CookTimeMinutes = recipeUpdateDto.CookTimeMinutes;
            recipe.Servings = recipeUpdateDto.Servings;
            await _recipeValidator.ValidateUpdateAsync(recipe);
            await _recipeRepository.UpdateAsync(recipe);
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                CookTimeMinutes = recipe.CookTimeMinutes,
                Servings = recipe.Servings,
                Ingredients = [.. recipe.RecipeIngredients.Select(ri => new IngredientMeasurementDto
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Amount = ri.Measurement.Amount,
                    Unit = new UnitDto
                    {
                        Id = ri.Measurement.Unit.Id,
                        Name = ri.Measurement.Unit.Name,
                    }
                })],
                Categories = [.. recipe.RecipeCategories.Select(rc => new CategoryDto
                {
                    Id = rc.Category.Id,
                    Name = rc.Category.Name,
                })],
                Instructions = [.. recipe.Instructions.OrderBy(i => i.StepNumber).Select(i => new InstructionDto
                {
                    Id = i.Id,
                    StepNumber = i.StepNumber,
                    Description = i.Description,
                })],
            };
        }
        public async Task DeleteAsync(int id)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return;
            await _recipeRepository.DeleteAsync(recipe);
        }
    }
}
