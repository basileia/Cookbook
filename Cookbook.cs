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
            Console.WriteLine("VYBER, NAKUP & BE HAPPY");
            EndApp = endApp;
            Recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            string endOfEntry = "";
            while(endOfEntry != "ne")
            {
                string name = AuxiliaryMethod.LoadStringFromConsole("Zadejte název receptu:");
                Recipe recipe = new Recipe(name);

                string userInput = "";
                while (userInput != "ne")
                {
                    recipe.AddIngredient();
                    userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat další ingredienci? ano/ne");
                }
                recipe.NumberOfServings = (int)AuxiliaryMethod.LoadNumberFromConsole("Jaký je počet porcí?");
                recipe.Preparation = AuxiliaryMethod.LoadStringFromConsole("Napište postup přípravy:");
                recipe.Categories = SelectCategories();
                Recipes.Add(recipe);
                endOfEntry = AuxiliaryMethod.EnterYesOrNo("Chcete zadat další recept? ano/ne");
            }
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
                int categoryNumber = (int)AuxiliaryMethod.LoadNumberFromConsole("Do které kategorie chcete recept zařadit? Napište číslo:");
                Category category = (Category)(int)categoryNumber;
                if (!IsInCategoryList(categories, category) && categoryNumber <= count)
                {
                    
                    categories.Add(category);
                }
                else if(categoryNumber > count)
                {
                    Console.WriteLine("Tato kategorie neexistuje.");
                }
                else
                {
                    Console.WriteLine("Tato kategorie již byla přidána.");
                }
                userInput = AuxiliaryMethod.EnterYesOrNo("Chcete přidat další kategorii? ano/ne");
                                    
            }
            return categories;
        }

        private bool IsInCategoryList(List<Category> categories, Category category)
        {
            return categories.Contains(category);
        }




    }
}
