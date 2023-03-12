using SupplyDepotDomain.DAO;
using SupplyDepotDomain.Model;

internal class Program
{
    public static void Main(string[] args)
    {
        VendorDAO vDao = new VendorDAO();
        OrderDAO oDao = new OrderDAO();

        //GetVendors();

        PlaceOrder();

        void GetVendors()
        {
            var vendors = vDao.GetAllVendors();
            foreach (Vendor v in vendors)
            {
                Console.WriteLine(v);
            }
        }

        void PlaceOrder()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail { ProductId = 1, Quantity = 2, Amount = 13.98m });
            orderDetails.Add(new OrderDetail { ProductId = 2, Quantity = 3, Amount = 188.97m });
            orderDetails.Add(new OrderDetail { ProductId = 3, Quantity = 1, Amount = 5.99m });
            orderDetails.Add(new OrderDetail { ProductId = 4, Quantity = 4, Amount = 15.96m });

            OrderHeader orderHeader = new OrderHeader
            {
                UserId = 1,
                OrderDetails = orderDetails,
                TotalAmount = orderDetails.Select(o => o.Amount).Sum(),
            };

            oDao.CreateOrder(orderHeader);
        }
    }
}