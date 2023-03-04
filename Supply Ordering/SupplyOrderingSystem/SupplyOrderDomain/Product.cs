using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain
{
    public class Product
    {
        [Range(1,int.MaxValue)]
        public int? ProductId { get; private set; }
        [Required]
        public string ProductName { get; private set; }
        [Required]
        public string ProductDescription { get; private set; }
        [Required]
        public int CaseQty { get; private set; }
        [Required]
        public decimal PricePerCase { get; private set; }
        [Required]
        public int VendorId { get; private set; }
        public Vendor vendor { get; private set; }
        [Required]
        public string VendorItemNum { get; private set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int MinQty { get; private set; }

        public int MaxQty { get; private set; }

        public Product(int? productId, string productName, string productDescription, int caseQty, decimal pricePerCase, int vendorId, string vendorItemNum, int minQty, int maxQty)
        {
            ProductId = productId;
            this.ProductName = productName;
            ProductDescription = productDescription;
            CaseQty = caseQty;
            PricePerCase = pricePerCase;
            VendorId = vendorId;
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
