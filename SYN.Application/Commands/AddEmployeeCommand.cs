using MediatR;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Commands
{
    public record AddEmployeeCommand(EmployeeEntity Employee): IRequest<EmployeeEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepositories employeeRepositories) :
        IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
          return await employeeRepositories.AddEmployeeAsync(request.Employee);
        }
    }
}
