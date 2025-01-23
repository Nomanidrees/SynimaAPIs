using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Entities
{

    public class Form
    {
        [Key]
        public int FormId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public ICollection<FormElement> Elements { get; set; } = null!;
    }

    public class FormElement
    {
        [Key]
        public int ElementId { get; set; }
        public int FormId { get; set; }
        public string? Label { get; set; } = null!;
        public string? FieldName { get; set; } = null!;
        public string? FieldType { get; set; } = null!; 
        public bool IsRequired { get; set; }
        public string? ValidationRules { get; set; } = null!;
        public string? Options { get; set; } = null!;
        public string? Placeholder { get; set; } = null!;
        public string? DefaultValue { get; set; } = null!;
        public int SequenceId { get; set; }
        public bool IsVisible { get; set; }
    }
}
