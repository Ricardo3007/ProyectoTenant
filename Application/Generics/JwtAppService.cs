using Microsoft.IdentityModel.Tokens;
using multitenant.Application.Contracts.Generics;
using multitenant.Domain.Entities.MultAdmin;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace multitenant.Application.Generics
{
    public class JwtAppService:IJwtAppService
    {
        private readonly IConfiguration _configuration;

        public JwtAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username, string tenantId)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("(4j0Id?6~9:jq40`Hb2U"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:4200",
                audience: "https://localhost:4200", 
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), 
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        

        //var key = Encoding.UTF8.GetBytes("(4j0Id?6~9:jq40`Hb2U");
        //var tokenHandler = new JwtSecurityTokenHandler();
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new[]
        //    {
        //    new Claim(ClaimTypes.NameIdentifier, username),
        //    new Claim(ClaimTypes.Email, "ricardo@gmail.com"),
        //    new Claim(ClaimTypes.GivenName, username),
        //    new Claim("tenant", tenantId)
        //}),
        //    Expires = DateTime.UtcNow.AddHours(1), // Configurar la expiración del token
        //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //};

        //var token = tokenHandler.CreateToken(tokenDescriptor);
        //return tokenHandler.WriteToken(token);

        //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
        //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //var claims = new[]
        //{
        //    new Claim(ClaimTypes.Name, username),
        //    new Claim("tenant", tenantId) 
        //};

        //var token = new JwtSecurityToken
        //    (
        //    _configuration["Jwt:Issuer"],
        //    _configuration["Jwt:Issuer"],
        //    claims,
        //    expires: DateTime.Now.AddMinutes(15),
        //    signingCredentials: credentials
        //    );

        //return new JwtSecurityTokenHandler().WriteToken(token);

    }
    }
}
