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
            Console.WriteLine("1) Zobrazit recepty");
            Console.WriteLine("2) Přidat recept");
            Console.WriteLine("3) Konec");
            Console.Write("\r\nCo chcete udělat? ");

            switch (Console.ReadLine())
            {
                case "1":
                    cookbook.ViewRecipes();
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
    }
}
