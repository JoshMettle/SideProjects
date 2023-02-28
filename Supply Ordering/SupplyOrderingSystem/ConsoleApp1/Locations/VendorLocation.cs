using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm.Locations
{
    public class VendorLocation : Location
    {
        public Vendor Vendor { get; private set; }

        public VendorLocation(string streetAddress, string city, string state, string zip, Vendor vendor) : base(streetAddress, city, state, zip)
        {
            Vendor = vendor;
        }
    }
}
