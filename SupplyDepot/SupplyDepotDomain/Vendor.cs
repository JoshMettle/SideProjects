using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace SupplyDepotDomain;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDirectShip { get; set; }

    public bool IsConsolidatedBilling { get; set; }

    public int? AccountContactId { get; set; }

    public int? RemitTo { get; set; }

    public virtual Person? AccountContact { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual Location? RemitToNavigation { get; set; }

    public virtual ICollection<VendorOrderHeader> VendorOrderHeaders { get; } = new List<VendorOrderHeader>();

    public override string ToString()
    {
        string contact = "";
        if (AccountContact != null)
        {
            contact = AccountContact.ToString();
        }
            return $"{Name} Account Contact: {contact}";
    }
}
