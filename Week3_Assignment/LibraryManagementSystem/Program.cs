using System;
using LibraryManagementSystem.CustomException;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Service;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryService libraryService = new LibraryService();

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n==============================");
                Console.WriteLine("   Library Management System  ");
                Console.WriteLine("==============================");
                Console.ResetColor();

                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Display Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddBook(libraryService);
                        break;

                    case "2":
                        AddMagazine(libraryService);
                        break;

                    case "3":
                        libraryService.DisplayItems();
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                        break;
                }
            }
        }

        static void AddBook(LibraryService libraryService)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? "";

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine() ?? "";

                Console.Write("Enter Publication Year: ");
                string yearInput = Console.ReadLine() ?? "";

                Console.Write("Enter Author: ");
                string author = Console.ReadLine() ?? "";

                if (!int.TryParse(yearInput, out int year))
                    throw new InvalidItemDataException("Publication year must be a number.");

                Book book = new Book(title, publisher, year, author);
                libraryService.AddItem(book);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateEntryException ex)
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

        static void AddMagazine(LibraryService libraryService)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? "";

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine() ?? "";

                Console.Write("Enter Publication Year: ");
                string yearInput = Console.ReadLine() ?? "";

                Console.Write("Enter Issue Number: ");
                string issueInput = Console.ReadLine() ?? "";

                if (!int.TryParse(yearInput, out int year))
                    throw new InvalidItemDataException("Publication year must be a number.");

                if (!int.TryParse(issueInput, out int issueNumber))
                    throw new InvalidItemDataException("Issue number must be a number.");

                Magazine magazine = new Magazine(title, publisher, year, issueNumber);
                libraryService.AddItem(magazine);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateEntryException ex)
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
    }
}
