using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain.Locations
{
    public class VendorLocation : Location
    {
        public int VendorId { get; private set; }
        public Vendor Vendor { get; private set; }

        public VendorLocation(int? id,string name, string address1, string address2, string city, string state, string zip, int vendorId, Vendor vendor) : base(id, name, address1, address2, city, state, zip)
        {
            VendorId = vendorId;
            Vendor = vendor;
        }
    }
}
