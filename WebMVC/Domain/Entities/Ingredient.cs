﻿namespace WebMVC.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}