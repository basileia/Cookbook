using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook
{
    class ShoppingList
    {
        public List<Ingredient> IngredientsList { get; private set; }

        public ShoppingList() 
        {
            IngredientsList = new List<Ingredient>();
        }

        public void AddIngredientsToShoppingList(Recipe recipe)
        {
            IngredientsList.AddRange(recipe.ConvertedIngredients);
        }

        public void ViewShoppingList()
        {
            if (IngredientsList.Any())
            {
                int x = 1;
                IngredientsList.ForEach(i => Console.Write($"{x++}) {i.Name}: {i.Quantity} {i.Unit}\n")); ;
            }
            else
            {
                Console.WriteLine("Nákupní seznam je prázdný.");
            }
        }

    }
}
