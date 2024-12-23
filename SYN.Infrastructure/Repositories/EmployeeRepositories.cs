using Microsoft.EntityFrameworkCore;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;
using SYN.Infrastructure.Data;

namespace SYN.Infrastructure.Repositories
{
    public class EmployeeRepositories(SynDBContext dbContext) : IEmployeeRepositories
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeesByIdAsync(long id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employeeEntity)
        {
            dbContext.Employees.Add(employeeEntity);
            await dbContext.SaveChangesAsync();
            return employeeEntity;
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(long employeeId, EmployeeEntity employeeEntity)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee is not null)
            {
                employee.Name = employeeEntity.Name;
                employee.Email = employeeEntity.Email;
                employee.Phone = employeeEntity.Phone;

                await dbContext.SaveChangesAsync();
                return employeeEntity;
            }
            return employeeEntity;
        }

        public async Task<bool> DeleteEmployeeAsync(long employeeid)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeid);
            if (employee is not null)
            {
                dbContext.Remove(employee);
               return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

    }
}
