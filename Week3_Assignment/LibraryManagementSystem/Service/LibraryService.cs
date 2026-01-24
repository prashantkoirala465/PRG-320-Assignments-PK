using System;
using System.Collections.Generic;
using LibraryManagementSystem.CustomException;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Service
{
    // Its a service layer to manage library items.
    public class LibraryService
    {
        private List<Item> _items = new();

        // Method to add item to the library.
        public void AddItem(Item item)
        {
            foreach (var existingItem in _items)
            {
                if (existingItem.Title == item.Title &&
                    existingItem.Publisher == item.Publisher &&
                    existingItem.PublicationYear == item.PublicationYear)
                {
                    throw new DuplicateEntryException("Item already exists in the library.");
                }
            }

            _items.Add(item);
            Console.WriteLine($"Item with these information Title:{item.Title} - Publisher:{item.Publisher} - Publication Year: {item.PublicationYear} added successfully.");
        }

        public void DisplayItems()
        {
            foreach (var item in _items)
            {
                item.DisplayItems();
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
