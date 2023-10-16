using multitenant.Application.DTO.Admin;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Contracts.Admin
{
    public interface IUsersAppService
    {

        RequestResult<string> LoginToken(UsersDTO usersDTO);

        RequestResult<string> SaveUsuario(UsersDTO usersDTO);

    }
}
