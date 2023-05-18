﻿using Konyvtar_nyilvantarto.Services.LibaryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Contracts.BorrowingData
{
    public class BorrowingRequest
    {
      

        public virtual LibraryMemberEntity LibraryMembers { get; set; }

        public virtual BookEntity Book { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }

    }
}
