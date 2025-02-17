using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem
{
    internal class CartItem
    {
        public string Name { get; set; }
        public double Price {  get; set; }
        public CartItem(string name ,double price)
        {
            Name = name;
            Price = price;
        }

    }
}
