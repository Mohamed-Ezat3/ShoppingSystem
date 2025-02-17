namespace ShoppingSystem
{
    internal class Program
    {
        public enum CartAction
        {
            AddItem=1,
            ViewCart=2,
            RemoveItem=3,
            ViewTotalPrice = 4,
            Checkout = 5,
            UndoLastAction =6,
            Exit =7
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\tWelcome\n");
            Product product = new Product();
            Cart cart = new Cart();
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add item to cart");
                Console.WriteLine("2. View cart");
                Console.WriteLine("3. Remove item from cart");
                Console.WriteLine("4. ViewTotalPrice ");
                Console.WriteLine("5. Checkout ");
                Console.WriteLine("6. Undo last action");
                Console.WriteLine("7. Exit");
                var chioc = (CartAction)int.Parse(Console.ReadLine());
                switch (chioc)
                {
                    case CartAction.AddItem :
                        product.ViewProducts();
                        Console.Write("Enter item name :  ");
                        string itemChois = Console.ReadLine();
                        if (product.Products.ContainsKey(itemChois))
                        {
                            double itemChoisPrice = product.Products[itemChois];
                            CartItem item = new CartItem(itemChois, itemChoisPrice);
                            cart.AddItem(item);     
                        }
                        else
                        {
                            Console.WriteLine("Item is out of stock or not available.");
                        }
                        break;
                    case CartAction.ViewCart:
                        cart.ViewCart();
                        break;
                    case CartAction.RemoveItem:
                        cart.RemoveItem();
                        break;
                    case CartAction.ViewTotalPrice:
                        Console.WriteLine("Total Price : "+ cart.ViewTotalPrice());
                        break;

                    case CartAction.Checkout:
                        cart.Checkout();
                        break;
                    case CartAction.UndoLastAction:
                        cart.UndoLastAction();
                        break;
                    case CartAction.Exit:
                       Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option.");
                        break;
                }
            }

        }
    }
}
