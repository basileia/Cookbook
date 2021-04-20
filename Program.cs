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

            while (cookbook.ShowMenu)
            {
                cookbook.ShowMenu = Menu.MainMenu(cookbook);
            }
            
            cookbook.PutRecipesToJson();
             
        }

    }
}
