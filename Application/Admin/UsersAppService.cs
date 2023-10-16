using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.Contracts.Generics;
using multitenant.Application.DTO.Admin;
using multitenant.Domain.Contracts.Admin;
using multitenant.Domain.Entities.MultAdmin;
using multitenant.Domain.Entities.MultInventario;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Admin
{
    public class UsersAppService: IUsersAppService
    {
        private readonly IUsersDomainService _UsersDomainService;
        private readonly IJwtAppService _JwtAppService;
        private readonly IMapper _Mapper;
        public UsersAppService(IUsersDomainService UsersDomainService, IMapper Mapper, IJwtAppService JwtAppService)        
        {
            _UsersDomainService = UsersDomainService;
            _Mapper = Mapper;
            _JwtAppService = JwtAppService;
        }

        #region Method
      
        public RequestResult<string> LoginToken(UsersDTO usersDTO)
        {

            if (usersDTO.EmailDTO.IsNullOrEmpty())
            {
                return RequestResult<string>.CreateUnsuccessful(new string[] { "El Email no puede esta vacio." });
            }

            if (usersDTO.PasswordDTO.IsNullOrEmpty())
            {
                return RequestResult<string>.CreateUnsuccessful(new string[] { "El password no puede esta vacio." });
            }

            try
            {

                Users? resultUsers = _UsersDomainService.LoginToken(usersDTO);
                if (resultUsers == null)
                {
                    return RequestResult<string>.CreateUnsuccessful(new string[] { "Credenciales invalidas" });
                }

                var token = _JwtAppService.GenerateToken(resultUsers.Email, "prueba");

                return RequestResult<string>.CreateSuccessful(token);
            }
            catch (Exception ex)
            {
                return RequestResult<string>.CreateError(ex.Message.ToString());
            }
        }



        public RequestResult<string> SaveUsuario(UsersDTO usersDTO)
        {
            try
            {
                Users usersMap = _Mapper.Map<UsersDTO, Users>(usersDTO);

                Users resultData = _UsersDomainService.SaveUsuario(usersMap);
                if (resultData == null) return RequestResult<string>.CreateUnsuccessful(new string[] { "Error al Guardar Registro" });
                return RequestResult<string>.CreateSuccessful(resultData.Id.ToString());
            }
            catch (Exception ex)
            {
                return RequestResult<string>.CreateError(ex.Message.ToString());
            }
        }


        #endregion Method
    }
}
