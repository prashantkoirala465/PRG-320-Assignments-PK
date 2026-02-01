using System;
using System.Collections.Generic;
using System.IO;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Interface;
using LibraryManagementSystemExtended.Model;
using Newtonsoft.Json;

namespace LibraryManagementSystemExtended.Service
{
    // Service layer handles add/display + file saving/loading.
    public class LibraryService
    {
        private List<ILibraryItem> items = new List<ILibraryItem>(); // all items stay here
        private readonly string fileName = "LibraryFile.json";       // file used for saving

        // Private property to store duplicate check result.
        private bool CheckForDuplicate { get; set; }

        public LibraryService()
        {
            LoadData(); // load items when app starts
        }

        public void AddItem(ILibraryItem item)
        {
            // Always load latest file data before doing anything.
            LoadData();

            // Instead of checking list count, we check if file has any item.
            if (FileHasAnyItem())
            {
                // Check duplicates
                CheckForDuplicate = CheckForDuplicates(item);

                if (CheckForDuplicate)
                    throw new DuplicateItemException("Item you are about to add already exists.");
            }

            items.Add(item); // safe to add now
            Console.WriteLine("Item added successfully.");

            SaveData(); // save back to file
        }

        public void DisplayAllItems()
        {
            LoadData(); // load latest from file

            if (items.Count == 0)
            {
                Console.WriteLine("No items found in the library yet.");
                return;
            }

            Console.WriteLine("\n========= Library Items =========");
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("=================================");
        }

        // Checks if file exists and has at least one item inside.
        private bool FileHasAnyItem()
        {
            if (!File.Exists(fileName))
                return false;

            string json = File.ReadAllText(fileName);

            return !string.IsNullOrWhiteSpace(json) && json.Trim() != "[]";
        }

        // Loop through items and check if any matches.
        private bool CheckForDuplicates(ILibraryItem newItem)
        {
            foreach (var existingItem in items)
            {
                if (IsDuplicate(existingItem, newItem))
                    return true;
            }
            return false;
        }

        // duplicate logic.
        private bool IsDuplicate(ILibraryItem existingItem, ILibraryItem newItem)
        {
            // Different types cannot be duplicates
            if (existingItem.GetType() != newItem.GetType())
                return false;

            // Check base properties that all items share
            if (existingItem.Title != newItem.Title ||
                existingItem.Publisher != newItem.Publisher ||
                existingItem.PublicationYear != newItem.PublicationYear)
                return false;

            // Check type-specific properties
            if (existingItem is Book existingBook && newItem is Book newBook)
                return existingBook.Author == newBook.Author;

            if (existingItem is Magazine existingMagazine && newItem is Magazine newMagazine)
                return existingMagazine.IssueNumber == newMagazine.IssueNumber;

            if (existingItem is Newspaper existingNews && newItem is Newspaper newNews)
                return existingNews.Editor == newNews.Editor;

            return false;
        }

        // Saves list to json file.
        public void SaveData()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(items, settings);
            File.WriteAllText(fileName, json);
        }

        // Loads list from json file.
        public void LoadData()
        {
            if (!File.Exists(fileName))
            {
                items = new List<ILibraryItem>(); // start with empty list
                return;
            }

            try
            {
                string json = File.ReadAllText(fileName);

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                var loadedItems = JsonConvert.DeserializeObject<List<ILibraryItem>>(json, settings);

                items = loadedItems ?? new List<ILibraryItem>(); // avoid null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                items = new List<ILibraryItem>(); // reset safely
            }
        }
    }
}
