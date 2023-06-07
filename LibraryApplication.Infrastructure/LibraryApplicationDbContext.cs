using LibraryApplication.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Infrastructure;

public sealed class LibraryApplicationDbContext: DbContext
{
    public LibraryApplicationDbContext(DbContextOptions<LibraryApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Author> Authors => Set<Author>();
    
    public DbSet<Book> Books => Set<Book>();
    
    public DbSet<BookGenre> BookGenres => Set<BookGenre>();
    
    public DbSet<BookTransfer> BookTransfers => Set<BookTransfer>();
    
    public DbSet<BudgetTransfer> BudgetTransfers => Set<BudgetTransfer>();
    
    public DbSet<Discount> Discounts => Set<Discount>();
    
    public DbSet<Fine> Fines => Set<Fine>();
    
    public DbSet<TransferType> TransferTypes => Set<TransferType>();

    public DbSet<User> Users => Set<User>();

    public DbSet<UserBalance> UserBalances => Set<UserBalance>();

    public DbSet<UserBalanceTransfer> UserBalanceTransfers => Set<UserBalanceTransfer>();

    public DbSet<UserCategory> UserCategories => Set<UserCategory>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
        
        modelBuilder.Entity<Book>()
            .HasOne(x => x.Genre)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.GenreId);
        
        modelBuilder.Entity<BookTransfer>()
            .HasOne(x => x.Book)
            .WithMany(x => x.BookTransfers)
            .HasForeignKey(x => x.BookId);
        
        modelBuilder.Entity<BookTransfer>()
            .HasOne(x => x.Discount)
            .WithMany(x => x.BookTransfers)
            .HasForeignKey(x => x.DiscountId);

        modelBuilder.Entity<Fine>()
            .HasOne(x => x.User)
            .WithMany(x => x.Fines)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Fine>()
            .HasOne(x => x.BookTransfer)
            .WithMany(x => x.Fines)
            .HasForeignKey(x => x.BookTransferId);

        modelBuilder.Entity<UserBalance>()
            .HasOne(x => x.User)
            .WithOne(x => x.UserBalance);

        modelBuilder.Entity<User>()
            .HasMany(x => x.UserCategories)
            .WithMany(x => x.Users);
        
        modelBuilder.Entity<UserBalanceTransfer>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserBalanceTransfers)
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<UserBalanceTransfer>()
            .HasOne(x => x.TransferType)
            .WithMany(x => x.UserBalanceTransfers)
            .HasForeignKey(x => x.TransferTypeId);
        
        modelBuilder.Entity<BudgetTransfer>()
            .HasOne(x => x.TransferType)
            .WithMany(x => x.BudgetTransfers)
            .HasForeignKey(x => x.TransferTypeId);
    }
}