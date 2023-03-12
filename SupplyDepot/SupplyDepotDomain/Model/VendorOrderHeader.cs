using System;
using System.Collections.Generic;

namespace SupplyDepotDomain.Model;

public partial class VendorOrderHeader
{
    public int VendorOrderId { get; set; }

    public int VendorId { get; set; }

    public int OrderId { get; set; }

    public int ShipToId { get; set; }

    public DateTime? VendorOrderDate { get; set; }

    public decimal Amount { get; set; }

    public virtual OrderHeader Order { get; set; } = null!;

    public virtual Location ShipTo { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;

    public virtual ICollection<VendorOrderDetail> VendorOrderDetails { get; } = new List<VendorOrderDetail>();

    public VendorOrderHeader()
    {
        VendorOrderDetails = new List<VendorOrderDetail>();
    }
}
