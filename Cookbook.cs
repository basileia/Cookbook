using Newtonsoft.Json;
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
        public ShoppingList ShoppingList { get; private set; }
        public string SourceFile { get; private set; }
        private readonly string sourceDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cookbook");

        public Cookbook(bool showMenu = true)
        {
            ShowMenu = showMenu;
            Recipes = new List<Recipe>();
            ShoppingList = new ShoppingList();
            SourceFile = Path.Combine(sourceDirectory, "recipes.json");
            if (!Directory.Exists(sourceDirectory))
            {
               Directory.CreateDirectory(sourceDirectory);
            }
        }

        public void AddRecipe(string name, int numberOfervings, string preparation, List<Ingredient> ingredients, List<Category> categories)
        {
            Recipe recipe = new Recipe(name)
            {
                NumberOfServings = numberOfervings,
                Preparation = preparation,
                Categories = categories,
                IngredientsList = ingredients
             };
            
            Recipes.Add(recipe);
        }

        public void ViewRecipes()
        {
             {
                Recipes.ForEach(x => x.ViewRecipe());
             }
        }

        public List<Recipe> FindRecipesByCategory(Category category)
        {
            return Recipes.FindAll(x => x.Categories.Contains(category));
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
            return recipes;
        }

        public Recipe FindRecipeByName(string recipeName)
        {
            return Recipes.Find(x => x.Name.ToLower() == recipeName.ToLower());
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        public void PutRecipesToJson()
        {
            if (Recipes.Any() || File.Exists(SourceFile))
            {
                using (StreamWriter file = File.CreateText(SourceFile))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, Recipes);
                }
            }
        }

        public void LoadRecipesFromJson()
        {
            if (File.Exists(SourceFile))
            {
                var fileContent = File.ReadAllText(SourceFile);
                Recipes = JsonConvert.DeserializeObject<List<Recipe>>(fileContent);
            }
        }

        public Dictionary<Category, Recipe> GenerateRandomMenu()
        {
            Random rnd = new Random();
            Dictionary<Category, Recipe> randomMenu = new Dictionary<Category, Recipe>();

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                List<Recipe> recipesByCategory = FindRecipesByCategory(category);
                if (recipesByCategory.Any())
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = rnd.Next(recipesByCategory.Count);

                    } while (randomMenu.ContainsValue(recipesByCategory[randomIndex]));
                    
                    randomMenu[category] = recipesByCategory[randomIndex];
                }
            }
            return randomMenu;
        }
       
    }
}
