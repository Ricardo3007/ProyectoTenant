using multitenant.Application.DTO.Admin;
using multitenant.Domain.Entities.MultAdmin;

namespace multitenant.Domain.Contracts.Admin
{
    public interface IUsersDomainService
    {
        Users? LoginToken(UsersDTO usersDTO);

        Users SaveUsuario(Users users);
    }
}
