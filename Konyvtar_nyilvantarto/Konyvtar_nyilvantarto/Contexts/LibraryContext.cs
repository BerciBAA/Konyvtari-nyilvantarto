﻿using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using LibaryRegister.Contracts.Book;
using LibaryRegister.Contracts.LibraryMember;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookEntity> Books { get; set; }

        public DbSet<LibraryMemberEntity> LibraryMembers { get; set; }

        public DbSet<BorrowingDataEntity> BorrowingData { get; set; }


      
    }
}