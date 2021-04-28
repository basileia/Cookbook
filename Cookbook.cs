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

        public Cookbook(bool showMenu = true)
        {
            ShowMenu = showMenu;
            Recipes = new List<Recipe>();
            ShoppingList = new ShoppingList();
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
            string curFile = AuxiliaryMethod.GetProjectDirectory() + "\\recipes.json";
            if (Recipes.Any() || File.Exists(curFile))
            {
                using (StreamWriter file = File.CreateText(curFile))
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
            string file = AuxiliaryMethod.GetProjectDirectory() + "\\recipes.json";
            if (File.Exists(file))
            {
                var fileContent = File.ReadAllText(file);
                Recipes = JsonConvert.DeserializeObject<List<Recipe>>(fileContent);
            }
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
    }
}
