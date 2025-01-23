using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using SYN.Application.DTOs;
using SYN.Application.Interfaces;
using SYN.Domain.Interfaces;

namespace SYN.Infrastructure.Services
{
    public class FormService : IFormService
    {
        private readonly IFormElementRepository _repository;

        public FormService(IFormElementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FormElementDto>> GetFormElementByIdAsync(int FormId)
        {
            var elements = await _repository.GetFormElementByIdAsync(FormId);
            return elements.Select(element => new FormElementDto
            {
                ElementId = element.ElementId,
                Label = element.Label,
                FieldName = element.FieldName,
                FieldType = element.FieldType,
                IsRequired = element.IsRequired,
                Placeholder = element.Placeholder,
                DefaultValue = element.DefaultValue
            }).ToList() ;
        }
    }
}
