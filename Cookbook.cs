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
            Console.WriteLine("VYBER, NAKUP, UVAŘ");
            EndApp = endApp;
            List<Recipe> Recipes = new List<Recipe>();
        }



    }
}
