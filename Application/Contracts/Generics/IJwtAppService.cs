
namespace multitenant.Application.Contracts.Generics
{
    public interface IJwtAppService
    {

        /// <summary>
        /// Generar token 
        /// </summary>
        /// <returns></returns>
        string GenerateToken(string username, string tenantId);

    }
}
