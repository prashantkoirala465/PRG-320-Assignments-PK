using System;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Model;
using LibraryManagementSystemExtended.Service;

namespace LibraryManagementSystemExtended
{
    public class Program
    {
        // Keeping library service as static
        private static LibraryService library;

        static void Main(string[] args)
        {
            library = new LibraryService(); // create service once

            bool exit = false; // loop flag

            while (!exit)
            {
                DisplayMenu(); // show menu every time

                string choice = Console.ReadLine() ?? ""; // take input safely

                // handle choice and decide if we should exit
                exit = HandleMenuChoice(choice);
            }
        }

        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==============================");
            Console.WriteLine("   Library Management System  ");
            Console.WriteLine("==============================");
            Console.ResetColor();

            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Magazine");
            Console.WriteLine("3. Add Newspaper");
            Console.WriteLine("4. Display All Items");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
        }

        private static bool HandleMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    ExecuteAddBook();
                    return false;

                case "2":
                    ExecuteAddMagazine();
                    return false;

                case "3":
                    ExecuteAddNewspaper();
                    return false;

                case "4":
                    library.DisplayAllItems();
                    return false;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return true;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    return false;
            }
        }

        private static void ExecuteAddBook()
        {
            try
            {
                // Taking inputs one by one.
                string title = GetStringInput("Enter Title: ");
                string publisher = GetStringInput("Enter Publisher: ");
                int year = GetIntInput("Enter Publication Year: ");
                string author = GetStringInput("Enter Author: ");

                // Create book object and add to library.
                Book book = new Book(title, publisher, year, author);
                library.AddItem(book);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Book add attempt completed.");
            }
        }

        private static void ExecuteAddMagazine()
        {
            try
            {
                string title = GetStringInput("Enter Title: ");
                string publisher = GetStringInput("Enter Publisher: ");
                int year = GetIntInput("Enter Publication Year: ");
                int issue = GetIntInput("Enter Issue Number: ");

                Magazine magazine = new Magazine(title, publisher, year, issue);
                library.AddItem(magazine);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Magazine add attempt completed.");
            }
        }

        private static void ExecuteAddNewspaper()
        {
            try
            {
                string title = GetStringInput("Enter Title: ");
                string publisher = GetStringInput("Enter Publisher: ");
                int year = GetIntInput("Enter Publication Year: ");
                string editor = GetStringInput("Enter Editor: ");

                Newspaper newspaper = new Newspaper(title, publisher, year, editor);
                library.AddItem(newspaper);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Newspaper add attempt completed.");
            }
        }

        // Helper: keeps asking until user enters something non-empty.
        private static string GetStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Please enter a valid value.");
            }
        }

        // Helper: keeps asking until user enters a valid int.
        private static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
