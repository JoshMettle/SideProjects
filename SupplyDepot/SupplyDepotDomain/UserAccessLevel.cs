using System;
using System.Collections.Generic;

namespace SupplyDepotDomain;

public partial class UserAccessLevel
{
    public int AccessLevelId { get; set; }

    public string AccessLevelName { get; set; } = null!;

    public decimal? MaxPurchaseAmount { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
