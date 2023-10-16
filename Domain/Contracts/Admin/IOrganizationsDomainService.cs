
using multitenant.Domain.Entities.MultAdmin;

namespace multitenant.Domain.Contracts.Admin
{
    public interface IOrganizationsDomainService
    {
        List<Organizations> GetOrganization();

        Organizations? GetOrganizationbytenant(string slugTenant);

    }
}
