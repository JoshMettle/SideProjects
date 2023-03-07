using System;
using System.Collections.Generic;

namespace SupplyDepotDomain.Model;

public partial class VendorOrderDetail
{
    public int VendorOrderDetailId { get; set; }

    public int VendorOrderId { get; set; }

    public int OrderId { get; set; }

    public int OrderLineItem { get; set; }

    public string VendorItemNumber { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public virtual VendorOrderHeader VendorOrder { get; set; } = null!;
}
