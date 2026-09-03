
using System;
using System.IO;
void ControlFile()
{
   
    if (!File.Exists("passwords.txt"))
    {
        File.WriteAllText("passwords.txt", "=========All Passwords=========" + Environment.NewLine);
    }
}

void SeeAllPasswords()
{
    try
    {
        string[] passwords = File.ReadAllLines("passwords.txt");
        foreach (string password in passwords)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(password);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while reading passwords: " + ex.Message);
    }
}

void CreateNewPassword()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Random random = new Random();

    // Geçerli bir C# karakter dizisi tanımlaması
    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#+-.";

    string password = "";
    Console.Write("Enter the Description of the password: ");
    string description = Console.ReadLine();

    Console.Write("Enter the length of the password: ");
    if (int.TryParse(Console.ReadLine(), out int readLength))
    {
        for (int i = 0; i < readLength; i++)
        {
            password += chars[random.Next(chars.Length)];
        }
        File.AppendAllText("passwords.txt", description + ": " + password + Environment.NewLine);
        Console.WriteLine("New password created successfully.");
    }
    else
    {
        Console.WriteLine("Invalid length entered.");
    }
}

void DeletePassword()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Enter the description of the password to delete: ");
    string descriptionToDelete = Console.ReadLine();

    if (!File.Exists("passwords.txt")) return;

    string[] lines = File.ReadAllLines("passwords.txt");
    using (StreamWriter writer = new StreamWriter("passwords.txt"))
    {
        foreach (string line in lines)
        {
            if (!line.StartsWith(descriptionToDelete + ":"))
            {
                writer.WriteLine(line);
            }
        }
    }
    Console.WriteLine("If existed, password deleted.");
}

void UpdatePassword()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter the description of the password to update: ");
    string descriptionToUpdate = Console.ReadLine();

    if (!File.Exists("passwords.txt")) return;

    string[] lines = File.ReadAllLines("passwords.txt");
    using (StreamWriter writer = new StreamWriter("passwords.txt"))
    {
        foreach (string line in lines)
        {
            if (line.StartsWith(descriptionToUpdate + ":"))
            {
                Console.Write("Enter the new password: ");
                string newPassword = Console.ReadLine();
                writer.WriteLine(descriptionToUpdate + ": " + newPassword);
            }
            else
            {
                writer.WriteLine(line);
            }
        }
    }
    Console.WriteLine("If existed, password updated.");
}

void ManagePasswords(int choice)
{
    switch (choice)
    {
        case 1:
            SeeAllPasswords();
            break;
        case 2:
            CreateNewPassword();
            break;
        case 3:
            DeletePassword();
            break;
        case 4:
            UpdatePassword();
            break;
        case 5:
            AntiMalware antivirus = new AntiMalware();
            antivirus.Antivirus();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}


try
{
    ControlFile();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. See All passwords");
    Console.WriteLine("2. Create a new password");
    Console.WriteLine("3. Delete a password");
    Console.WriteLine("4. Update a password");
    Console.WriteLine("5. AntiVirus");

    Console.Write("Enter your choice (1-5): ");
    string process = Console.ReadLine();


    if (int.TryParse(process, out int choice))
    {
        ManagePasswords(choice);
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    Console.ResetColor();
}
