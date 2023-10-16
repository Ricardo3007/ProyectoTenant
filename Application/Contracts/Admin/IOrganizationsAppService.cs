using multitenant.Application.DTO.Admin;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Contracts.Admin
{
    public interface IOrganizationsAppService
    {
        RequestResult<List<OrganizationsDTO>> GetOrganization();

        OrganizationsDTO? GetOrganizationbytenant(String slugTenant);
    }
}
