using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class Discount : IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Amount { get; set; }

    public virtual List<BookTransfer> BookTransfers { get; set; }
}