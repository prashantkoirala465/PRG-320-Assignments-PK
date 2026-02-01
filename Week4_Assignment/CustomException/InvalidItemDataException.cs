using System;

namespace LibraryManagementSystemExtended.CustomException
{
    // Custom exception for invalid user input.
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message)
        {
            // Same idea, we only store the message.
        }
    }
}
