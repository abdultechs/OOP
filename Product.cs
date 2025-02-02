using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAv1
{
    internal class Product
    {
        public string Name;
        public int Price;
        public int Stock;
        
        public Product(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public static void SaveProductsToFile(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter("products.txt"))
            {
                foreach (Product product in products)
                {
                    writer.WriteLine($"{product.Name},{product.Price},{product.Stock}");
                }
            }
        }


        public static List<Product> LoadProductsFromFile()
        {
            List<Product> products = new List<Product>();
            if (File.Exists("products.txt"))
            {
                string[] lines = File.ReadAllLines("products.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    products.Add(new Product(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
                }
            }
            return products;
        }

        public static void AdminMenu()
        {
            List<Product> products = LoadProductsFromFile();
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: 
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Product Price: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Stock: ");
                        int stock = int.Parse(Console.ReadLine());
                        products.Add(new Product(name, price, stock));
                        SaveProductsToFile(products);
                        Console.WriteLine("Product added successfully!");
                        break;

                    case 2: 
                        Console.WriteLine("\nProducts:");
                        foreach (Product product in products)
                        {
                            Console.WriteLine($"{product.Name} - Price: {product.Price}, Stock: {product.Stock}");
                        }
                        break;

                    case 3: 
                        Console.Write("Enter Product Name to Update: ");
                        string updateName = Console.ReadLine();
                        Product productToUpdate = products.Find(p => p.Name == updateName);
                        if (productToUpdate != null)
                        {
                            Console.Write("Enter New Price: ");
                            productToUpdate.Price = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Stock: ");
                            productToUpdate.Stock = int.Parse(Console.ReadLine());
                            SaveProductsToFile(products);
                            Console.WriteLine("Product updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case 4: 
                        Console.Write("Enter Product Name to Delete: ");
                        string deleteName = Console.ReadLine();
                        Product productToDelete = products.Find(p => p.Name == deleteName);
                        if (productToDelete != null)
                        {
                            products.Remove(productToDelete);
                            SaveProductsToFile(products);
                            Console.WriteLine("Product deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
