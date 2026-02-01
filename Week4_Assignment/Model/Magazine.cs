using System;
using LibraryManagementSystemExtended.Abstraction;
using LibraryManagementSystemExtended.CustomException;
using LibraryManagementSystemExtended.Utilities;

namespace LibraryManagementSystemExtended.Model
{
    // Magazine is a LibraryItemBase with an IssueNumber.
    public class Magazine : LibraryItemBase
    {
        private int issueNumber; // stores validated issue number

        public int IssueNumber
        {
            get { return issueNumber; }
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be greater than 0.");
                issueNumber = value;
            }
        }

        public Magazine(string title, string publisher, int year, int issueNumber)
            : base(title, publisher, year)
        {
            IssueNumber = issueNumber; // validate and store
        }

        public override void DisplayInfo()
        {
            Helper.TypeWriter($"[Magazine] Title: {Title}, Issue: {IssueNumber}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
