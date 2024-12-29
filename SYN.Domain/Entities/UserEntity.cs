using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
    }
}
