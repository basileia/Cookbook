using System;
using System.Linq;

namespace Cookbook
{
    class ShoppingListConsoleUtility
    {
        public static void ViewShoppingList(Cookbook cookbook)
        {
            if (cookbook.ShoppingList.IngredientsDict.Any())
            {
                cookbook.ShoppingList.ViewShoppingList();
            }
            else
            {
                Console.WriteLine("Nákupní seznam je prázdný.");
            }
        }
    }
}
