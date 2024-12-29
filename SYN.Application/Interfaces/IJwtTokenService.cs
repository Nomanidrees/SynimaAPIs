using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;

namespace SYN.Application.Interfaces
{
    public interface IJwtTokenService
    {
        (string Token, DateTime Expiry) GenerateToken(string userEntity, string role);
    }
}
