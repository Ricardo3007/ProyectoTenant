
using multitenant.Application.DTO.Admin;
using multitenant.Domain.Contracts.Admin;
using multitenant.Domain.Entities.MultAdmin;
using multitenant.Infrastructure.DataAccess.MultAdminContext;

namespace multitenant.Infrastructure.Admin
{
    public class UsersDomainService: IUsersDomainService
    {
        private readonly MultAdminContext _MultAdminContext;
        public UsersDomainService(MultAdminContext MultAdminContext)
        {
            _MultAdminContext = MultAdminContext;
        }


        public Users? LoginToken(UsersDTO usersDTO)
        {

            var resultUsers = _MultAdminContext.Users.Where(x => x.Email.Equals(usersDTO.EmailDTO) && x.Password.Equals(usersDTO.PasswordDTO)).FirstOrDefault();

            return resultUsers;
        }

        public Users SaveUsuario(Users users)
        {
            users.Id = Guid.NewGuid();
            users.Estado = true;
            _MultAdminContext.Users.Add(users);

            _MultAdminContext.SaveChanges();
            return users;
        }

    }
}
