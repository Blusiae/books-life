﻿// <auto-generated />
using System;
using BooksLife.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksLife.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602081644_AddedIsActivePropertyToBorrow")]
    partial class AddedIsActivePropertyToBorrow
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksLife.Core.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BooksLife.Core.AuthorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BooksLife.Core.BookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookTitleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("ConditionNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditionPublicationYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookTitleId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksLife.Core.BookTitleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookTitles");
                });

            modelBuilder.Entity("BooksLife.Core.BorrowEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("BooksLife.Core.ReaderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("BooksLife.Core.BookEntity", b =>
                {
                    b.HasOne("BooksLife.Core.BookTitleEntity", "BookTitle")
                        .WithMany("Books")
                        .HasForeignKey("BookTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookTitle");
                });

            modelBuilder.Entity("BooksLife.Core.BookTitleEntity", b =>
                {
                    b.HasOne("BooksLife.Core.AuthorEntity", "Author")
                        .WithMany("BookTitles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BooksLife.Core.BorrowEntity", b =>
                {
                    b.HasOne("BooksLife.Core.BookEntity", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BooksLife.Core.ReaderEntity", "Reader")
                        .WithMany("Borrows")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("BooksLife.Core.ReaderEntity", b =>
                {
                    b.HasOne("BooksLife.Core.AddressEntity", "Address")
                        .WithMany("Readers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BooksLife.Core.AddressEntity", b =>
                {
                    b.Navigation("Readers");
                });

            modelBuilder.Entity("BooksLife.Core.AuthorEntity", b =>
                {
                    b.Navigation("BookTitles");
                });

            modelBuilder.Entity("BooksLife.Core.BookEntity", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("BooksLife.Core.BookTitleEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BooksLife.Core.ReaderEntity", b =>
                {
                    b.Navigation("Borrows");
                });
#pragma warning restore 612, 618
        }
    }
}
