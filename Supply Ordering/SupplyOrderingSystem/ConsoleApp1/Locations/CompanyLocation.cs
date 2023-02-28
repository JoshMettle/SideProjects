using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm.Locations
{
    public abstract class CompanyLocation : Location
    {
        public string LocationName { get; private set; }
        public string LocationId { get; private set; }

        public CompanyLocation(string locationName, string locationId, string streetAddress, string city, string state, string zip) : base(streetAddress, city, state, zip)
        {
            LocationName = locationName;
            LocationId = locationId;
        }
    }
}
