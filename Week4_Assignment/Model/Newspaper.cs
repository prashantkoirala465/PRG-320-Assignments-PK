using System;
using LibraryManagementSystemExtended.Abstraction;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Utilities;

namespace LibraryManagementSystemExtended.Model
{
    // Newspaper is a LibraryItemBase with an Editor field.
    public class Newspaper : LibraryItemBase
    {
        private string editor = ""; // stores validated editor name

        public string Editor
        {
            get { return editor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Editor cannot be empty.");

                string trimmed = value.Trim();

                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Editor must be at least 5 characters long.");

                if (!char.IsUpper(trimmed[0]))
                    throw new InvalidItemDataException("Editor must start with a capital letter (Example: John Smith).");

                editor = trimmed;
            }
        }

        public Newspaper(string title, string publisher, int year, string editor)
            : base(title, publisher, year)
        {
            Editor = editor;
        }

        public override void DisplayInfo()
        {
            Helper.TypeWriter($"[Newspaper] Title: {Title}, Editor: {Editor}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
