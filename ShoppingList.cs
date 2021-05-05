using System.Collections.Generic;

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
    }
}
