using SupplyOrderDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderConsole
{
    public class Cart
    {
        private Dictionary<Product, int> cart = new Dictionary<Product, int>();

        /// <summary>
        /// verify a specific product 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productManagement"></param>
        /// <returns></returns>
        public string ValidateProductSelection(string id, ProductManagement productManagement)
        {
            if (!int.TryParse(id, out int productId))
            {
                return "invalid product Id please try again";
            }

            Product? product = productManagement.FindProduct(productId);
            if (product == null)
            {
                return "invalid product id please try again";
            }
            else
            {
                return "Please enter the quantity to be added or press enter to cancel";
            }


        }

        public string AddQuantityToCart(string strQty, string productId, ProductManagement productManagement)
        {
            if (!int.TryParse(strQty, out int Qty))
            {
                return "Invalid Quantity please reselect product.  Please reenter order quantity.";
            }

            Product product = productManagement.FindProduct(int.Parse(productId));

            int existingQty = 0;

            if (cart.ContainsKey(product))
            {
                existingQty = cart[product];
            }

            if (Qty < product.MinQty)
            {
                return "Quantity selected is less than the minimum required order.  Please reenter order quantity.";
            }
            else if (Qty > product.MaxQty)
            {
                return "Quantity selected is greater than the maximum order amount.  Please reenter order quantity.";
            }
            else if (Qty + existingQty > product.MaxQty)
            {
                return "Quantity selected will increase total amount order over the maximum order amount.  Please reenter order quantity.";
            }
            else
            {
                if (existingQty != 0)
                {
                    cart[product] += Qty;
                }
                else
                {
                    cart[product] = Qty;
                }

                return $"{Qty} {product.ProductName} have been added to your cart";
            }
        }
    }
}
