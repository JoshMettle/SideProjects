using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SupplyDepotDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepotDomain.DAO
{
    public class ProductDAO
    {
        public List<Product> GetAllProducts()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Product> products = context.Products.ToList();
            return products;
        }

        public List<Product> GetAllProductsInCategory(ProductCategory category)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Product> products = context.Products.Where(p => p.ProductType == category.CategoryId).ToList();
            return products;
        }

        public Product? GetProductByProductId(int id)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Product? product = context.Products.Find(id);
            return product;
        }

        /// <summary>
        /// Updates Product record to flag them as inactive
        /// </summary>
        /// <param name="id"> Target Product Id</param>
        /// <returns>True if Product record set to Inactive</returns>
        public bool DeactivateProduct(int id)
        {
            bool isInactive = false;
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Product? product = context.Products.Find(id);
            if(product != null)
            {
                product.IsInactive = true;
                context.SaveChanges();
                isInactive = true;
            }

            return isInactive;
        }
    }
}
