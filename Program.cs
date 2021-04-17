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

            Cookbook cookbook = new Cookbook();

            cookbook.AddRecipe();
            cookbook.ViewRecipes((Category)1);


            Console.ReadKey();

        }

        
    }
}
