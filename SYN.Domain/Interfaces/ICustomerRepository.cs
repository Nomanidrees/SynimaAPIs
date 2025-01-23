using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;

namespace SYN.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEntity>> GetCustomers();
        Task<CustomerEntity> GetCustomerByIdAsync(long id);
        Task<CustomerEntity> AddCustomerAsync(CustomerEntity customerEntity);
        Task<CustomerEntity> UpdateCustomerAsync(long customerId, CustomerEntity customerEntity);
        Task<bool> DeleteCustomerAsync(long customerId);
    }
}
