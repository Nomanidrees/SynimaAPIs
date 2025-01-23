using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SYN.Application.Commands;
using SYN.Application.Queries;
using SYN.Domain.Entities;

namespace Synima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ISender sender) : ControllerBase
    {
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerEntity customerEntity)
        {
            var result = await sender.Send(new AddCustomerCommand(customerEntity));
            return Ok(result);
        }
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var result = await sender.Send(new GetCustomerQuery());
            return Ok(result);
        }
        //[HttpGet("{customerId}")]
        //public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] long customerId)
        //{
        //    var result = await sender.Send(new GetCustomerByIdQuery(customerId));
        //    return Ok(result);
        //}

    }
}
