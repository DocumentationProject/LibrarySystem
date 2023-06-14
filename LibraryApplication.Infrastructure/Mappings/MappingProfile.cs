using AutoMapper;
using LibraryApplication.Data.Database.Entities;
using LibraryApplication.Data.Models;

namespace LibraryApplication.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // entity to model
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
        
        // model to entity
        CreateMap<BookModel, BookEntity>();
        CreateMap<UserModel, UserEntity>();
        CreateMap<FineModel, FineEntity>();
        CreateMap<AuthorModel, AuthorEntity>();
        CreateMap<BookGenreModel, BookGenre>();
        CreateMap<BookTransferModel, BookTransferEntity>();
        CreateMap<BudgetTransferModel, BudgetTransferEntity>();
        CreateMap<DiscountModel, DiscountEntity>();
        CreateMap<TransferTypeModel, TransferType>();
        CreateMap<UserBalanceTransferModel, UserBalanceTransferEntity>();
        CreateMap<UserCategoryModel, UserCategoryEntity>();
    }   
}