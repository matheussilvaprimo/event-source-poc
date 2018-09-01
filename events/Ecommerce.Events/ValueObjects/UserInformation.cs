namespace Ecommerce.Events.ValueObjects
{
    public class UserInformation
    {
        public UserInformation(string fullName, int age, string email, string gender)
        {
            FullName = fullName;
            Age = age;
            Email = email;
            Gender = gender;
        }

        public string FullName { get; }
        public int Age { get; }
        public string Email { get; }
        public string Gender { get; }
    }
}
