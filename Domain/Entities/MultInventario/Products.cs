using System;
using System.Collections.Generic;

namespace multitenant.Domain.Entities.MultInventario;

public partial class Products
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public bool? Estado { get; set; }

    public Guid? OrganizationId { get; set; }
}
