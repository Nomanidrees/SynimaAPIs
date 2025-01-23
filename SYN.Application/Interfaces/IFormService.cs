using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SYN.Application.DTOs;

namespace SYN.Application.Interfaces
{
    public interface IFormService
    {
        Task<List<FormElementDto>> GetFormElementByIdAsync(int FormId);
        //Task<IEnumerable<FormElementDto>> GetFormElementsByFormIdAsync(int formId);

        //Task<int> CreateFormElementAsync(CreateFormElementRequestDto request);
        //Task UpdateFormElementAsync(UpdateFormElementRequestDto request);
        //Task DeleteFormElementAsync(int id);
        //Task<IEnumerable<FormElementDto>> GetFormElementsByFormNameAsync(string formName);
    }
}
