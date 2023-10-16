using System;
using System.Collections.Generic;

namespace multitenant.Domain.Entities.MultAdmin;

public partial class Organizations
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? slugtenant { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
