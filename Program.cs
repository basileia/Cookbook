namespace Cookbook
{
    class Program
    {
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
