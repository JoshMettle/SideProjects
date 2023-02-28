using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderForm
{
    public class Vendor
    {
        public string VendorName { get; private set; }
        public int VendorId { get; private set; }
        public int AccountContactId { get; private set; }
        public bool IsDirectShip { get; private set; }
        public bool IsConsolidatedBilling { get; private set; }

        public Vendor (string name, int id, bool directShip, bool consolidatedBilling)
        {
            VendorName = name;
            VendorId = id;
            IsDirectShip = directShip;
            IsConsolidatedBilling = consolidatedBilling;
        }

        public Vendor(string name, int id, int contactId, bool warehouse, bool nationalAccount)
        {
            VendorName = name;
            VendorId = id;
            AccountContactId = contactId;
            IsDirectShip = warehouse;
            IsConsolidatedBilling = nationalAccount;
        }
    }
}
