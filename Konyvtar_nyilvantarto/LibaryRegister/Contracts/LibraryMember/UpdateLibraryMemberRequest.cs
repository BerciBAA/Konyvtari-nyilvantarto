﻿namespace LibaryRegister.Contracts.LibraryMember
{
    public sealed class UpdateLibraryMemberRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
