using System;
using System.Collections.Generic;

namespace multitenant.Domain.Entities.MultAdmin;

public partial class Users
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? Estado { get; set; }

    public Guid? OrganizationId { get; set; }

    public virtual Organizations? Organization { get; set; }
}
