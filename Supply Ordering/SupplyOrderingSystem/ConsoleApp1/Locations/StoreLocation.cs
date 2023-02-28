using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm.Locations
{
    public class StoreLocation : CompanyLocation
    {
        public WarehouseLocation DefaultWarehouse { get; private set; }

        public StoreLocation(string name, string id, string streetAddress, string city, string state, string zip, WarehouseLocation warehouse) : base(name, id, streetAddress, city, state, zip)
        {
            DefaultWarehouse = warehouse;
        }

    }
}
