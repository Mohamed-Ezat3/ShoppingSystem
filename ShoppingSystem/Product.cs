using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem
{
    internal class Product
    {

        public Dictionary<string, double> Products = new Dictionary<string, double>()
        {
            {"1",100 },
            {"2",500 },
            {"3",400 },
            {"4",5000 },
            {"5",3200 }
        };
        public void ViewProducts()
        {
            foreach (var product in Products)
            {

                Console.WriteLine($"{product.Key} : {product.Value}");
            }

        }
    }
}
