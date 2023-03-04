using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class ChocolateConfectionery : Candy
    {
        // Constructor
        public ChocolateConfectionery(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Chocolate Confectionery";
        }
    }
}
