
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.DTO.Admin;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.WebApi.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly IUsersAppService _UsersAppService;
        #endregion Fields

        #region Const
        #endregion Const

        #region builder
        public UsersController(IUsersAppService UsersAppService)
        {
            _UsersAppService = UsersAppService;
        }
        #endregion builder

        #region Method

        /// <summary>
        /// Generar token segun datos de usuario
        /// </summary>
        /// <param name="UsersDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsersController.LoginToken))]
        public RequestResult<string> LoginToken(UsersDTO usersDTO)
        {
            return _UsersAppService.LoginToken(usersDTO);

        }

        /// <summary>
        /// Crear usuarios
        /// </summary>
        /// <param name="usersDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(UsersController.SaveUsuario))]
        public RequestResult<string> SaveUsuario(UsersDTO usersDTO)
        {
            return _UsersAppService.SaveUsuario(usersDTO);

        }


        #endregion Method

    }
}
