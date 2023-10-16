using multitenant.Domain.Contracts.Admin;
using multitenant.Domain.Entities.MultAdmin;
using multitenant.Infrastructure.DataAccess.MultAdminContext;

namespace multitenant.Infrastructure.Admin
{
    public class OrganizationsDomainService: IOrganizationsDomainService
    {
        private readonly MultAdminContext _MultAdminContext;
        public OrganizationsDomainService(MultAdminContext MultAdminContext)
        {
            _MultAdminContext = MultAdminContext;
        }

        public List<Organizations> GetOrganization()
        {
           return _MultAdminContext.Organizations.ToList();
        }

        public Organizations? GetOrganizationbytenant(string slugTenant)
        {
            return _MultAdminContext.Organizations.Where(x => x.slugtenant.Equals(slugTenant)).FirstOrDefault();
        }

    }
}
