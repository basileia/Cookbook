using System;
using System.Collections.Generic;

namespace Cookbook
{
    class RecipeConsoleUtility
    {
        public static List<Ingredient> CreateListOfIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string userInput = "";
            while (userInput != "n")
            {
                string name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název ingredience: ").ToLower();
                double quantity = AuxiliaryMethod.LoadNumberFromConsole("Zadejte množství: ");
                string unit = AuxiliaryMethod.LoadStringFromConsole("Zadejte jednotku: ");
                ingredients.Add(new Ingredient(name, quantity, unit));
                userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat další ingredienci? a/n");
            }
            return ingredients;
        }

        public static void ViewRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nNÁZEV RECEPTU:\n{recipe.Name}");
            Console.WriteLine("SEZNAM INGREDIENCÍ: ");
            recipe.IngredientsList.ForEach(i => Console.Write($"{i.Name}: {i.Quantity} {i.Unit}\n"));
            Console.WriteLine($"PŘÍPRAVA:\n{recipe.Preparation}\nPOČET PORCÍ: {recipe.NumberOfServings}");
            Console.WriteLine("KATEGORIE: " + string.Join(", ", recipe.Categories) + "\n");
        }


    }
}
