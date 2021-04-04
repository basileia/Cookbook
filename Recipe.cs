using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> IngredientsList { get; set; }
        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }
        public List<Category> Categories;

        public Recipe(string name, List<Ingredient> ingredientsList, string preparation, List<Category> categories, int numberOfServings = 2)
        {
            Name = name;
            IngredientsList = ingredientsList;
            Preparation = preparation;
            Categories = categories;
            NumberOfServings = numberOfServings;
        }

    }
}
