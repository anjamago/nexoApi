using Nexos.Entities.DTO;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Entities.Interface.BusinessRules
{
    public interface IEditorialBusiness
    {
        Task<ResponseBase<List<Editoriale>>> GetAll();
        Task<ResponseBase<Editoriale>> GetFind(int id);
        Task<ResponseBase<Editoriale>> Create(EditorialeDTO data);
        Task<ResponseBase<Editoriale>> Update(EditorialeDTO data);
        Task<ResponseBase<Editoriale>> delete(int id);
    }
}
