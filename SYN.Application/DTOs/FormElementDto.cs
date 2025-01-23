using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Application.DTOs
{
    public class FormElementDto
    {
        public int ElementId { get; set; }
        public int FormId { get; set; }
        public string? Label { get; set; } = null!;
        public string? FieldName { get; set; } = null!;
        public string? FieldType { get; set; } = null!; 
        public bool IsRequired { get; set; }
        public string? Placeholder { get; set; } = null!;
        public string? DefaultValue { get; set; } = null!;
        public string? Options { get; set; } = null!;
    }
}
