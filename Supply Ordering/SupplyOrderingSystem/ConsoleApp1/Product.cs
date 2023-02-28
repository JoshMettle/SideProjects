using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CaseQty { get; private set; }
        public decimal PricePerCase { get; private set; }
        public int VendorId { get; private set; }
        public string VendorItemNum { get; private set; }
        public int MinQty { get; private set; }
        public int MaxQty { get; private set; }

        public Product(int productId, string name, string desc, int caseQty, decimal pricePerCase, int vendorId, string vendorItemNum, int minQty, int maxQty)
        {
            ProductId = productId;
            Name = name;
            Description = desc;
            CaseQty = caseQty;
            PricePerCase = pricePerCase;
            VendorId= vendorId;
            VendorItemNum = vendorItemNum;
            MinQty = minQty;
            MaxQty = maxQty;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
