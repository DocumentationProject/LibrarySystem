using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class UserBalanceTransfer : IEntityBase
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double Amount { get; set; }

    public DateTime TransferDate { get; set; }

    public int TransferTypeId { get; set; }

    public virtual User User { get; set; }

    public virtual TransferType TransferType { get; set; }
}   