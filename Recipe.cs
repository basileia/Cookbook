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

        public Recipe(string name, string preparation, List<Category> categories, int numberOfServings = 2)
        {
            Name = name;
            IngredientsList = new List<Ingredient>();
            Preparation = preparation;
            Categories = categories;
            NumberOfServings = numberOfServings;
        }

        public void AddIngredient()
        {
            string name;
            double quantity;
            string unit;

            name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název ingredience: ");
            quantity = AuxiliaryMethod.LoadNumberFromConsole("Zadejte množství: ");
            unit = AuxiliaryMethod.LoadStringFromConsole("Zadejte jednotku: ");

            IngredientsList.Add(new Ingredient(name, quantity, unit));

        }

        
    }
}
