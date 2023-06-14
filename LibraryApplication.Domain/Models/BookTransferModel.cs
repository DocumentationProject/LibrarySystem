namespace LibraryApplication.Data.Models;

public class BookTransferModel : IModelBase
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public bool IsBorrowed { get; set; }

    public bool IsReturned { get; set; }

    public DateTime TransferDate { get; set; }

    public int? DiscountId { get; set; }

    public DateTime? ExpectedReturnDate { get; set; }
}