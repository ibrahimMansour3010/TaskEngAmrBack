using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskEngAmr.Services.Abstraction;
using TaskEngAmr.Settings;

namespace TaskEngAmr.Services
{
    public class BasicService: IBasicService
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly JWT JWT;
        public BasicService(UserManager<IdentityUser> userManager,IOptions<JWT> jwt)
        {
            UserManager = userManager;
            JWT = jwt.Value;
        }
        public async Task<string> GenerateToken(IdentityUser user)
        {
            var userClaims = await UserManager.GetClaimsAsync(user);
            var roles = await UserManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("userid", user.Id)
            }.Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Key));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                    issuer: JWT.Issuer,
                    audience: JWT.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(14),
                    signingCredentials: signInCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

    }
}
