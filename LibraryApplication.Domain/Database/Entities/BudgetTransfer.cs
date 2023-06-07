using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class BudgetTransfer : IEntityBase
{
    public int Id { get; set; }

    public int TransferTypeId { get; set; }

    public double TransferAmount { get; set; }

    public double TotalAmount { get; set; }

    public int TransferFrom { get; set; }

    public int TransferTo { get; set; }

    public DateTime TransferDate { get; set; }

    public virtual TransferType TransferType { get; set; }
}