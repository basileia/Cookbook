using System;
using System.Collections.Generic;

namespace Cookbook
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> IngredientsList { get; set; }
        public List<Ingredient> ConvertedIngredients { get; set; }
        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }
        public List<Category> Categories { get; set; }

        public Recipe(string name)
        {
            Name = name;
            IngredientsList = new List<Ingredient>();
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public List<Ingredient> ConvertToTheNumberOfServings(int servings)
        {
            List<Ingredient> convertedIngredients = IngredientsList.ConvertAll(x => new Ingredient(x));
            convertedIngredients.ForEach(i => i.Quantity = Math.Round(i.Quantity / NumberOfServings * servings, 2));
            return convertedIngredients;

        }
    }
}
