﻿// <auto-generated />
using System;
using LibraryApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApplication.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryApplicationDbContext))]
    partial class LibraryApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.AuthorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RentPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpectedReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("BookTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BudgetTransferEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<double>("TransferAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransferFrom")
                        .HasColumnType("int");

                    b.Property<int>("TransferTo")
                        .HasColumnType("int");

                    b.Property<int>("TransferTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransferTypeId");

                    b.ToTable("BudgetTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.DiscountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.FineEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("BookTransferId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookTransferId");

                    b.HasIndex("UserId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.TransferType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransferTypes");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserBalanceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserBalances");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserBalanceTransferEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransferTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransferTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBalanceTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserCategoryEntityUserEntity", b =>
                {
                    b.Property<int>("UserCategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("UserCategoriesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserCategoryEntityUserEntity");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.AuthorEntity", "AuthorEntity")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.BookGenre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorEntity");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.BookEntity", "BookEntity")
                        .WithMany("BookTransfers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.DiscountEntity", "DiscountEntity")
                        .WithMany("BookTransfers")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId");

                    b.Navigation("BookEntity");

                    b.Navigation("DiscountEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BudgetTransferEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.TransferType", "TransferType")
                        .WithMany("BudgetTransfers")
                        .HasForeignKey("TransferTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransferType");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.FineEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.BookEntity", "BookEntity")
                        .WithMany("Fines")
                        .HasForeignKey("BookTransferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.UserEntity", "UserEntity")
                        .WithMany("Fines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserBalanceTransferEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.TransferType", "TransferType")
                        .WithMany("UserBalanceTransfers")
                        .HasForeignKey("TransferTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.UserEntity", "UserEntity")
                        .WithMany("UserBalanceTransfers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransferType");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.UserBalanceEntity", "UserBalanceEntity")
                        .WithOne("UserEntity")
                        .HasForeignKey("LibraryApplication.Data.Database.Entities.UserEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBalanceEntity");
                });

            modelBuilder.Entity("UserCategoryEntityUserEntity", b =>
                {
                    b.HasOne("LibraryApplication.Data.Database.Entities.UserCategoryEntity", null)
                        .WithMany()
                        .HasForeignKey("UserCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApplication.Data.Database.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.AuthorEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.Navigation("BookTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookGenre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.BookEntity", b =>
                {
                    b.Navigation("Fines");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.DiscountEntity", b =>
                {
                    b.Navigation("BookTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.TransferType", b =>
                {
                    b.Navigation("BudgetTransfers");

                    b.Navigation("UserBalanceTransfers");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserBalanceEntity", b =>
                {
                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("LibraryApplication.Data.Database.Entities.UserEntity", b =>
                {
                    b.Navigation("Fines");

                    b.Navigation("UserBalanceTransfers");
                });
#pragma warning restore 612, 618
        }
    }
}