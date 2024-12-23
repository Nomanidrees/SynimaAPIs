using SYN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Interfaces
{
    public interface IEmployeeRepositories
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeesByIdAsync(long id);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employeeEntity);
        Task<EmployeeEntity> UpdateEmployeeAsync(long employeeId, EmployeeEntity employeeEntity);
        Task<bool> DeleteEmployeeAsync(long employeeid);
    }
}
