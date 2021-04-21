using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cookbook
{
    class Cookbook
    {
        public bool ShowMenu { get; set; }
        public List<Recipe> Recipes { get; set; }
        
        public Cookbook(bool showMenu = true)
        {
            ShowMenu = showMenu;
            Recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            string endOfEntry = "";
            while(endOfEntry != "n")
            {
                string name = AuxiliaryMethod.LoadStringFromConsole("\nZadejte název receptu:");
                Recipe recipe = new Recipe(name);

                string userInput = "";
                while (userInput != "n")
                {
                    recipe.AddIngredient();
                    userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat další ingredienci? a/n");
                }
                recipe.NumberOfServings = (int)AuxiliaryMethod.LoadNumberFromConsole("Jaký je počet porcí?");
                string preparation = AuxiliaryMethod.LoadStringFromConsole("Napište postup přípravy. Jednotlivé řádky můžete oddělit dvěma mezerami.");
                recipe.Preparation = preparation.Replace("  ", "\n");
                recipe.Categories = SelectCategories();
                Recipes.Add(recipe);
                endOfEntry = AuxiliaryMethod.EnterYesOrNo("Chcete zadat další recept? a/n");
            }
        }

        public void ViewRecipes()
        {
             {
                Recipes.ForEach(x => x.ViewRecipe());
             }
        }

        public List<Category> SelectCategories()
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

        private bool IsInCategoryList(List<Category> categories, Category category)
        {
            return categories.Contains(category);
        }

        public List<Recipe> FindRecipesByCategory(Category category)
        {
            List<Recipe> recipes = Recipes.FindAll(x => x.Categories.Contains(category));
            if (recipes.Any())
            {
                return recipes;
            }
            Console.WriteLine("Recept s touto kategorií v kuchařce není.");
            return recipes;
        }

        public List<Recipe> FindRecipesByIngredient(string ingredientName)
        {
            List<Recipe> recipes = new List<Recipe>();
            foreach (Recipe recipe in Recipes)
            {
               foreach (Ingredient ingredient in recipe.IngredientsList)
                {
                    if (ingredient.Name == ingredientName)
                    {
                        recipes.Add(recipe);
                    }
                }
            }

            if (recipes.Any())
            {
                return recipes;
            }
            Console.WriteLine("Recept s touto ingrediencí v kuchařce není.");
            return recipes;
        }

        public Recipe FindRecipeByName(string recipeName)
        {
            Recipe recipe = Recipes.Find(x => x.Name.ToLower() == recipeName.ToLower());
            if (recipe != null)
            {
                return recipe;
            }
            Console.WriteLine("Recept s tímto názvem v kuchařce není.");
            return recipe;
        }

        public void DeleteRecipe()
        {
            int recipeNumber = AuxiliaryMethod.LoadNumberInRange("Který recept chcete smazat?", Recipes.Count);
            Recipe recipe = FindRecipeByName(Recipes[recipeNumber - 1].Name);
            if (recipe != null)
            {
                Recipes.Remove(recipe);
                Console.WriteLine("Recept byl odebrán.");
            }
        }

        public void PutRecipesToJson()
        {
            using (StreamWriter file = File.CreateText(AuxiliaryMethod.GetProjectDirectory() + "\\recipes.json"))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                serializer.Serialize(file, Recipes);  
                
                
            }
        }

        public void LoadRecipesFromJson()
        {
            var fileContent = File.ReadAllText(AuxiliaryMethod.GetProjectDirectory() + "\\recipes.json");
            Recipes = JsonConvert.DeserializeObject<List<Recipe>>(fileContent);
        }

        public List<Recipe> GenerateRandomMenu()
        {
            Random rnd = new Random();
            List<Recipe> randomMenu = new List<Recipe>();
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                List<Recipe> recipesByCategory = FindRecipesByCategory(category);
                if (recipesByCategory.Any())
                {
                    int randomIndex = rnd.Next(recipesByCategory.Count);
                    randomMenu.Add(recipesByCategory[randomIndex]);
                }
 
            }
            return randomMenu;                
        }

        public void ShowRandomMenu()
        {
            List<Recipe> randomMenu = GenerateRandomMenu();

            foreach (int i in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{ (Category)i }:");
                if (i <= randomMenu.Count)
                {
                    randomMenu[i - 1].ViewRecipe();
                }
                
            }
        }

    }
}
