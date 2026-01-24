using System;
using LibraryManagementSystem.CustomException;

namespace LibraryManagementSystem.Model
{
    // Child class Magazine inheriting Item.
    public class Magazine : Item
    {
        private int _issueNumber;

        public int IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be a positive number.");
                _issueNumber = value;
            }
        }

        public Magazine(string title, string publisher, int publicationYear, int issueNumber)
            : base(title, publisher, publicationYear)
        {
            IssueNumber = issueNumber;
        }

        // Override to show magazine specific information.
        public override void DisplayItems()
        {
            base.DisplayItems();
            Console.WriteLine($"Issue Number: {IssueNumber}");
        }
    }
}
