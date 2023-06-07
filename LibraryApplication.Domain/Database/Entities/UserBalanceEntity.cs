using LibraryApplication.Data.Database.Base;

namespace LibraryApplication.Data.Database.Entities;

public class UserBalanceEntity : IEntityBase
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double Amount { get; set; }

    public virtual UserEntity UserEntity { get; set; }
}