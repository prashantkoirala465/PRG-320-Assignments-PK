using System;

namespace LibraryManagementSystemExtended.CustomException
{
    // Custom exception for duplicate entries.
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message)
        {
            // Nothing special, just passing message to base Exception.
        }
    }
}
