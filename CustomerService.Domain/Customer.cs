using Core.Domain;

namespace CustomerService.Domain
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Pesel { get; set; }
        public bool IsRemoved { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}