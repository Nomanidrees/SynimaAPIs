using MediatR;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Commands
{
    public record UpdateEmployeeCommand(long EmployeeId, EmployeeEntity Employee)
        : IRequest<EmployeeEntity>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepositories employeeRepositories)
        : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepositories.UpdateEmployeeAsync(request.EmployeeId, request.Employee);
        }
    }
}
