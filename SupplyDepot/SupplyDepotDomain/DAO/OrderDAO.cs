using SupplyDepotDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepotDomain.DAO
{
    public class OrderDAO
    {
        public OrderHeader CreateOrder(OrderHeader orderHeader, List<OrderDetail> orderDetails)
        {
            orderHeader.OrderDetails = orderDetails;
            using SupplyOrdersContext context = new SupplyOrdersContext();
            context.OrderHeaders.Add(orderHeader);
            context.SaveChanges();

            return orderHeader;
        }

        
    }
}
