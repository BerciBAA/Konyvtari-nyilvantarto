﻿using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Contracts.BorrowingData
{
    public class BorrowingResponse : BorrowingBase
    {
        public Guid BorrowingId { get; set; }
       
    }
}
