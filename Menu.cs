using System;
using System.Collections.Generic;

namespace Cookbook
{
    class Menu
    {
        public static bool MainMenu(Cookbook cookbook)
        {
            Console.Clear();
            Console.WriteLine("VYBER, UVAŘ & BE HAPPY\n\n");
            Console.WriteLine("HLAVNÍ MENU:\n");
            Console.WriteLine("1) Zobrazit recepty");
            Console.WriteLine("2) Přidat recept");
            Console.WriteLine("3) Smazat recept");
            Console.WriteLine("4) Vygenerovat náhodný jídelníček");
            Console.WriteLine("5) Ukázat nákupní seznam");
            Console.WriteLine("6) Konec");

            switch (AuxiliaryMethod.LoadNumberInRange("\nCo chcete udělat? ", 6))
            {
                case 1:
                    MenuRecipesToView(cookbook);
                    Console.WriteLine("Pro navrácení do hlavního menu stiskněte jakoukoli klávesu");
                    Console.ReadKey();
                    return true;
                case 2:
                    CookbookConsoleUtility.AddRecipeToCookbook(cookbook);
                    return true;
                case 3:
                    ShowRecipeNames(cookbook.Recipes);
                    CookbookConsoleUtility.RemoveRecipeFromCookbook(cookbook);
                    Console.WriteLine("Pro navrácení do hlavního menu stiskněte jakoukoli klávesu");
                    Console.ReadKey();
                    return true;
                case 4:
                    CookbookConsoleUtility.ShowRandomMenu(cookbook);
                    Console.WriteLine("Pro navrácení do hlavního menu stiskněte jakoukoli klávesu");
                    Console.ReadKey();
                    return true;
                case 5:
                    ShoppingListConsoleUtility.ViewShoppingList(cookbook);
                    Console.WriteLine("Pro navrácení do hlavního menu stiskněte jakoukoli klávesu");
                    Console.ReadKey();
                    return true;
                case 6:
                    return false;
                default:
                    return true;
            }
        }

        private static void MenuRecipesToView(Cookbook cookbook)
        {
            Console.WriteLine("\n1) Zobrazit všechny recepty");
            Console.WriteLine("2) Zobrazit recepty dle kategorie");
            Console.WriteLine("3) Zobrazit recepty dle ingredience");
            
            switch (AuxiliaryMethod.LoadNumberInRange("\nVyberte jednu z možností: ", 3))
            {
                case 1:
                    ShowCertainRecipeFromList(cookbook, cookbook.Recipes);
                    break;
                case 2:
                    ShowCategories();
                    Category category = (Category)(int)AuxiliaryMethod.LoadNumberInRange("Kterou kategorii chcete zobrazit?", 4);
                    var recipes = CookbookConsoleUtility.FindRecipesByCategoryInCookbook(cookbook, category);
                    ShowCertainRecipeFromList(cookbook, recipes);
                    break;
                case 3:
                    string ingredient = AuxiliaryMethod.LoadStringFromConsole("Recepty s kterou ingrediencí chcete zobrazit?").ToLower();
                    var recipesByIngredient = CookbookConsoleUtility.FindRecipesByIngredientInCookbook(cookbook, ingredient);
                    ShowCertainRecipeFromList(cookbook, recipesByIngredient);
                    break;
                default:
                    CookbookConsoleUtility.ViewRecipes(cookbook);
                    break;

            }
        }

        public static void ShowCategories()
        {
            int count = 0;
            foreach (Category c in Enum.GetValues(typeof(Category)))
            {
                if (c != 0)
                {
                    count++;
                    Console.WriteLine("Kategorie {0, 8}: {1, 10}", c, count);
                }
            }
        }

        private static void ShowCertainRecipeFromList(Cookbook cookbook, List<Recipe> recipes)
        {
            ShowRecipeNames(recipes);
            if (recipes.Count > 0)
            {
                int recipeNumber = AuxiliaryMethod.LoadNumberInRange("\nKterý recept chcete zobrazit?", recipes.Count);
                Console.WriteLine("Zmáčkli jste číslo: " + recipeNumber);
                Recipe recipe = cookbook.FindRecipeByName(cookbook.Recipes[recipeNumber - 1].Name);
                if (recipe != null)
                {
                    RecipeConsoleUtility.ViewRecipe(recipe);
                }
            }
            else
            {
                Console.WriteLine("Nejsou žádné recepty k zobrazení.");
            }
        }

        private static void ShowRecipeNames(List<Recipe> recipes)
        {
            int i = 1;
            recipes.ForEach(x => Console.Write($"\n{i++}) {x}"));
        }

              
    }
}
