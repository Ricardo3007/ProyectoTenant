using Microsoft.AspNetCore.Mvc;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.DTO.Admin;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.WebApi.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        #region Fields
        private readonly IOrganizationsAppService _OrganizationsAppService;
        #endregion Fields

        #region Const
        #endregion Const

        #region builder
        public OrganizationsController(IOrganizationsAppService OrganizationsAppService)
        {
            _OrganizationsAppService = OrganizationsAppService;
        }
        #endregion builder

        #region Method
        /// <summary>
        /// Consultar organizacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(OrganizationsController.GetOrganization))]
        public RequestResult<List<OrganizationsDTO>> GetOrganization()
        {
            return _OrganizationsAppService.GetOrganization();

        }

        /// <summary>
        /// Consultar organizacion por tenant
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(OrganizationsController.GetOrganizationbytenant))]
        public OrganizationsDTO? GetOrganizationbytenant(String slugTenant)
        {
            return _OrganizationsAppService.GetOrganizationbytenant(slugTenant);

        }



        #endregion Method

    }
}
