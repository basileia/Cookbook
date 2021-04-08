﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity <= 0 ? 0 : quantity;
            Unit = unit;
        }

        public Ingredient(Ingredient clone)
        {
            Name = clone.Name;
            Quantity = clone.Quantity;
            Unit = clone.Unit;

        }

    }
}
