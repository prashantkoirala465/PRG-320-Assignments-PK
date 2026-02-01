namespace LibraryManagementSystemExtended.Interface
{
    // This interface holds common fields for any library item (Book, Magazine, Newspaper).
    public interface ILibraryItem
    {
        // Common properties
        string Title { get; set; }
        string Publisher { get; set; }
        int PublicationYear { get; set; }

        // Common display method (will be overridden in child classes).
        void DisplayInfo();
    }
}
