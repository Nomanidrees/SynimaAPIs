using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using MediatR;

using SYN.Application.DTOs;
using SYN.Domain.Entities;
using SYN.Domain.Interfaces;

namespace SYN.Application.Queries
{
    public record GetFormElementByIdQuery(int FormId) : IRequest<List<FormElementDto>>;

    public class GetFormElementByIdQueryHandler : IRequestHandler<GetFormElementByIdQuery, List<FormElementDto>>
    {
        private readonly IFormElementRepository _formRepository;

        public GetFormElementByIdQueryHandler(IFormElementRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<List<FormElementDto>> Handle(GetFormElementByIdQuery request, CancellationToken cancellationToken)
        {
            var element = await _formRepository.GetFormElementByIdAsync(request.FormId);
            if (element == null)
                throw new KeyNotFoundException("Form element not found");

            // Map each FormElement to FormElementDto
            return element.Select(element => new FormElementDto
            {
                ElementId = element.ElementId,
                FormId = element.FormId,
                Label = element.Label,
                FieldName = element.FieldName,
                FieldType = element.FieldType,
                IsRequired = element.IsRequired,
                Placeholder = element.Placeholder,
                DefaultValue = element.DefaultValue,
                Options = element.Options
            }).ToList();
        }
    }
}
