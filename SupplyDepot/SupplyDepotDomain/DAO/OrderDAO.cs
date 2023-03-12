using Microsoft.EntityFrameworkCore;
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
        public OrderHeader CreateOrder(OrderHeader orderHeader)
        {
            
            using SupplyOrdersContext context = new SupplyOrdersContext();
            context.OrderHeaders.Add(orderHeader);
            context.SaveChanges();   
            CreateVendorOrders(orderHeader);
            return orderHeader;
        }

        private void CreateVendorOrders(OrderHeader orderHeader)
        
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            orderHeader.OrderDetails = context.OrderDetails.Where(od => od.OrderId == orderHeader.OrderId)
                                                           .Include(od => od.Product)
                                                           .Include(od => od.Product.Vendor)
                                                           .ToList();
            List<Vendor> orderVendors = orderHeader.OrderDetails.Select(o => o.Product.Vendor)
                                                                .Distinct()
                                                                .ToList();
            User user = context.Users.Where(u => u.UserId == orderHeader.UserId)
                                     .Include(u => u.LocationNavigation).First();
            List<VendorOrderHeader> vendorOrders = new List<VendorOrderHeader>();
            foreach(Vendor vendor in orderVendors)
            {
                List<OrderDetail> orderDetailsByVendor = orderHeader.OrderDetails.Where(o => o.Product.Vendor == vendor).ToList(); 
                VendorOrderHeader vendorOrderHeader = new VendorOrderHeader();
                vendorOrderHeader.OrderId = orderHeader.OrderId;
                vendorOrderHeader.Vendor = vendor;
                vendorOrderHeader.Amount = orderHeader.OrderDetails.Where(o => o.Product.VendorId == vendor.VendorId)
                                                                   .Select(o => o.Amount)
                                                                   .Sum();
                vendorOrderHeader.ShipToId = user.LocationId;
                
                foreach(OrderDetail orderDetail in orderDetailsByVendor)
                {
                    VendorOrderDetail vendorOrderDetail = new VendorOrderDetail
                    {
                        VendorItemNumber = orderDetail.Product.VendorProductNumber,
                        OrderId = orderHeader.OrderId,
                        Quantity = orderDetail.Quantity,
                        Amount = orderDetail.Amount
                    };
                    vendorOrderHeader.VendorOrderDetails.Add(vendorOrderDetail);
                }
                vendorOrders.Add(vendorOrderHeader);                
            }
            context.VendorOrderHeaders.AddRange(vendorOrders);
            context.SaveChanges();
        }
    }
}
