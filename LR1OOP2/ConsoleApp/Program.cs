using System;
using FileOperations;
using ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting laboratory work...");

        try
        {
            IFileService fileService = new FileService();

            ConsoleMenu menu = new ConsoleMenu(fileService);

            menu.ShowMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Critical error: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}