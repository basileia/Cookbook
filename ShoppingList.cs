using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook
{
    class ShoppingList
    {
        public Dictionary<string, Ingredient> IngredientsDict { get; private set; }

        public ShoppingList() 
        {
            IngredientsDict = new Dictionary<string, Ingredient>();
        }

        public void AddIngredientsToShoppingList(Recipe recipe)   
        {
            foreach (var convertedIngredient in recipe.ConvertedIngredients)
            {
                if (IngredientsDict.ContainsKey(convertedIngredient.Name))
                {
                    Ingredient ingredient = IngredientsDict[convertedIngredient.Name];
                    if (ingredient.Unit == convertedIngredient.Unit)
                    {
                        convertedIngredient.Quantity += ingredient.Quantity;
                    }
                }
                IngredientsDict[convertedIngredient.Name] = convertedIngredient;
            }
        }

        public void ViewShoppingList()
        {
            if (IngredientsDict.Any())
            {
                int x = 1;
                foreach (var i in IngredientsDict.Values)
                {
                    Console.Write($"{x++}) {i.Name}: {i.Quantity} {i.Unit}\n");
                }
            }
            else
            {
                Console.WriteLine("Nákupní seznam je prázdný.");
            }
        }

    }
}
