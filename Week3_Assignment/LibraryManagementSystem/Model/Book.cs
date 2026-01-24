using System;
using LibraryManagementSystem.CustomException;

namespace LibraryManagementSystem.Model
{
    // Child class Book inheriting Item.
    public class Book : Item
    {
        private string _author = "";

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be empty.");

                string trimmed = value.Trim();

                // Similar validation style as Title/Publisher
                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Author must be at least 5 characters long.");

                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Author must start with a capital letter (example: George Orwell).");

                _author = trimmed;
            }
        }

        public Book(string title, string publisher, int publicationYear, string author)
            : base(title, publisher, publicationYear)
        {
            Author = author;
        }

        // Override to show book specific information.
        public override void DisplayItems()
        {
            base.DisplayItems();
            Console.WriteLine($"Author: {Author}");
        }
    }
}
