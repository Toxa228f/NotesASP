using Microsoft.IdentityModel.Tokens;
using Notes.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Notes.JWT
{
    public class GenerateToken
    {
        private readonly IConfiguration config;

        public GenerateToken(IConfiguration config) => this.config = config;

        public string GenerateNewToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("login", user.Login)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
