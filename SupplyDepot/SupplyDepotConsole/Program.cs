using SupplyDepotDomain.DAO;
using SupplyDepotDomain.Model;

internal class Program
{
    public static void Main(string[] args)
    {
        VendorDAO vDao = new VendorDAO();

        GetVendors();
            
        void GetVendors()
        {
            var vendors = vDao.GetAllVendors();
            foreach (Vendor v in vendors)
            {
                Console.WriteLine(v);
            }
        }
    }
}