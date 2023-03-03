using Microsoft.IdentityModel.Tokens;
using PaymentLogInterfce.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentLogInterfce.API.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(Owner owner)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, owner.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, owner.LastName));
            claims.Add(new Claim(ClaimTypes.Email, owner.Email));

            //owner.Roles.ForEach(role =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Name));
            //});

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Token:Expires"])),
                signingCredentials: credentials);


            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }


    }
}
