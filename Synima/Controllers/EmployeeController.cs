using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYN.Application.Commands;
using SYN.Application.Queries;
using SYN.Domain.Entities;

namespace Synima.Controllers
{
    //api/Employee this is base same for all
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeEntity employeeEntity)
        {
            var result = await sender.Send(new AddEmployeeCommand(employeeEntity));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeeQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeesByIdAsync([FromRoute] long employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }


        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] long employeeId, [FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employeeId, employee));
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] long employeeId)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }
}
