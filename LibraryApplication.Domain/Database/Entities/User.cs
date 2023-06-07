using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class User : IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Address { get; set; }

    public bool IsAdmin { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual List<UserCategory> UserCategories { get; set; } = new();

    public virtual List<Fine> Fines { get; set; }

    public virtual UserBalance UserBalance { get; set; }

    public virtual List<UserBalanceTransfer> UserBalanceTransfers { get; set; }
}