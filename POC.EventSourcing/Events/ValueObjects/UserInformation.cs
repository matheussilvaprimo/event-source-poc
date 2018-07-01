using System;
using Events.Enums;

namespace Events.ValueObjects
{
    public class UserInformation
    {
        public UserInformation(DateTime? dateOfBirth, string fullName, Gender gender, string email)
        {
            DateOfBirth = dateOfBirth;
            FullName = fullName;
            Gender = gender;
            Email = email;
        }

        public DateTime? DateOfBirth { get; }
        public string FullName { get; }
        public Gender Gender { get; }
        public string Email { get; }        
    }
}

namespace Events.Enums
{
    public enum Gender
    {
        Male,
        Female
    }
}

