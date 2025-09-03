﻿namespace WebMVC.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<RecipeCategory> RecipeCategories { get; set; } = [];
    }
}