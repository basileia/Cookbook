using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook
{
    class CookbookConsoleUtility
    {
        public static void AddRecipeToCookbook(Cookbook cookbook)
        {
            string endOfEntry = "";
            while (endOfEntry != "n")
            {
                string name = AuxiliaryMethod.LoadStringFromConsole("\nZadejte název receptu:"); ;
                while (cookbook.Recipes.Any(p => p.Name.ToLower() == name.ToLower()))
                {
                    Console.WriteLine("Recept s tímto názvem již existuje.");
                    name = AuxiliaryMethod.LoadStringFromConsole("\nZadejte název receptu:");
                }
                List<Ingredient> ingredients = RecipeConsoleUtility.CreateListOfIngredients();
                int numberOfServings = (int)AuxiliaryMethod.LoadNumberFromConsole("Jaký je počet porcí?");
                string preparation = AuxiliaryMethod.LoadStringFromConsole("Napište postup přípravy. Jednotlivé řádky můžete oddělit dvěma mezerami.");
                preparation = preparation.Replace("  ", "\n");
                List <Category> categories= SelectCategories();
                cookbook.AddRecipe(name, numberOfServings, preparation, ingredients, categories);
                endOfEntry = AuxiliaryMethod.EnterYesOrNo("Chcete zadat další recept? a/n");
            }
        }

        public static List<Category> SelectCategories()
        {
            List<Category> categories = new List<Category>();
            string userInput = "";
            while (userInput != "n")
            {
                Menu.ShowCategories();
                int count = (int)Enum.GetValues(typeof(Category)).Cast<Category>().Max();
                int categoryNumber = (int)AuxiliaryMethod.LoadNumberInRange("Do které kategorie chcete recept zařadit?\nNapište číslo:", count);
                Category category = (Category)(int)categoryNumber;
                if (!IsInCategoryList(categories, category))
                {
                    categories.Add(category);
                }
                else
                {
                    Console.WriteLine("Tato kategorie již byla přidána.");
                }
                userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat další kategorii? a/n");

            }
            return categories;
        }

        private static bool IsInCategoryList(List<Category> categories, Category category)
        {
            return categories.Contains(category);
        }

        public static List<Recipe> FindRecipesByCategoryInCookbook(Cookbook cookbook, Category category)
        {
            var recipes = cookbook.FindRecipesByCategory(category);
            if (recipes.Any())
            {
                return recipes;
            }
            Console.WriteLine($"{category}: Recept s touto kategorií v kuchařce není.");  
            return recipes;
        }

        public static List<Recipe> FindRecipesByIngredientInCookbook(Cookbook cookbook, string ingredientName)
        {
            List<Recipe> recipes = cookbook.FindRecipesByIngredient(ingredientName);

            if (recipes.Any())
            {
                return recipes;
            }
            Console.WriteLine("Recept s touto ingrediencí v kuchařce není.");
            return recipes;
        }

        public static Recipe FindRecipeByNameInCookbook(Cookbook cookbook, string recipeName)
        {
            Recipe recipe = cookbook.FindRecipeByName(recipeName);
            if (recipe != null)
            {
                return recipe;
            }
            Console.WriteLine("Recept s tímto názvem v kuchařce není.");
            return recipe;
        }

        public static void RemoveRecipeFromCookbook(Cookbook cookbook)
        {
            if (cookbook.Recipes.Any())
            {
                int recipeNumber = AuxiliaryMethod.LoadNumberInRange("\nKterý recept chcete smazat?", cookbook.Recipes.Count);
                Recipe recipe = FindRecipeByNameInCookbook(cookbook, cookbook.Recipes[recipeNumber - 1].Name);
                if (recipe != null)
                {
                    cookbook.DeleteRecipe(recipe);
                    Console.WriteLine("Recept byl odebrán.");
                }
            }
            else
            {
                Console.WriteLine("Nejsou žádné recepty, které by mohly být smazány.");
            }
        }

        public static void ShowRandomMenu(Cookbook cookbook)
        {
            Dictionary<Category, Recipe> randomMenu = cookbook.GenerateRandomMenu();

            foreach (Category i in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{ i }:");   
                
                if (randomMenu.ContainsKey(i))
                {
                    RecipeConsoleUtility.ViewRecipe(randomMenu[i]);
                }
                else
                {
                    Console.WriteLine("Recept s touto kategorií není k dispozici.\n");
                }
            }
            AddIngredientsToShoppingList(randomMenu, cookbook);
        }

        public static void AddIngredientsToShoppingList(Dictionary<Category, Recipe> randomMenu, Cookbook cookbook)
        {
            if (randomMenu.Any())
            {
                string userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat ingredience do nákupního seznamu? a/n");
                if (userInput == "a")
                {
                    int numberOfServings = (int)AuxiliaryMethod.LoadNumberFromConsole("\nPro kolik lidí budete vařit?");

                    foreach (var recipe in randomMenu.Values)
                    {
                        recipe.ConvertedIngredients = recipe.ConvertToTheNumberOfServings(numberOfServings);
                        cookbook.ShoppingList.AddIngredientsToShoppingList(recipe);
                        recipe.ConvertedIngredients.Clear();
                    }
                }
            }
        }

        public static void ViewRecipes(Cookbook cookbook)
        {
            {
                cookbook.Recipes.ForEach(x => RecipeConsoleUtility.ViewRecipe(x));
            }
        }

    }
}
