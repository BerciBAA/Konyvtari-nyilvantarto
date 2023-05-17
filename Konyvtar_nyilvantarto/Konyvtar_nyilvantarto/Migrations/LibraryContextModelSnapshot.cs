﻿// <auto-generated />
using System;
using Konyvtar_nyilvantarto.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Konyvtar_nyilvantarto.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Konyvtar_nyilvantarto.BookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Konyvtar_nyilvantarto.Services.BorrowingData.Model.BorrowingDataEntity", b =>
                {
                    b.Property<Guid>("BorrowingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LibraryMembersMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BorrowingId");

                    b.HasIndex("BookId");

                    b.HasIndex("LibraryMembersMemberId");

                    b.ToTable("borrowingData");
                });

            modelBuilder.Entity("Konyvtar_nyilvantarto.Services.LibaryMembers.Model.LibraryMemberEntity", b =>
                {
                    b.Property<Guid>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("LibraryMembers");
                });

            modelBuilder.Entity("Konyvtar_nyilvantarto.Services.BorrowingData.Model.BorrowingDataEntity", b =>
                {
                    b.HasOne("Konyvtar_nyilvantarto.BookEntity", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Konyvtar_nyilvantarto.Services.LibaryMembers.Model.LibraryMemberEntity", "LibraryMembers")
                        .WithMany()
                        .HasForeignKey("LibraryMembersMemberId");

                    b.Navigation("Book");

                    b.Navigation("LibraryMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
