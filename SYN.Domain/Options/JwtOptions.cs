using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Options
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt"; // Section name in appsettings.json
        public string Key { get; set; } = null!; // The secret key for signing tokens
        public string Issuer { get; set; } = null!; // The issuer of the tokens
        public string Audience { get; set; } = null!; // The audience for the tokens
        public int AccessTokenExpiration { get; set; }
    }
}
