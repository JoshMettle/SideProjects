using System;
using System.Collections.Generic;

namespace SupplyDepotDomain;

public partial class ProductCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
