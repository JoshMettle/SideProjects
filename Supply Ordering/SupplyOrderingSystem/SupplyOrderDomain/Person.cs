using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain
{
    [Table("Person")]
    public class Person
    {
        [Range(1,int.MaxValue)]
        public int PersonId { get;  set; }
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string LastName { get;  set; }
        [Required]
        public string Email { get;  set; }
        [Phone]
        public string? PhoneNumber { get;  set; }

        public Person (string firstName, string lastName, string email, string phone, int personId)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phone;
        }

        public Person(string firstName, string lastName, string email, int personId)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName+ " " +LastName,-27}{Email.PadRight(35)}{PhoneNumber,-15}";
        }
    }
}
