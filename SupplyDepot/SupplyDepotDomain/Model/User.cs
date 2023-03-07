using System;
using System.Collections.Generic;

namespace SupplyDepotDomain.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int PersonId { get; set; }

    public int AccessLevel { get; set; }

    public virtual UserAccessLevel AccessLevelNavigation { get; set; } = null!;

    public virtual ICollection<OrderHeader> OrderHeaders { get; } = new List<OrderHeader>();

    public virtual Person Person { get; set; } = null!;
}
