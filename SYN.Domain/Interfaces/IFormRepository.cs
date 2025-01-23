using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Domain.Entities;

namespace SYN.Domain.Interfaces
{
    public interface IFormRepository
    {
        Task<Form> GetFormByNameAsync(string formName);
        Task<IEnumerable<FormElement>> GetFormElementsByFormIdAsync(int formId);
    }
}
