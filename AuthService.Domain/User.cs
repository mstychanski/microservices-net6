using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}

