using System;
using LibraryManagementSystem.CustomException;

namespace LibraryManagementSystem.Model
{
    // Base class "Item".
    public abstract class Item
    {
        // Private fields.
        private string _title = "";
        private string _publisher = "";
        private int _publicationYear;

        public string Title
        {
            get { return _title; }
            set
            {
                // 1) Null/empty check
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be empty.");

                string trimmed = value.Trim();

                // 2) Length check (at least 5 characters)
                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Title must be at least 5 characters long.");

                // 3) Must start with a capital letter
                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Title must start with a capital letter (example: The Great Gatsby).");

                _title = trimmed;
            }
        }

        public string Publisher
        {
            get { return _publisher; }
            set
            {
                // 1) Null/empty check
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be empty.");

                string trimmed = value.Trim();

                // 2) Length check (at least 6 characters)
                if (trimmed.Length < 6)
                    throw new InvalidItemDataException("Publisher must be at least 6 characters long.");

                // 3) Must start with a capital letter
                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Publisher must start with a capital letter (example: Hachette).");

                _publisher = trimmed;
            }
        }

        public int PublicationYear
        {
            get { return _publicationYear; }
            set
            {
                // Must be exactly 4 digits (example: 1991, 2005)
                string yearText = value.ToString();
                if (yearText.Length != 4)
                    throw new InvalidItemDataException("Publication year must be exactly 4 digits (example: 2005).");

                _publicationYear = value;
            }
        }

        // Constructor to make sure every item has required values.
        protected Item(string title, string publisher, int publicationYear)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
        }

        // Method (virtual so it can be overridden).
        public virtual void DisplayItems()
        {
            Console.WriteLine($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
