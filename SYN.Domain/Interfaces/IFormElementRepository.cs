using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;

namespace SYN.Domain.Interfaces
{
    public interface IFormElementRepository
    {
        Task<List<FormElement>> GetFormElementByIdAsync(int formId);
        //Task<IEnumerable<FormElement>> GetFormElementsByFormIdAsync(int formId);
        //Task AddFormElementAsync(FormElement formElement);
        //Task UpdateFormElementAsync(FormElement formElement);
        //Task DeleteFormElementAsync(int id);
    }
}
