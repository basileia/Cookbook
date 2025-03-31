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
            if (Recipes == null || recipeName == null)
            {
                return null;
            }

            return Recipes.Find(x => x.Name != null && x.Name.ToLower() == recipeName.ToLower());
        }

        public void DeleteRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        public static void PutRecipesToJson(Cookbook cookbook, string sourceDirectory, string filePath)
        {
            AuxiliaryMethod.CreateDirectory(sourceDirectory);
            if (cookbook.Recipes.Any() || File.Exists(filePath))
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, cookbook.Recipes);
                }
            }
        }

        public static Cookbook LoadRecipesFromJson(string filePath)
        {
            Cookbook cookbook = new Cookbook();
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                cookbook.Recipes = JsonConvert.DeserializeObject<List<Recipe>>(fileContent);
            }
            return cookbook;
        }

        public Dictionary<Category, Recipe> GenerateRandomMenu()
        {
            Random rnd = new Random();
            Dictionary<Category, Recipe> randomMenu = new Dictionary<Category, Recipe>();

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                List<Recipe> recipesByCategory = FindRecipesByCategory(category);
                
                foreach (Recipe recipe in randomMenu.Values)
                {
                    if (recipesByCategory.Contains(recipe))
                    {
                        recipesByCategory.Remove(recipe);
                    }
                }

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
