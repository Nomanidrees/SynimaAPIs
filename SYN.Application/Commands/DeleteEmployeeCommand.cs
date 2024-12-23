using MediatR;
using SYN.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Application.Commands
{
    public record DeleteEmployeeCommand(long EmployeeId)
        : IRequest<bool>;
    internal class DeleteEmployeeCommandHandler(IEmployeeRepositories employeeRepositories)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepositories.DeleteEmployeeAsync(request.EmployeeId);
        }
    }
}
