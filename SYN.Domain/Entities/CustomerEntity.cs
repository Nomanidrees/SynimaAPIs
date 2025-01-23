using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Entities
{
    public class CustomerEntity
    {
        [Key]
        public long CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public long TenantID { get; set; }
        public string? CustomerLogo { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StateName { get; set; }
        public long CustomerTypeId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
