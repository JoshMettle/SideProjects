using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain
{
    public class ProductManagement
    {
        List<Product> productList = new List<Product>();

        public void AddProduct(int id, string name, string desc, int caseQty, decimal pricePerCase, int vendorId, string vendItemNum, int minQty, int maxQty)
        {
            Product product = new Product(id, name, desc, caseQty, pricePerCase, vendorId, vendItemNum, minQty, maxQty);

            productList.Add(product);
        }

        public string DisplayProducts(VendorManagement vendorManagement)
        {
            StringBuilder sb = new StringBuilder();
            bool foundMatch = false;
            sb.AppendLine("Id   Product Name        Description                             Case Qty   Case Price   Vendor         Min Order   Max Order");

            foreach (Product product in productList)
            {
                Vendor vendor = vendorManagement.GetVendor(product.VendorId);
                sb.AppendLine($"{product.ProductId.ToString().PadRight(5)}{product.ProductName.PadRight(20)}{product.ProductDescription.PadRight(40)}{product.CaseQty.ToString().PadRight(11)}{product.PricePerCase.ToString("C").PadRight(13)}{vendor.Name.PadRight(15)}{product.MinQty.ToString().PadRight(12)}{product.MaxQty.ToString()}");
                foundMatch = true;
            }

            if (foundMatch)
            {
                return sb.ToString();
            }
            else
            {
                return "No Products Found";
            }
        }

        public Product? FindProduct(int productId)
        {
            Product? targetProduct = null;

            foreach (Product product in productList)
            {
                if(product.ProductId == productId)
                {
                    targetProduct = product;
                }
            }

            return targetProduct;
        }

    }
}
