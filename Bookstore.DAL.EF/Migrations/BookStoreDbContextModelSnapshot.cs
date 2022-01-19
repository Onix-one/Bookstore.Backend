﻿// <auto-generated />
using System;
using Bookstore.DAL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookstore.DAL.EF.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCustomer", b =>
                {
                    b.Property<int>("BroughtBooksId")
                        .HasColumnType("int");

                    b.Property<int>("BuyersId")
                        .HasColumnType("int");

                    b.HasKey("BroughtBooksId", "BuyersId");

                    b.HasIndex("BuyersId");

                    b.ToTable("BookCustomer");
                });

            modelBuilder.Entity("BookCustomer1", b =>
                {
                    b.Property<int>("BooksReadyToBuyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomersWantedToBuyId")
                        .HasColumnType("int");

                    b.HasKey("BooksReadyToBuyId", "CustomersWantedToBuyId");

                    b.HasIndex("CustomersWantedToBuyId");

                    b.ToTable("BookCustomer1");
                });

            modelBuilder.Entity("BookCustomer2", b =>
                {
                    b.Property<int>("FansId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteBooksId")
                        .HasColumnType("int");

                    b.HasKey("FansId", "FavoriteBooksId");

                    b.HasIndex("FavoriteBooksId");

                    b.ToTable("BookCustomer2");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biografy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.AuthorGenreOfBook", b =>
                {
                    b.Property<int>("GenreOfBookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("GenreOfBookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorGenreOfBook");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookGenreOfBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreOfBookId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreOfBookId");

                    b.HasIndex("GenreOfBookId");

                    b.ToTable("BookGenreOfBook");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookImages");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bonuses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.GenreOfBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GenresOfBooks");
                });

            modelBuilder.Entity("CustomerGenreOfBook", b =>
                {
                    b.Property<int>("FansOfGenresId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteTypesId")
                        .HasColumnType("int");

                    b.HasKey("FansOfGenresId", "FavoriteTypesId");

                    b.HasIndex("FavoriteTypesId");

                    b.ToTable("CustomerGenreOfBook");
                });

            modelBuilder.Entity("BookCustomer", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BroughtBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("BuyersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCustomer1", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksReadyToBuyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersWantedToBuyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCustomer2", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("FansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("FavoriteBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.AuthorGenreOfBook", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Author", "Author")
                        .WithMany("AuthorGenreOfBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.GenreOfBook", "GenreOfBook")
                        .WithMany("AuthorGenreOfBooks")
                        .HasForeignKey("GenreOfBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("GenreOfBook");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookAuthor", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookGenreOfBook", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Book", "Book")
                        .WithMany("BookGenreOfBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.GenreOfBook", "GenreOfBook")
                        .WithMany("BookGenreOfBooks")
                        .HasForeignKey("GenreOfBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("GenreOfBook");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookImage", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Book", "Book")
                        .WithMany("Images")
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CustomerGenreOfBook", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("FansOfGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.GenreOfBook", null)
                        .WithMany()
                        .HasForeignKey("FavoriteTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Author", b =>
                {
                    b.Navigation("AuthorGenreOfBooks");

                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookGenreOfBooks");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Bookstore.Core.Models.Entities.GenreOfBook", b =>
                {
                    b.Navigation("AuthorGenreOfBooks");

                    b.Navigation("BookGenreOfBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
