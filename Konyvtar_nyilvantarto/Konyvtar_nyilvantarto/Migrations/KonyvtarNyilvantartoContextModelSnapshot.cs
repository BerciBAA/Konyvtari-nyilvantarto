﻿// <auto-generated />
using Konyvtar_nyilvantarto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Konyvtar_nyilvantarto.Migrations
{
    [DbContext(typeof(KonyvtarNyilvantartoContext))]
    partial class KonyvtarNyilvantartoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Konyvtar_nyilvantarto.Book", b =>
                {
                    b.Property<string>("accessionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("accessionNumber");

                    b.ToTable("books");
                });
#pragma warning restore 612, 618
        }
    }
}
