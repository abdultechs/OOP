using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

        namespace BAv1
{
    internal class User
{

    public string Username;
    public string Password;
    public string Role; 

    public User(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }


    public static void SaveUserToFile(User user)
    {
        using (StreamWriter writer = new StreamWriter("users.txt", true))
        {
            writer.WriteLine($"{user.Username},{user.Password},{user.Role}");
        }
    }


    public static List<User> LoadUsersFromFile()
    {
        List<User> users = new List<User>();
        if (File.Exists("users.txt"))
        {
            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                users.Add(new User(parts[0], parts[1], parts[2]));
            }
        }
        return users;
    }


    public static bool SignUp()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();
        Console.Write("Enter Role (user/admin): ");
        string role = Console.ReadLine();

        
        if (role != "user" && role != "admin")
        {
            Console.WriteLine("Invalid role. Role must be 'user' or 'admin'.");
                Console.WriteLine("Press any key to continue");

            return false;
        }

        
        List<User> users = LoadUsersFromFile();
        foreach (User user in users)
        {
            if (user.Username == username)
            {
                Console.WriteLine("User already exists.");
                    Console.WriteLine("Press any key to continue");
                    Console.Clear();
                    return false;
            }
        }

        
        User newUser = new User(username, password, role);
        SaveUserToFile(newUser);
        Console.WriteLine("User registered successfully!");
        return true;
    }

    
    public static string SignIn()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        List<User> users = LoadUsersFromFile();
        foreach (User user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                Console.WriteLine("Login successful!");
                    
                    
                    return user.Role;
            }
        }
        Console.WriteLine("Invalid username or password.");
        return null;
    }
}
}
