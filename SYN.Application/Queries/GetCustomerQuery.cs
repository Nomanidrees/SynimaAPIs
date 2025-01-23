using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Queries
{
    public record GetCustomerQuery : IRequest<IEnumerable<CustomerEntity>>;
    public class GetCustomerQueryHandler(ICustomerRepository customerRepositories) :
         IRequestHandler<GetCustomerQuery, IEnumerable<CustomerEntity>>
    {
        public async Task<IEnumerable<CustomerEntity>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await customerRepositories.GetCustomers();
        }

    }
}
