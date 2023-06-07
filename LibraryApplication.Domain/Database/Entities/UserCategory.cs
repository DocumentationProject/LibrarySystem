using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class UserCategory : IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual List<User> Users { get; set; } = new();
}