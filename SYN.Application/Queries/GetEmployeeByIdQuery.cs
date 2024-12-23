using MediatR;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Queries
{

    public record GetEmployeeByIdQuery(long employeeId) : IRequest<EmployeeEntity>;
    public class GetEmployeeByIdQueryHandler(IEmployeeRepositories employeeRepositories)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepositories.GetEmployeesByIdAsync(request.employeeId);
        }
    }
}
