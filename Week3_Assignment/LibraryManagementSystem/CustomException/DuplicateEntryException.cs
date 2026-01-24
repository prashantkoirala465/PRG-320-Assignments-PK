using System;

namespace LibraryManagementSystem.CustomException
{
    // Custom exception for duplicate entries (same Title + Publisher + PublicationYear).
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
