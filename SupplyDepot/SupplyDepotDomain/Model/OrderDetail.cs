using System;
using System.Collections.Generic;

namespace SupplyDepotDomain.Model;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public virtual OrderHeader Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
