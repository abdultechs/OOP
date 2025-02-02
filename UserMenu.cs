using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAv1
{
    internal class UserMenu
    {
        public static void ShowMenu()
        {
            List<Product> products = Product.LoadProductsFromFile();
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Exit(More Options will  be added in Next Version)");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: // View Products
                        Console.WriteLine("\nProducts:");
                        foreach (Product product in products)
                        {
                            Console.WriteLine($"{product.Name} - Price: {product.Price}, Stock: {product.Stock}");
                        }
                        break;

                    case 2: // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
