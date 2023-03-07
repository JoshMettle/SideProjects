using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SupplyDepotDomain.Model;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    [DefaultValue("false")]
    public bool? IsInactive { get; set; }
    public virtual ICollection<VendorOrderHeader> VendorOrderHeaders { get; } = new List<VendorOrderHeader>();

    public virtual ICollection<Vendor> Vendors { get; } = new List<Vendor>();
}
