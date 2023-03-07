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
    }
}
