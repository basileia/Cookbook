using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> IngredientsList { get; set; }
        public int NumberOfServings { get; set; }
        public string Preparation { get; set; }
        public List<Category> Categories { get; set; }

        public Recipe(string name)
        {
            Name = name;
            IngredientsList = new List<Ingredient>();
            //Preparation = preparation;
            //Categories = categories;
            //NumberOfServings = numberOfServings;
        }

       public void AddIngredient()
        {
            string name;
            double quantity;
            string unit;

            name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název ingredience: ").ToLower();
            quantity = AuxiliaryMethod.LoadNumberFromConsole("Zadejte množství: ");
            unit = AuxiliaryMethod.LoadStringFromConsole("Zadejte jednotku: ");

            IngredientsList.Add(new Ingredient(name, quantity, unit));

        }

        public void RemoveIngredient()
        {
            string ingredientToRemove = AuxiliaryMethod.LoadStringFromConsole("Kterou ingredienci chcete odebrat? ").ToLower();
            if (IngredientsList.Any(i => i.Name == ingredientToRemove))
            {
                IngredientsList.RemoveAll(x => x.Name == ingredientToRemove);
                return;
            }
            Console.WriteLine("Tato ingredience v receptu není.");
            
        }

        public void ViewRecipe()
        {
            Console.WriteLine($"\nNÁZEV RECEPTU:\n{Name}");
            Console.WriteLine("SEZNAM INGREDIENCÍ: ");
            IngredientsList.ForEach(i => Console.Write($"{i.Name}: {i.Quantity} {i.Unit}\n"));
            Console.WriteLine($"PŘÍPRAVA:\n{Preparation}\nPOČET PORCÍ: {NumberOfServings}");
            Console.WriteLine("KATEGORIE: " + string.Join(", ", Categories) + "\n");
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void ConvertToTheNumberOfServings(int servings)
        {
            List<Ingredient> convertedIngredients = IngredientsList.ConvertAll(x => new Ingredient(x));
            convertedIngredients.ForEach(i => i.Quantity = i.Quantity / NumberOfServings * servings);
            Console.WriteLine($"Přepočítané ingredience pro recept na počet porcí: {servings}");
            convertedIngredients.ForEach(i => Console.Write($"{i.Name}: {i.Quantity} {i.Unit}\n"));

        }
    }
}
