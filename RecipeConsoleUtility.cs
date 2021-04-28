namespace Cookbook
{
    class RecipeConsoleUtility
    {
        public static void AddIngredientToRecipe(Recipe recipe)
        {
            string name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název ingredience: ").ToLower();
            double quantity = AuxiliaryMethod.LoadNumberFromConsole("Zadejte množství: ");
            string unit = AuxiliaryMethod.LoadStringFromConsole("Zadejte jednotku: ");

            recipe.AddIngredient(name, quantity, unit);
        }

    }
}
