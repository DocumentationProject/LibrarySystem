using AutoMapper;
using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Models;

namespace LibraryApplication.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookEntity, BookModel>();
        CreateMap<UserEntity, UserModel>();
        CreateMap<FineEntity, FineModel>();
        CreateMap<AuthorEntity, AuthorModel>();
        CreateMap<BookGenre, BookGenreModel>();
        CreateMap<BookTransferEntity, BookTransferModel>();
        CreateMap<BudgetTransferEntity, BudgetTransferModel>();
        CreateMap<DiscountEntity, DiscountModel>();
        CreateMap<TransferType, TransferTypeModel>();
        CreateMap<UserBalanceTransferEntity, UserBalanceTransferModel>();
        CreateMap<UserCategoryEntity, UserCategoryModel>();
    }   
}