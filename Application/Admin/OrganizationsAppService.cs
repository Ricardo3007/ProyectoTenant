using AutoMapper;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.DTO.Admin;
using multitenant.Domain.Contracts.Admin;
using multitenant.Domain.Entities.MultAdmin;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Admin
{
    public class OrganizationsAppService: IOrganizationsAppService
    {
        private readonly IOrganizationsDomainService _OrganizationsDomainService;
        private readonly IMapper _Mapper;
        public OrganizationsAppService(IOrganizationsDomainService OrganizationsDomainService, IMapper Mapper)
        {
            _OrganizationsDomainService = OrganizationsDomainService;
            _Mapper = Mapper;   
        }

        #region Method
        public RequestResult<List<OrganizationsDTO>> GetOrganization()
        {
            try
            {          
                var result = _OrganizationsDomainService.GetOrganization();
                List<OrganizationsDTO> resultMap = _Mapper.Map<List<Organizations>, List<OrganizationsDTO>>(result);

                return RequestResult<List<OrganizationsDTO>>.CreateSuccessful(resultMap);
            }
            catch (Exception ex)
            {
                return RequestResult<List<OrganizationsDTO>>.CreateError(ex.Message.ToString());
            }

        }


        public OrganizationsDTO? GetOrganizationbytenant(String slugTenant)
        {
            try
            {
                var result = _OrganizationsDomainService.GetOrganizationbytenant(slugTenant);
                OrganizationsDTO resultMap = _Mapper.Map<Organizations, OrganizationsDTO>(result);

                return resultMap;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion Method
    }
}
