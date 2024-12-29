using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Application.DTOs
{
    public class LoginRequestDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginResponseDto
    {
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime TokenExpiry { get; set; }
        public bool authenticated { get; set; }

        
    }
}
