using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryRegister.Contracts.BorrowingData
{
    public class BookStateResponse
    {
        public bool IsOnLoan { get; set; }

        public LibraryMemberResponse LibraryMembers { get; set; }

        public DateTime RetrievalLimitTime { get; set; }
    }
}
