using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SYN.Application.Commands;
using SYN.Application.DTOs;
using SYN.Domain.Entities;

namespace Synima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender sender) : ControllerBase
    {
       // private readonly IMediator _mediator;

        //public AuthController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await sender.Send(new AuthenticateUserCommand(request));
            return Ok(result);
        }
    }
}
