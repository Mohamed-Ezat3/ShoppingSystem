using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ShoppingSystem
{
    internal class Cart
    {
       List <CartItem> CartItems = new List<CartItem> ();
       double TotalPrice=0;
       public Stack<string> Actions=new Stack<string> ();
       public void AddItem(CartItem item )
        {
            
                CartItems.Add(item);
                Console.WriteLine($"{item.Name} has been added to your cart.");
                Actions.Push($"{item.Name} added");
        }
        public void RemoveItem()
        {
            ViewCart();
            if (CartItems.Count > 0)
            {
                Console.WriteLine("Select an item to remove: ");
                string itemToRemove = Console.ReadLine();
                foreach (CartItem item in CartItems)
                {
                    if (item.Name == itemToRemove)
                    {
                        CartItems.Remove(item);
                        Console.WriteLine($"{itemToRemove} is removed from cart.");
                        Actions.Push($"{itemToRemove} removed");
                        return;
                    }
                    
                }     
                Console.WriteLine($"{itemToRemove} doesn't exist in the shopping cart. ");        
            }
        }
        public void ViewCart()
        {
            if (CartItems.Count > 0)
            {
                foreach (var item in CartItems)
                {
                    Console.WriteLine($" {item.Name}  :  {item.Price} ");
                }
            }
            else
            {
                Console.WriteLine("Cart is empty.");
                
            }
        }
        public double ViewTotalPrice()
        {
            for (int i = 0; i < CartItems.Count; i++)
            {
                TotalPrice += CartItems[i].Price;
            }
            return TotalPrice;
        }
        public void Checkout()
        {
            ViewCart();
            Console.WriteLine("Total Price : " + ViewTotalPrice());
        }
        public void UndoLastAction()
        {
            if (Actions.Count > 0)
            {
                string lastAction = Actions.Pop();
                var actionsArray = lastAction.Split();
                string productName = actionsArray[0];

                if (lastAction.Contains("removed"))
                {
                    double price = new Product().Products[productName];
                    CartItems.Add(new CartItem(productName, price));
                }
                else if (lastAction.Contains("added"))
                {
                    CartItem itemToRemove = null;
                    foreach (var item in CartItems)
                    {
                        if (item.Name == productName)
                        {
                            itemToRemove = item;
                            break;
                        }
                    }
                    if (itemToRemove != null)
                    {
                        CartItems.Remove(itemToRemove);
                    }
                }
            }
        }


    }
}
