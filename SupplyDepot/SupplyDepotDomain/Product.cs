using System;
using System.Collections.Generic;

namespace SupplyDepotDomain;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int CaseQty { get; set; }

    public decimal PricePerCase { get; set; }

    public int VendorId { get; set; }

    public string VendorProductNumber { get; set; } = null!;

    public int? MinimumQty { get; set; }

    public int? MaximumQty { get; set; }

    public int? ProductType { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ProductCategory? ProductTypeNavigation { get; set; }

    public virtual Vendor Vendor { get; set; } = null!;
}
