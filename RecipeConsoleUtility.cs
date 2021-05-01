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
    }
}
