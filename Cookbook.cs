using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class Cookbook
    {
        public bool EndApp { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Cookbook(bool endApp = false)
        {
            Console.WriteLine("VYBER, NAKUP, UVAŘ");
            EndApp = endApp;
            Recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            string name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název receptu:");
            Recipe recipe = new Recipe(name);

            string userInput = "";           
            while(userInput != "ne")
            {
                recipe.AddIngredient();
                userInput = AuxiliaryMethod.LoadStringFromConsole("Chcete přidat další ingredienci? ano/ne").ToLower();
            }

            recipe.NumberOfServings = (int)AuxiliaryMethod.LoadNumberFromConsole("Jaký je počet porcí?");
            recipe.Preparation = AuxiliaryMethod.LoadStringFromConsole("Napište postup přípravy:");
            recipe.Categories = SelectCategories();
            Recipes.Add(recipe);
                  
        }

        public void ViewRecipes()
        {
            Recipes.ForEach(x => x.ViewRecipe());
        }

        public List<Category> SelectCategories()
        {
            List<Category> categories = new List<Category>();
            string userInput = "";
            while (userInput != "ne")
            {
                int count = 0;
                foreach (Category c in Enum.GetValues(typeof(Category)))
                {
                    count++;
                    Console.WriteLine("Kategorie {0, 8}: {1, 10}", c, count);
                }
                Category category = (Category)(int)AuxiliaryMethod.LoadNumberFromConsole("Do které kategorie chcete recept zařadit? Napište číslo:");
                categories.Add(category);
                userInput = AuxiliaryMethod.LoadStringFromConsole("Chcete přidat další kategorii? ano/ne").ToLower();
            }
            return categories;
            

        }




    }
}
