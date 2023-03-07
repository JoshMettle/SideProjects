using SupplyDepotDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepotDomain.DAO
{
    public class ProductCategoryDAO
    {
        public List<ProductCategory> GetAllProductCategories()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<ProductCategory> productCategories = context.ProductCategories.ToList();
            return productCategories;
        }

        public ProductCategory AddProductCategory(string categoryName)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            ProductCategory productCategory = new ProductCategory { CategoryName = categoryName};
            context.ProductCategories.Add(productCategory);
            context.SaveChanges();
            return productCategory;
        }
    }
}
