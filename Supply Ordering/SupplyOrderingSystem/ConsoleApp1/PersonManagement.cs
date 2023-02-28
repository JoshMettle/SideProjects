using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm
{
    public class PersonManagement
    {
        private List<Person> contactList = new List<Person>();

        public void AddContact(string firstName, string lastName, string email, string phoneNumber, int personId)
        {
            Person contact = new Person(firstName, lastName, email, phoneNumber, personId);

            contactList.Add(contact);
        }

        public string DisplayContact()
        {
            StringBuilder sb = new StringBuilder();
            bool foundMatch = false;
            sb.AppendLine("Id   First Name          Last Name           Email                              Phone Number");

            foreach (Person contact in contactList)
            {

                    sb.AppendLine($"{contact.PersonId.ToString().PadRight(5)}{contact.FirstName.PadRight(20)}{contact.LastName.PadRight(20)}{contact.Email.PadRight(35)}{contact.PhoneNumber}");
                    foundMatch = true;
            }

            if (foundMatch)
            {
                return sb.ToString();
            }
            else
            {
                return "No Contacts Found";
            }
        }

        public string DisplayContact(string firstName, string lastName)
        {
            StringBuilder sb = new StringBuilder();
            bool foundMatch = false;
            sb.AppendLine("Id   First Name          Last Name           Email                              Phone Number");

            foreach(Person contact in contactList)
            {
                if(contact.FirstName == firstName && contact.LastName == lastName)
                {
                    sb.AppendLine ($"{contact.PersonId.ToString().PadRight(5)}{contact.FirstName.PadRight(20)}{contact.LastName.PadRight(20)}{contact.Email.PadRight(35)}{contact.PhoneNumber}");
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return sb.ToString();
            }
            else
            {
                return "No Matching Contact Found";
            }
        }

        public Person FindPerson (int id)
        {
            foreach (Person contact in contactList)
            {
                if(contact.PersonId == id){
                    return contact;
                }
            }
            return null;
        }
    }
}
