using SupplyOrderData;
using SupplyOrderDomain;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static void Main(string[] args)
    {
        //UI_MainMenu ui = new UI_MainMenu();
        //ui.MainMenu();

        GetAllPeople();

        void GetAllPeople()
        {
            using SOContext context = new SOContext();
            List<Person> people = context.People.ToList();
            foreach(Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}