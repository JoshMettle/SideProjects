using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class SourFlavoredCandies : Candy
    {
        // Constructor
        public SourFlavoredCandies(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Sour Flavored Candies";
        }
    }
}
