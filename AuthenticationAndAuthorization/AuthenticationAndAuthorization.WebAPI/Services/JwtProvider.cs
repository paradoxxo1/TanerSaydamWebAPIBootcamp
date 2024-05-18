using AuthenticationAndAuthorization.WebAPI.Models;
using AuthenticationAndAuthorization.WebAPI.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorization.WebAPI.Services
{
    public sealed class JwtProvider(IConfiguration configuration, IOptionsMonitor<Jwt> jwt)
    {
        public string CreateToken(User user, List<string> roles)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Fullname",string.Join(" ", user.FirstName + user.LastName)),
                new Claim(ClaimTypes.Role, roles[0])


            };

            string securitykeyValue = jwt.CurrentValue.SecretKey;
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykeyValue));

            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwt.CurrentValue.Issuer, //configuration.GetSection("JWT:Issuer").Value,
                audience: jwt.CurrentValue.Audience, //configuration.GetSection("JWT:Audience").Value,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha512));

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
