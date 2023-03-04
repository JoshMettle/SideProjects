using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain.Locations
{
    public class WarehouseLocation : CompanyLocation
    {
        public WarehouseLocation(int? id, string name, string companyId, string address1, string address2, string city, string state, string zip) : base(id, name, companyId, address1, address2, city, state, zip)
        {
        }
    }
}
