using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class Menu
    {
        public static bool MainMenu(Cookbook cookbook)
        {
            Console.Clear();
            Console.WriteLine("HLAVNÍ MENU:\n");
            Console.WriteLine("1) Zobrazit názvy receptů");
            Console.WriteLine("2) Přidat recept");
            Console.WriteLine("3) Konec");
            Console.Write("\nCo chcete udělat? ");

            switch (Console.ReadLine())
            {
                case "1":
                    MenuRecipesToView(cookbook);
                    Console.WriteLine("Pro navrácení do hlavního menu stiskněte jakoukoli klávesu");
                    Console.ReadKey();
                    return true;
                case "2":
                    cookbook.AddRecipe();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static void MenuRecipesToView(Cookbook cookbook)
        {
            Console.WriteLine("\n1) Zobrazit všechny recepty");
            Console.WriteLine("2) Zobrazit recepty dle kategorie");
            Console.WriteLine("3) Zobrazit recepty dle ingredience\n");
            Console.Write("Vyberte jednu z možností: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowCertainRecipeFromList(cookbook, cookbook.Recipes);
                    break;
                case "2":
                    ShowCategories();
                    Category category = (Category)(int)AuxiliaryMethod.LoadNumberInRange("Kterou kategorii chcete zobrazit?", 4);
                    var recipes = cookbook.FindRecipesByCategory(category);
                    ShowCertainRecipeFromList(cookbook, recipes);
                    break;
                case "3":
                    string ingredient = AuxiliaryMethod.LoadStringFromConsole("Recepty s kterou ingrediencí chcete zobrazit?").ToLower();
                    var recipesByIngredient = cookbook.FindRecipesByIngredient(ingredient);
                    ShowCertainRecipeFromList(cookbook, recipesByIngredient);
                    break;
                default:
                    cookbook.ViewRecipes();
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
                int recipeNumber = AuxiliaryMethod.LoadNumberInRange("Který recept chcete zobrazit?", recipes.Count);
                Recipe recipe = cookbook.FindRecipeByName(cookbook.Recipes[recipeNumber - 1].Name);
                if (recipe != null)
                {
                    recipe.ViewRecipe();
                }
            }
        }

        private static void ShowRecipeNames(List<Recipe> recipes)
        {
            int i = 1;
            recipes.ForEach(x => Console.Write($"\n{i++}) {x}"));
        }

        
    }
}
