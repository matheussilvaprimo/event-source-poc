using System;

namespace User.BackOffice.EventSourcing.VOs
{
    public class UserInformation
    {
        public DateTime? DateOfBirth { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }    }

    public enum Gender
    {
        Male,
        Female
    }
}
