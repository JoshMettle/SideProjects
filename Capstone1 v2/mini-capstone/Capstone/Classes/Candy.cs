using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Candy
    {
        // properties
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Wrapped { get; private set; }
        public string FullClassName { get; protected set; }
        public int Quantity { get; private set; }

        // constructor 

        public Candy(string id, string name, decimal price, string wrapped)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = 100;
            if (wrapped == "T")
            {
                Wrapped = "Y";
            }
            else
            {
                Wrapped = "N";
            }
        }

        public Candy(string id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Wrapped = "Y";
        }

        // methods
        public void RemoveInventory(int qtyToRemove)
        {
            Quantity -= qtyToRemove;
        }

        public override string ToString()
        {
            string qty;
            if(Quantity == 0)
            {
                qty = "SOLD OUT";
            }
            else
            {
                qty = Quantity.ToString();
            }

            return Id.PadRight(5)+Name.PadRight(20)+Wrapped.PadRight(8)+qty.PadRight(9)+Price.ToString("C");
        }

    }
}
