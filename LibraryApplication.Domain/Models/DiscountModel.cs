namespace LibraryApplication.Data.Models;

public class DiscountModel : IModelBase
{
    public int Id { get; set; }
    
    public int UserCategoryId { get; set; }
    
    public int Amount { get; set; }
}