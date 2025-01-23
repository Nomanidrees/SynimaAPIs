using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SYN.Application.Queries;

namespace Synima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormElementsController(ISender sender) : ControllerBase
    {
        [HttpGet("{formId}")]
        public async Task<IActionResult> GetFormElementsByFormId(int formId)
        {
            var formElement = await sender.Send(new GetFormElementByIdQuery(formId));
            if (formElement == null) return NotFound();
            return Ok(formElement);
        }

        //[HttpGet("forms/{formId}/elements")]
        //public async Task<IActionResult> GetFormElementsByFormId(int formId)
        //{
        //    var query = new GetFormElementsByFormIdQuery(formId);
        //    var formElements = await _mediator.Send(query);
        //    return Ok(formElements);
        //}
    }
}
