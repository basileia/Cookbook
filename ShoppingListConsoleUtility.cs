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
                int x = 1;
                foreach (var i in cookbook.ShoppingList.IngredientsDict.Values)
                {
                    Console.Write($"{x++}) {i}\n");
                }
            }
            else
            {
                Console.WriteLine("Nákupní seznam je prázdný.");
            }
        }
    }
}
