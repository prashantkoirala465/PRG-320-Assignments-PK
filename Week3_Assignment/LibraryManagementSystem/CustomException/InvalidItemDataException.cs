using System;

namespace LibraryManagementSystem.CustomException
{
    // Custom exception for invalid item input/data.
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message)
        {
        }
    }
}
