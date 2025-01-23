using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SYN.Domain.Entities;
using SYN.Domain.Interfaces;
using SYN.Infrastructure.Data;

namespace SYN.Infrastructure.Repositories
{
    public class CustomerRepository(SynDBContext dbContext) : ICustomerRepository
    {
        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            return await dbContext.Customer.ToListAsync();
        }

        public async Task<CustomerEntity> GetCustomerByIdAsync(long id)
        {
            return await dbContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<CustomerEntity> AddCustomerAsync(CustomerEntity customerEntity)
        {
            dbContext.Customer.Add(customerEntity);
            await dbContext.SaveChangesAsync();
            return customerEntity;
        }
 
        public async Task<CustomerEntity> UpdateCustomerAsync(long customerid, CustomerEntity customerEntity)
        {
            var customer = await dbContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerid);
            //if (customer is not null)
            //{
            //    employee.Name = employeeEntity.Name;
            //    employee.Email = employeeEntity.Email;
            //    employee.Phone = employeeEntity.Phone;

            //    await dbContext.SaveChangesAsync();
            //    return employeeEntity;
            //}
            return customerEntity;
        }

        public async Task<bool> DeleteCustomerAsync(long customerid)
        {
            var customer = await dbContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerid);
            //if (employee is not null)
            //{
            //    dbContext.Remove(employee);
            //    return await dbContext.SaveChangesAsync() > 0;
            //}
            return false;
        }
    }
}
