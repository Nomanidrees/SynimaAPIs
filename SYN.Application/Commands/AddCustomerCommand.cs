using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Commands
{
    public record AddCustomerCommand(CustomerEntity customer) : IRequest<CustomerEntity>;

    public class AddCustomerCommandHandler(ICustomerRepository customerRepository) : 
        IRequestHandler<AddCustomerCommand, CustomerEntity>
    {
       // private readonly ICustomerRepository _customerRepository;
      
        public async Task<CustomerEntity> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.AddCustomerAsync(request.customer);
        }
    }
}