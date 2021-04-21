namespace Cookbook
{
    class Program
    {
        /// <summary>
        /// The main Program class.
        /// Loads recipes from json files to cookbook. 
        /// There is while cycle where everything in program is done.
        /// Puts recipes to json file after user wants to exit the program.
        /// </summary>
        static void Main()
        {

            Cookbook cookbook = new Cookbook();

            cookbook.LoadRecipesFromJson();

            while (cookbook.ShowMenu)
            {
                cookbook.ShowMenu = Menu.MainMenu(cookbook);
            }
            
            cookbook.PutRecipesToJson();
             
        }

    }
}
