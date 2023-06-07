using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class Author : IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public virtual List<Book> Books { get; set; }
}