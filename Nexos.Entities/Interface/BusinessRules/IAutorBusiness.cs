using Nexos.Entities.DTO;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Entities.Interface.BusinessRules
{
    public interface IAutorBusiness
    {
        Task<ResponseBase<List<Autore>>> GetAll();
        Task<ResponseBase<Autore>> GetFind(int id);
        Task<ResponseBase<Autore>> Create(AutoreDTO data);
        Task<ResponseBase<Autore>> Update(AutoreDTO data);
        Task<ResponseBase<Autore>> delete(int id);
    }
}
