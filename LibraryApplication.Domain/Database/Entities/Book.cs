using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class Book : IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int AuthorId { get; set; }

    public double RentPrice { get; set; }

    public int GenreId { get; set; }

    public virtual Author Author { get; set; }

    public virtual BookGenre Genre { get; set; }

    public virtual List<BookTransfer> BookTransfers { get; set; }
}