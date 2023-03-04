using SupplyOrderDomain.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain
{
    public class Vendor
    {
        [Range(1,int.MaxValue)]
        public int? VendorId { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int AccountContactId { get; private set; }
        public Person AccountContact { get; private set; }
        [Required]
        public bool IsDirectShip { get; private set; }
        [Required]
        public bool IsConsolidatedBilling { get; private set; }
        public int RemitToId { get; private set; }
        public Location RemitTo { get; private set; }

        public Vendor (int? vendorId, string name, bool isDirectShip, bool isConsolidatedBilling, int remitToId)
        {
            Name = name;
            VendorId = vendorId;
            IsDirectShip = isDirectShip;
            IsConsolidatedBilling = isConsolidatedBilling;
            RemitToId = remitToId;
        }
        public Vendor(int? vendorId, string name,  bool isDirectShip, bool isConsolidatedBilling)
        {
            Name = name;
            VendorId = vendorId;
            IsDirectShip = isDirectShip;
            IsConsolidatedBilling = isConsolidatedBilling;
            
        }
        public Vendor(int? vendorId, string name,  int accountContactId, bool isDirectShip, bool isConsolidatedBilling, int remitToId)
        {
            Name = name;
            VendorId = vendorId;
            AccountContactId = accountContactId;
            IsDirectShip = isDirectShip;
            IsConsolidatedBilling = isConsolidatedBilling;
            RemitToId = remitToId;
        }

        public Vendor(int? vendorId, string name,  int accountContactId, bool isDirectShip, bool isConsolidatedBilling)
        {
            Name = name;
            VendorId = vendorId;
            AccountContactId = accountContactId;
            IsDirectShip = isDirectShip;
            IsConsolidatedBilling = isConsolidatedBilling;
        }
    }
}
