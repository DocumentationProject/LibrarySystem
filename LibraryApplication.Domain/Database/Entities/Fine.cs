using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class Fine : IEntityBase
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookTransferId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; }

    public virtual BookTransfer BookTransfer { get; set; }
}