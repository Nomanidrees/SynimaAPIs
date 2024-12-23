using Microsoft.EntityFrameworkCore;
using SYN.Domain.Entities;


namespace SYN.Infrastructure.Data
{
    public class SynDBContext(DbContextOptions<SynDBContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
     
