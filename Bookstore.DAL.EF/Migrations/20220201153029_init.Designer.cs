﻿// <auto-generated />
using System;
using Bookstore.DAL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookstore.DAL.EF.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20220201153029_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

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

            modelBuilder.Entity("BookGenreOfBook", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenreOfBooksId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenreOfBooksId");

                    b.HasIndex("GenreOfBooksId");

                    b.ToTable("BookGenreOfBook");
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

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookUrl")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Bookstore.Core.Models.Entities.BookImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Name")
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

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("BookGenreOfBook", b =>
                {
                    b.HasOne("Bookstore.Core.Models.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookstore.Core.Models.Entities.GenreOfBook", null)
                        .WithMany()
                        .HasForeignKey("GenreOfBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Bookstore.Core.Models.Entities.Book", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
