using System;

namespace WinForm
{
    [Serializable]
    class Product
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string country, decimal price)
        {
            Name = name;
            Country = country;
            Price = price;
        }

        public override string ToString() => string.Format(Name);
    }
}
