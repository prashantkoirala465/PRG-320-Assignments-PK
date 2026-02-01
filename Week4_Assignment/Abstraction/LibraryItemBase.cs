using System;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Interface;
using LibraryManagementSystemExtended.Utilities;

namespace LibraryManagementSystemExtended.Abstraction
{
    // Base abstract class for all library items.
    public abstract class LibraryItemBase : ILibraryItem
    {
        // Private fields (encapsulation)
        private string title = "";          // stores validated title
        private string publisher = "";      // stores validated publisher
        private int publicationYear;        // stores validated year

        // Public property with validation for Title.
        public string Title
        {
            get { return title; } // give title back
            set
            {
                // quick validation checks
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be empty.");

                string trimmed = value.Trim(); // remove extra spaces

                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Title must be at least 5 characters long.");

                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Title must start with a capital letter (Example: The Great Gatsby).");

                title = trimmed; // save only validated value
            }
        }

        // Public property with validation for Publisher.
        public string Publisher
        {
            get { return publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be empty.");

                string trimmed = value.Trim();

                if (trimmed.Length < 6)
                    throw new InvalidItemDataException("Publisher must be at least 6 characters long.");

                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Publisher must start with a capital letter (Example: Penguin).");

                publisher = trimmed;
            }
        }

        // Public property with validation for PublicationYear.
        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                // year must be 4 digits
                if (value.ToString().Length != 4)
                    throw new InvalidItemDataException("Publication year must be exactly 4 digits (Example: 2005).");

                publicationYear = value;
            }
        }

        // Constructor to set base values.
        protected LibraryItemBase(string title, string publisher, int publicationYear)
        {
            Title = title;                   // validated via property
            Publisher = publisher;           // validated via property
            PublicationYear = publicationYear; // validated via property
        }

        // Base display method (polymorphism via override in child classes).
        public virtual void DisplayInfo()
        {
            Helper.TypeWriter($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
