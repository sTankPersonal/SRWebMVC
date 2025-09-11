using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Application.Services.Implementations
{
    public class IngredientService(IIngredientRepository ingredientRepository, IIngredientValidator ingredientValidator) : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
        private readonly IIngredientValidator _ingredientValidator = ingredientValidator;

        public async Task<IEnumerable<IngredientDto>> GetAllAsync(IngredientQuery query)
        {
            IEnumerable<Ingredient> ingredients = await _ingredientRepository.GetAllAsync(query);
            return ingredients.Select(i => new IngredientDto
            {
                Id = i.Id,
                Name = i.Name
            });
        }
        public async Task<IngredientDto> GetByIdAsync(int id)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Ingredient with id {id} not found.");
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
        public async Task<IngredientDto> CreateAsync(CreateIngredientDto ingredientCreateDto)
        {
            Ingredient ingredient = new()
            {
                Name = ingredientCreateDto.Name
            };
            await _ingredientValidator.ValidateCreateAsync(ingredient);
            await _ingredientRepository.AddAsync(ingredient);
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
        public async Task<IngredientDto> UpdateAsync(int id, UpdateIngredientDto ingredientUpdateDto)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Ingredient with id {id} not found.");

            ingredient.Name = ingredientUpdateDto.Name;
            await _ingredientValidator.ValidateUpdateAsync(ingredient);
            await _ingredientRepository.UpdateAsync(ingredient);
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
        public async Task DeleteAsync(int id)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Ingredient with id {id} not found.");
            await _ingredientValidator.ValidateDeleteAsync(ingredient);
            await _ingredientRepository.DeleteAsync(ingredient);
        }
    }
}
