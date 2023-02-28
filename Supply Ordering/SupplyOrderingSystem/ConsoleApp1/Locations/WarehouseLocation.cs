using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm.Locations
{
    public class WarehouseLocation : CompanyLocation
    {
        public WarehouseLocation(string name, string id, string streetAddress, string city, string state, string zip) : base(name, id, streetAddress, city, state, zip)
        {
        }
    }
}
