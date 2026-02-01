using System;
using LibraryManagementSystemExtended.Abstraction;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Utilities;

namespace LibraryManagementSystemExtended.Model
{
    // Book is a LibraryItemBase with an extra Author field.
    public class Book : LibraryItemBase
    {
        private string author = ""; // private backing field for Author

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be empty.");

                string trimmed = value.Trim();

                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Author must be at least 5 characters long.");

                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Author must start with a capital letter (Example: George Orwell).");

                author = trimmed;
            }
        }

        // Constructor sets base fields + author.
        public Book(string title, string publisher, int year, string author)
            : base(title, publisher, year)
        {
            Author = author; // validate and store
        }

        // Override the base display to show book details.
        public override void DisplayInfo()
        {
            Helper.TypeWriter($"[Book] Title: {Title}, Author: {Author}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
