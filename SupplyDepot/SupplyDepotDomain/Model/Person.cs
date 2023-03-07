using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SupplyDepotDomain.Model;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    [DefaultValue("false")]
    public bool? IsInactive { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Vendor> Vendors { get; } = new List<Vendor>();
}
