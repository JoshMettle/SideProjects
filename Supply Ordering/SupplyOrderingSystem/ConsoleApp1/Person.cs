using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm
{
    public class Person
    {
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Person (string firstName, string lastName, string email, string phone, int personId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phone;
            PersonId = personId;
        }

        public override string ToString()
        {
            return $"{FirstName+ " " +LastName,-27}{Email.PadRight(35)}{PhoneNumber,-15}";
        }
    }
}
