using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class Program
    {
        static void Main(string[] args)
        {

            Recipe recipe = new Recipe("Jahody", "Zabalit do", new List<Category>() { Category.Breakfast, Category.Snack });
            recipe.AddIngredient();
            recipe.AddIngredient();

            recipe.ConvertToTheNumberOfServings(4);


            Console.ReadKey();

        }

        
    }
}
