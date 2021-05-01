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

        public Ingredient() { }

        public Ingredient(Ingredient clone)
        {
            Name = clone.Name;
            Quantity = clone.Quantity;
            Unit = clone.Unit;

        }

        public override string ToString()
        {
            return $"{Name}: {Quantity} {Unit}";
        }

    }
}
