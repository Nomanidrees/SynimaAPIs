using Microsoft.EntityFrameworkCore;
using SYN.Domain.Entities;


namespace SYN.Infrastructure.Data
{
     public class SynDBContext(DbContextOptions<SynDBContext> options) : DbContext(options)
    //public class SynDBContext : DbContext
    {
        //public SynDBContext(DbContextOptions<SynDBContext> options) : base(options) { }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<UserEntity> User { get; set; }
    }
}
     
