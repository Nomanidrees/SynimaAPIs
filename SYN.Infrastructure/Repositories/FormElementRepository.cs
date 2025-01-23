using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.EntityFrameworkCore;

using SYN.Domain.Entities;
using SYN.Domain.Interfaces;
using SYN.Infrastructure.Data;

namespace SYN.Infrastructure.Repositories
{
    public class FormElementRepository(SynDBContext dbContext) : IFormElementRepository
    {
        public async Task<List<FormElement>> GetFormElementByIdAsync(int formId)
        {
            return await dbContext.Set<FormElement>()
                .Where(fe => fe.FormId == formId)
                .OrderBy(fe => fe.SequenceId)
                .Select(fe => new FormElement
                {
                    ElementId = fe.ElementId,
                    Label = fe.Label,
                    FieldName = fe.FieldName,
                    FieldType = fe.FieldType,
                    IsRequired = fe.IsRequired,
                    Placeholder = fe.Placeholder ?? string.Empty, // Provide default for nullable fields
                    DefaultValue = fe.DefaultValue ?? string.Empty,
                    Options = fe.Options ?? string.Empty,
                    FormId = fe.FormId
                }).ToListAsync();
        }
    }
}
