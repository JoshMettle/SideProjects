using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain.Locations
{
    public class StoreLocation : CompanyLocation
    {
        public WarehouseLocation DefaultWarehouse { get; private set; }

        public StoreLocation(int? id, string name, string companyId, string address1, string address2, string city, string state, string zip, WarehouseLocation warehouse) : base(id, name, companyId, address1, address2, city, state, zip)
        {
            DefaultWarehouse = warehouse;
        }
    }
}
