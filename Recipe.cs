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

        public void RemoveIngredient()
        {
            string ingredientToRemove = AuxiliaryMethod.LoadStringFromConsole("Kterou ingredienci chcete odebrat? ");
            if (IngredientsList.Any(i => i.Name == ingredientToRemove))
            {
                IngredientsList.RemoveAll(x => x.Name == ingredientToRemove);
                return;
            }
            Console.WriteLine("Tato ingredience v receptu není.");
            
        }

        public void ViewRecipe()
        {
            Console.WriteLine($"NÁZEV RECEPTU:\n{Name}");
            Console.WriteLine("SEZNAM INGREDIENCÍ: ");
            IngredientsList.ForEach(i => Console.Write($"{i.Name}: {i.Quantity} {i.Unit}\n"));
            Console.WriteLine($"PŘÍPRAVA:\n{Preparation}\nPOČET PORCÍ: {NumberOfServings}");
            Console.WriteLine("KATEGORIE: " + String.Join(", ", Categories));
           
        }

        public void ConvertToTheNumberOfServings(int servings)
        {
            List<Ingredient> convertedIngredients = IngredientsList.ConvertAll(x => new Ingredient(x));
            Console.WriteLine($"Přepočítané ingredience na počet porcí: {servings}");
            convertedIngredients.ForEach(i => Console.Write($"{i.Name}: {i.Quantity} {i.Unit}\n"));

        }
    }
}
