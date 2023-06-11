using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class FineEntity : IEntityBase
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual UserEntity UserEntity { get; set; }

    public virtual BookEntity BookEntity { get; set; }
}