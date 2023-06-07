using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class BookTransfer : IEntityBase
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public bool IsBorrowed { get; set; }

    public bool IsReturned { get; set; }

    public DateTime TransferDate { get; set; }

    public int DiscountId { get; set; }

    public DateTime ExpectedReturnDate { get; set; }

    public virtual Book Book { get; set; }

    public virtual User User { get; set; }

    public virtual Discount Discount { get; set; }
    
    public virtual List<Fine> Fines { get; set; }
}