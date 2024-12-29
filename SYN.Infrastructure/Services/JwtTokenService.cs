using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using SYN.Application.Interfaces;
using SYN.Domain.Entities;
using SYN.Domain.Options;

namespace SYN.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenService(IOptions<JwtOptions> jwtOptions)
        {
                //Retrieve the bound JwtOptions from DI
               _jwtOptions = jwtOptions.Value;
        }

        public (string Token, DateTime Expiry) GenerateToken(string username, string role)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);

            var expiry = DateTime.UtcNow.AddHours(1); // Set token expiry
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = expiry,
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
            return (tokenHandler.WriteToken(token), expiry); // Return both token and expiry
        }

    }
}
