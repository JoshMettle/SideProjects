using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class HardTackConfectionery : Candy
    {
        // Constructor
        public HardTackConfectionery(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Hard Tack Confectionery";
        }
    }
}
