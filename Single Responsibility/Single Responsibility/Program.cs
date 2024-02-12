


// Instantiate the classes
var librarySystem = new Library();
var checkoutTransaction = new CheckoutTransaction(librarySystem, librarySystem, librarySystem, librarySystem);

// Example usage
checkoutTransaction.CheckoutBook(12345, "John Doe");



//checking book availability
public interface IAvailabilityChecker
{
    bool IsBookAvailable(int bookId);
}
//recording borrower information
public interface IBorrowerRecorder
{
    void RecordBorrowerInfo(int bookId, string borrowerInfo);
}
//checkout book status
public interface IBookStatusUpdater
{
    void UpdateBookStatus(int bookId, string newStatus);
}
//send notification
public interface INotificationSender
{
    void SendBorrowerNotification(string borrowerInfo);
    void SendLibraryStaffNotification(int bookId, string borrowerInfo);
}
// CheckoutTransaction class coordinating the interactions between components
public class CheckoutTransaction
{
    private readonly IAvailabilityChecker _availabilityChecker;
    private readonly IBorrowerRecorder _borrowerRecorder;
    private readonly IBookStatusUpdater _bookStatusUpdater;
    private readonly INotificationSender _notificationSender;
    public CheckoutTransaction(IAvailabilityChecker availabilityChecker, IBorrowerRecorder borrowerRecorder,
        IBookStatusUpdater bookStatusUpdater, INotificationSender notificationSender)
    {
        _availabilityChecker = availabilityChecker;
        _borrowerRecorder = borrowerRecorder;
        _bookStatusUpdater = bookStatusUpdater;
        _notificationSender = notificationSender;
    }
    public void CheckoutBook(int bookId, string borrowerInfo)
    {
        if (_availabilityChecker.IsBookAvailable(bookId))
        {
            _borrowerRecorder.RecordBorrowerInfo(bookId, borrowerInfo);
            _bookStatusUpdater.UpdateBookStatus(bookId, "Checked Out");
            _notificationSender.SendBorrowerNotification(borrowerInfo);
            _notificationSender.SendLibraryStaffNotification(bookId, borrowerInfo);
            Console.WriteLine("Book checked out successfully!");
        }
        else
        {
            Console.WriteLine("Book is not available for checkout.");
        }
    }

}

class Library : IAvailabilityChecker, IBorrowerRecorder, IBookStatusUpdater, INotificationSender
{
    // Implementations of the interface methods
    public bool IsBookAvailable(int bookId)
    {
        // Logic to check if the book is available
        return true; // Placeholder logic
    }

    public void RecordBorrowerInfo(int bookId, string borrowerInfo)
    {
        // Logic to record borrower information
    }

    public void UpdateBookStatus(int bookId, string newStatus)
    {
        // Logic to update book status
    }

    public void SendBorrowerNotification(string borrowerInfo)
    {
        // Logic to send notification to the borrower
    }

    public void SendLibraryStaffNotification(int bookId, string borrowerInfo)
    {
        // Logic to send notification to library staff
    }
}