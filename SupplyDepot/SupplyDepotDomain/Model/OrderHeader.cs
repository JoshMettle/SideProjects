using System;
using System.Collections.Generic;

namespace SupplyDepotDomain.Model;

public partial class OrderHeader
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<VendorOrderHeader> VendorOrderHeaders { get; } = new List<VendorOrderHeader>();
}
