using System;
using System.IO;

namespace Cookbook
{
    class Program
    {
         static void Main()
        {
            string sourceDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cookbook");
            string sourceFile = Path.Combine(sourceDirectory, "recipes.json");
            
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }

            Cookbook cookbook = Cookbook.LoadRecipesFromJson(sourceFile);

            while (cookbook.ShowMenu)
            {
                cookbook.ShowMenu = Menu.MainMenu(cookbook);
            }
            
            Cookbook.PutRecipesToJson(cookbook, sourceFile);
             
        }

    }
}
