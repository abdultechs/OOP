using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAv1
{

    public class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nWelcome!");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        User.SignUp();
                        break;

                    case 2:
                        string role = User.SignIn();
                        if (role == "admin")
                        {
                            Product.AdminMenu();
                        }
                        else if (role == "user")
                        {
                            UserMenu.ShowMenu();
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            
        }
            public void PrintHeader()
            {
                Console.Clear();
                Console.WriteLine(@"
            #############################################################################################################################################
            ##-----------------------------------------------------------------------------------------------------------------------------------------##
            ##                           ______                                        __          _____    __                                         ##
            ##                          / ____/  ___    ____   ___    _____  ____ _   / /         / ___/   / /_   ____     ____                        ##
            ##                         / / __   / _ \  / __ \ / _ \  / ___/ / __ `/  / /          \__ \   / __ \ / __ \   / __ \                       ##
            ##                        / /_/ /  /  __/ / / / //  __/ / /    / /_/ /  / /          ___/ /  / / / // /_/ /  / /_/ /                       ##
            ##                        \____/   \___/ /_/ /_/ \___/ /_/     \__,_/  /_/          /____/  /_/ /_/ \____/  / .___/                        ##
            ##                                                                                                         /_/                             ##
            ##-----------------------------------------------------------------------------------------------------------------------------------------##
            #############################################################################################################################################                  
");
        }
    }

}
