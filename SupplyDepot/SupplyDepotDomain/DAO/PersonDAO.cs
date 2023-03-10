using SupplyDepotDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepotDomain.DAO
{
    public class PersonDAO
    {
        /// <summary>
        /// Will find all people in the database
        /// </summary>
        /// <returns>A list of all people in the database</returns>
        public List<Person> GetAllPeople()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Person> people = context.People.ToList();

            return people;
        }

        /// <summary>
        /// Takes in the person Primary Key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Any record with the matching key or null if no match found</returns>
        public Person? GetPersonById(int id)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();

            Person? person = context.People.Find(id);

            return person;
        }

        /// <summary>
        /// Takes in the parameters and adds the person record to the database.
        /// </summary>
        /// <param name="first"> First name</param>
        /// <param name="last"> Last name</param>
        /// <param name="email"> Email address</param>
        /// <param name="phone"> Phone number, can be null</param>
        /// <returns> Returns the record added to the database</returns>
        public Person AddPerson(string first, string last, string email, string? phone)
        {
            Person person = new Person { FirstName = first, LastName = last, Email = email, Phone = phone };
            using SupplyOrdersContext context = new SupplyOrdersContext();
            context.People.Add(person);
            context.SaveChanges();

            return person;
        }

        /// <summary>
        /// Updates Person record to flag them as inactive
        /// </summary>
        /// <param name="id"> Target Person Id</param>
        /// <returns>True if Person record set to Inactive</returns>
        public bool DeactivatePerson(int id)
        {
            bool isInactive = false;
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Person? person = context.People.Find(id);
            if (person != null)
            {
                person.IsInactive = true;
                context.SaveChanges();
                isInactive = true;
            }

            return isInactive;
        }

    }
}
