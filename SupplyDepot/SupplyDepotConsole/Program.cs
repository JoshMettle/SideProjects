using SupplyDepotData;
using SupplyDepotDomain;


internal class Program
{
    private static void Main(string[] args)
    {
        GetAllPeople();

        GetAllVendors();

        AddPerson("Sam", "Watson", "swatson@supplyorders.com", "614-987-6543");

        GetAllPeople();
        
        void GetAllPeople()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Person> people = context.People.ToList();
            foreach(Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        void GetAllVendors()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Vendor> vendors = context.Vendors.ToList();
            foreach(Vendor vendor in vendors)
            {
                
                Console.WriteLine(vendor);
            }
        }

        void AddPerson(string first, string last, string email, string? phone)
        {
            Person person = new Person { FirstName = first, LastName = last, Email = email, Phone = phone };
            using SupplyOrdersContext context = new SupplyOrdersContext();
            context.People.Add(person);
            context.SaveChanges();
        }
    }
}