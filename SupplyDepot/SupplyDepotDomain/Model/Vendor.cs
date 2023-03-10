using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplyDepotDomain.Model;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDirectShip { get; set; }

    public bool IsConsolidatedBilling { get; set; }

    public virtual int? AccountContactId { get; set; }

    public int? RemitToId { get; set; }

    [DefaultValue("false")]
    public bool? IsInactive { get; set; }
    public virtual Person? AccountContact { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual Location? RemitToLocation { get; set; }

    public virtual ICollection<VendorOrderHeader> VendorOrderHeaders { get; } = new List<VendorOrderHeader>();

    //Constructors
    public Vendor()
    {
    }

    public Vendor(string name, bool isDirectShip, bool isConsolidatedBilling)
    {
        Name = name;
        IsDirectShip = isDirectShip;
        IsConsolidatedBilling = isConsolidatedBilling;
    }

    public override string ToString()
    {
        if(AccountContact == null)
        {
            return Name+": No Account Contact on File";
        }
        else
        {
            return $"{Name}: Account Contact: {AccountContact.FirstName} {AccountContact.LastName} {AccountContact.Email}"; 
        }
    }
}
